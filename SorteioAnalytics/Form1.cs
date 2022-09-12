using MySql.Data.MySqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SorteioAnalytics.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SorteioAnalytics
{
    public partial class Form1 : Form
    {
        private string servidor = "localhost";
        private string database = "loteria_lotep";
        private string usuario = "root";
        private string senha = "";
        private const string NomeLoteria = "Nome da Loteria: ";
        private const string DataInicio = "Início: ";
        private const string DataFim = "Fim: ";
        private List<RelatorioCombinacoes> Relatorios;

        public Form1()
        {
            InitializeComponent();
            AlimentarCombobox();
        }

        private void AlimentarCombobox()
        {
            var mConn = new MySqlConnection($" Persist Security Info=False;server={servidor};database={database};uid={usuario};server = {servidor}; database = {database}; uid = {usuario}; pwd = {senha}");

            try
            {
                mConn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                MessageBox.Show("Erro ao tentar alimentar o combobox de extrações", "Erro Conexão Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (mConn.State == ConnectionState.Open)
            {
                var sqlCommand = $"SELECT Distinct extracao_loteria FROM combinacoes";
                var command = new MySqlCommand(sqlCommand, mConn);
                var mySqlData = command.ExecuteReader();

                while (mySqlData.Read())
                {
                    var nomeExtracao = mySqlData.GetString(0);
                    cbExtracoes.Items.Add(nomeExtracao);
                }

                cbExtracoes.SelectedIndex = 0;
            }                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dataInicio = $"{calendarInicio.Value.Year}/{calendarInicio.Value.Month}/{calendarInicio.Value.Day}";
            var dataFim = $"{calendarFim.Value.Year}/{calendarFim.Value.Month}/{calendarFim.Value.Day}";
            var filtro = new Tuple<string, string, string>(cbExtracoes.SelectedItem.ToString(), dataInicio, dataFim);
            BuscaCombinacoes(filtro);
        }

        public Tuple<string, string, string> GetFiltroRelatorio(string nomeArquivo)
        {
            var CurrentDirectory = Directory.GetCurrentDirectory();

            foreach (string line in File.ReadLines(CurrentDirectory + $"\\Arquivos\\{nomeArquivo}"))
            {
                var itens = line.Split('|');
                var dataInicio = $"{itens[3]}/{itens[2]}/{itens[1]}";
                var dataFim = $"{itens[6]}/{itens[5]}/{itens[4]}";
                return new Tuple<string, string, string>(itens[0], dataInicio, dataFim);
            }

            return null;
        }

        public void BuscaCombinacoes(Tuple<string, string, string> filtro)
        {
            Relatorios = new List<RelatorioCombinacoes>();
            var msgSaida = "";
            var relatorioComb = new Dictionary<string, int>();
            var relatorioDez = new Dictionary<string, int>();
            var relatorioCent = new Dictionary<string, int>();
            var relatorioMilha = new Dictionary<string, int>();
            var mConn = new MySqlConnection($" Persist Security Info=False;server={servidor};database={database};uid={usuario};server = {servidor}; database = {database}; uid = {usuario}; pwd = {senha}");
            try
            {
                mConn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                MessageBox.Show(e.Message.ToString(), "Erro Conexão Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (mConn.State == ConnectionState.Open)
            {
                var sqlCommandSemFiltroExtr = $"SELECT * FROM combinacoes WHERE data_loteria BETWEEN '{filtro.Item2}' and  '{filtro.Item3}'";
                var sqlCommandCompleto = $"SELECT * FROM combinacoes WHERE extracao_loteria = '{filtro.Item1}' and data_loteria BETWEEN '{filtro.Item2}' and  '{filtro.Item3}'";
                var command = new MySqlCommand(ckbFiltroExt.Checked ? sqlCommandCompleto : sqlCommandSemFiltroExtr, mConn);
                var mySqlData = command.ExecuteReader();

                if (!mySqlData.HasRows)
                {
                    msgSaida = $"A loteria {filtro.Item1} não possui registro no período entre {calendarInicio.Value.ToShortDateString()} e {calendarFim.Value.ToShortDateString()}";
                    MessageBox.Show(msgSaida,"Sem Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var combinacoes = new List<Combinacao>();
                while (mySqlData.Read())
                {
                    var combinacao = new Combinacao();
                    combinacao.id_loteria = Convert.ToInt32(mySqlData.GetString(0));
                    combinacao.extracao_loteria = mySqlData.GetString(1);
                    combinacao.loteria_loteria = mySqlData.GetString(2);
                    combinacao.data_loteria = mySqlData.GetString(3);
                    RankingDezCentMilha(mySqlData, relatorioDez, relatorioCent, relatorioMilha);
                    RankingCombinacoes(mySqlData, relatorioComb);
                    combinacoes.Add(combinacao);
                }

                var relCombOrd = relatorioComb.OrderByDescending(it => it.Value).ToList();
                var relDezOrd = relatorioDez.OrderByDescending(it => it.Value).ToList();
                var relCentOrd = relatorioCent.OrderByDescending(it => it.Value).ToList();
                var relMilhaOrd = relatorioMilha.OrderByDescending(it => it.Value).ToList();
                Relatorios.Add(new RelatorioCombinacoes(combinacoes, relCombOrd, relDezOrd, relCentOrd, relMilhaOrd));
                var nomeFiltro1 = ckbFiltroExt.Checked ? filtro.Item1.Replace(":", "_") : "Todas";
                var nomeArquivo = $"relatorio_{nomeFiltro1}_{calendarInicio.Value.ToShortDateString().Replace("/", "_")}_{calendarFim.Value.ToShortDateString().Replace("/", "_")}";
                RelatorioTxt(nomeArquivo + ".txt");
                RelatorioExcel(nomeArquivo + ".xlsx");
                var CurrentDirectory = Directory.GetCurrentDirectory();
                var fullPath = CurrentDirectory + $"\\Arquivos\\{nomeArquivo}";
                MessageBox.Show("Relatórios na pasta " + fullPath, "Relatório Combinações", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            mConn.Close();
            Console.WriteLine("\nFIM da BUSCA\n");
            return;
        }

        public string Numero2Digitos(int numero)
        {
            return numero < 10 ? $"0{numero}" : numero.ToString();
        }

        public string Numero3Digitos(int numero)
        {
            var result = numero < 100 ? $"0{numero}" : numero.ToString();
            result = numero < 10 ? $"00{numero}" : result;
            return result;
        }

        public string Numero4Digitos(int numero)
        {
            var result = numero < 1000 ? $"0{numero}" : numero.ToString();
            result = numero < 100 ? $"00{numero}" : result;
            result = numero < 10 ? $"000{numero}" : result;
            
            return result;
        }

        //public Tuple<string, string, string> AtualizarFiltro()
        //{
        //    var filtro = GetFiltroRelatorio("Filtros.txt");
        //    lblNomeLoteria.Text = NomeLoteria + filtro.Item1;
        //    lblDataInicio.Text = DataInicio + filtro.Item2;
        //    lblDataFim.Text = DataFim + filtro.Item3;

        //    return filtro;
        //}

        public void RelatorioTxt(string nomeArquivo)
        {
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var fullPath = CurrentDirectory + $"\\Arquivos\\{nomeArquivo}";
            if (File.Exists(fullPath))
                File.Delete(fullPath);
            FileStream objFileStrm = File.Create(fullPath);
            objFileStrm.Close();

            var nomeExtracoes = Relatorios[0].Combinacao.FirstOrDefault().extracao_loteria;
            var totalExtracoes = Relatorios[0].Combinacao.Count();
            var rankingComp = Relatorios[0].RankingCombinacoes;
            var rankingDez = Relatorios[0].RankingDezenas;
            var rankingCent = Relatorios[0].RankingCentenas;
            var rankingMilh = Relatorios[0].RankingMilhares;

            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                var nomeExtr = !ckbFiltroExt.Checked ? "Todas" : nomeExtracoes;
                writer.WriteLine($"Loteria: {nomeExtr} DataInício: {calendarInicio.Value.ToShortDateString()} DataFim: {calendarFim.Value.ToShortDateString()}");
                writer.WriteLine($"Total de Extrações: {totalExtracoes}\n");
                InsereTxt(rankingComp, writer, "Ranking de Combinações");
                InsereTxt(rankingDez, writer, "Ranking de Dezenas");
                InsereTxt(rankingCent, writer, "Ranking de Centenas");
                InsereTxt(rankingMilh, writer, "Ranking de Milhares");                    
            }
        }

        public void InsereTxt(List<KeyValuePair<string,int>> rankingComp, StreamWriter writer, string nomeRanking)
        {
            int i = 0;
            writer.WriteLine(nomeRanking);
            foreach (var item in rankingComp)
            {
                if (i > 9)
                    break;
                writer.WriteLine($"{item.Key} -> {item.Value}");
                i++;
            }
            writer.WriteLine();
        }

        public void RelatorioExcel(string nomeArquivo)
        {
            if (Relatorios == null || Relatorios.Count() < 1)
            {
                MessageBox.Show("O relatório de combinações não foi montado", "Relatório Combinações", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var excel = CriarExcel();

            foreach (var relatorio in Relatorios)
            {
                var nomeLoteriaOriginal = !ckbFiltroExt.Checked ? "Todas" : relatorio.Combinacao.FirstOrDefault().extracao_loteria;
                var nomeLoteria = !ckbFiltroExt.Checked ? "Todas" : relatorio.Combinacao.FirstOrDefault().extracao_loteria.Replace(":","_");
                CriarPlanilha(excel, nomeLoteria);

                var workSheet = excel.Workbook.Worksheets[nomeLoteria];

                workSheet.Cells[1, 1].Value = "Extração";
                workSheet.Cells[1, 2].Value = "Data de Início";
                workSheet.Cells[1, 3].Value = "Data de Fim";
                workSheet.Cells[1, 4].Value = "Quantidade de Registros";

                workSheet.Cells[2, 1].Value = nomeLoteriaOriginal;
                workSheet.Cells[2, 2].Value = calendarInicio.Value.ToShortDateString();
                workSheet.Cells[2, 3].Value = calendarFim.Value.ToShortDateString();
                workSheet.Cells[2, 4].Value = relatorio.Combinacao.Count();

                // Define o cabeçalho da planilha(base 1)
                InserePlanilha(workSheet, relatorio.RankingCombinacoes, "Combinação", 1);
                InserePlanilha(workSheet, relatorio.RankingDezenas, "Dezenas", 4);
                InserePlanilha(workSheet, relatorio.RankingCentenas, "Centenas", 7);              
                InserePlanilha(workSheet, relatorio.RankingMilhares, "Milhares", 10);              

                // Ajusta o tamanho da coluna
                workSheet.Column(1).AutoFit();
                workSheet.Column(2).AutoFit();
                workSheet.Column(3).AutoFit();
                workSheet.Column(4).AutoFit();
                workSheet.Column(5).AutoFit();
                workSheet.Column(6).AutoFit();
                workSheet.Column(7).AutoFit();
                workSheet.Column(8).AutoFit();
                workSheet.Column(9).AutoFit();
                workSheet.Column(10).AutoFit();
            }

            var fullPathExcel = Directory.GetCurrentDirectory() + $"\\Arquivos\\{nomeArquivo}";
            if (File.Exists(fullPathExcel))
                File.Delete(fullPathExcel);
            FileStream objFileStrm = File.Create(fullPathExcel);
            objFileStrm.Close();
            File.WriteAllBytes(fullPathExcel, excel.GetAsByteArray());
            excel.Dispose();
        }

        public ExcelPackage CriarExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();

            return excel;
        }

        public void CriarPlanilha(ExcelPackage excel, string WorkSheetName)
        {
            var workSheet = excel.Workbook.Worksheets.Add(WorkSheetName);
            // define propriedades da planilha
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            // Define propriedades da primeira linha
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;
        }

        public void InserePlanilha(ExcelWorksheet workSheet, List<KeyValuePair<string,int>> ranking, string textCabecalho, int coluna)
        {
            workSheet.Cells[4, coluna].Value = textCabecalho;
            workSheet.Cells[4, coluna+1].Value = "Quantidade de Repetições";
            workSheet.Row(4).Height = 20;
            workSheet.Row(4).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Row(4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(4).Style.Font.Bold = true;

            int indice = 5;
            foreach (var item in ranking)
            {
                workSheet.Cells[indice, coluna].Value = item.Key;
                workSheet.Cells[indice, coluna+1].Value = item.Value;
                indice++;
            }
        }

        public string RelatorioComb(Tuple<string,string,string> filtro, List<Combinacao> combinacoes, List<KeyValuePair<string,int>> relatorioOrdenado)
        {
            var totalExtracoes = combinacoes.Count();
            int j = 0;
            Console.WriteLine($"Loteria {filtro.Item1} -> {totalExtracoes}");
            var msgSaida = $"Loteria {filtro.Item1} -> {totalExtracoes}\n\n";
            foreach (var item in relatorioOrdenado)
            {
                if (j > 9)
                    break;
                Console.WriteLine($"Comb: {item.Key} -> {item.Value}");
                msgSaida += $"Comb: {item.Key} -> {item.Value}\n";
                j++;
            }

            return msgSaida;
        }

        public void RankingDezCentMilha(MySqlDataReader mySqlData, Dictionary<string, int> relatorioDez, Dictionary<string, int> relatorioCent, Dictionary<string, int> relatorioMilha)
        {
            for (int i = 4; i < 9; i++)
            {
                var sorteio = Convert.ToInt32(mySqlData.GetString(i));
                var dezena = sorteio % 100;
                var centena = sorteio % 1000;
                var milhar = sorteio % 10000;
                var keyDez = Numero2Digitos(dezena);
                var keyCent = Numero3Digitos(centena);
                var keyMilha = Numero4Digitos(milhar);
                if (relatorioDez.ContainsKey(keyDez))
                    relatorioDez[keyDez] += 1;
                else
                    relatorioDez[keyDez] = 1;

                if (relatorioCent.ContainsKey(keyCent))
                    relatorioCent[keyCent] += 1;
                else
                    relatorioCent[keyCent] = 1;

                if (relatorioMilha.ContainsKey(keyMilha))
                    relatorioMilha[keyMilha] += 1;
                else         
                    relatorioMilha[keyMilha] = 1;
            }
        }

        public void RankingCombinacoes(MySqlDataReader mySqlData, Dictionary<string, int> relatorioComb)
        {
            for (int i = 9; i < 19; i++)
            {
                var comb = mySqlData.GetString(i).Trim().Split('x');
                var combinacaoInt = new List<int>() { Convert.ToInt32(comb[0].Trim()), Convert.ToInt32(comb[1].Trim()), Convert.ToInt32(comb[2].Trim()) };
                var combOrdenada = combinacaoInt.OrderBy(it => it).ToList();
                var key = $"{Numero2Digitos(combOrdenada[0])}x{Numero2Digitos(combOrdenada[1])}x{Numero2Digitos(combOrdenada[2])}";
                if (relatorioComb.ContainsKey(key))
                    relatorioComb[key] += 1;
                else
                    relatorioComb[key] = 1;
            }
        }

        private void cbExtracoes_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
