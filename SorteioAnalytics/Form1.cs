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
            AtualizarFiltro();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filtro = AtualizarFiltro(); ;
            BuscaCombinacoes(filtro);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AtualizarFiltro();
            RelatorioExcel("relatorio.xlsx");
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
            var relatorio = new Dictionary<string, int>();
            var mConn = new MySqlConnection($" Persist Security Info=False;server={servidor};database={database};uid={usuario};server = {servidor}; database = {database}; uid = {usuario}; pwd = {senha}");
            try
            {
                mConn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                MessageBox.Show(e.Message.ToString(), "Error no Servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (mConn.State == ConnectionState.Open)
            {
                //var sqlCommand = "SELECT loteria_loteria, count(*) FROM `combinacoes` group by loteria_loteria";
                var sqlCommand = $"SELECT * FROM combinacoes WHERE loteria_loteria = '{filtro.Item1}' and data_loteria BETWEEN '{filtro.Item2}' and  '{filtro.Item3}'";

                var command = new MySqlCommand(sqlCommand, mConn);
                var mySqlData = command.ExecuteReader();

                if (!mySqlData.HasRows)
                {
                    Console.WriteLine($"A loteria {filtro.Item1} não possui registro no período entre {filtro.Item2} e {filtro.Item3}");
                    msgSaida = $"A loteria {filtro.Item1} não possui registro no período entre {filtro.Item2} e {filtro.Item3}";
                    MessageBox.Show(msgSaida,"Sem Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var cont = 0;
                var combinacoes = new List<Combinacao>();
                while (mySqlData.Read())
                {
                    var combinacao = new Combinacao();
                    combinacao.id_loteria = Convert.ToInt32(mySqlData.GetString(0));
                    combinacao.extracao_loteria = mySqlData.GetString(1);
                    combinacao.loteria_loteria = mySqlData.GetString(2);
                    combinacao.data_loteria = mySqlData.GetString(3);
                    var testeData = Convert.ToDateTime(combinacao.data_loteria);
                    for (int i = 9; i < 19; i++)
                    {
                        //var id = mySqlData.GetString(0);
                        //var data = Convert.ToDateTime(mySqlData.GetString(3));
                        //Console.WriteLine($"{id} -> {data}");
                        var comb = mySqlData.GetString(i).Trim().Split('x');
                        var combinacaoInt = new List<int>() { Convert.ToInt32(comb[0].Trim()), Convert.ToInt32(comb[1].Trim()), Convert.ToInt32(comb[2].Trim()) };
                        var combOrdenada = combinacaoInt.OrderBy(it => it).ToList();
                        var key = $"{Numero2Digitos(combOrdenada[0])}{Numero2Digitos(combOrdenada[1])}{Numero2Digitos(combOrdenada[2])}";
                        if (relatorio.ContainsKey(key))
                            relatorio[key] += 1;
                        else
                            relatorio[key] = 1;
                        i++;
                    }
                    cont++;
                    combinacoes.Add(combinacao);
                }
                Console.WriteLine($"Total: {cont}");

                var relatorioOrdenado = relatorio.OrderByDescending(it => it.Value).ToList();
                Relatorios.Add(new RelatorioCombinacoes(combinacoes, relatorioOrdenado));
                int j = 0;
                Console.WriteLine($"Loteria {filtro.Item1} -> {cont}");
                msgSaida = $"Loteria {filtro.Item1} -> {cont}\n\n";
                foreach (var item in relatorioOrdenado)
                {
                    if (j > 9)
                        break;
                    Console.WriteLine($"Comb: {item.Key} -> {item.Value}");
                    msgSaida += $"Comb: {item.Key} -> {item.Value}\n";
                    j++;
                }
                RelatorioTxt(msgSaida, $"relatorio_{filtro.Item1}_{filtro.Item2.Replace("/","_")}_{filtro.Item3.Replace("/", "_")}.txt");
                MessageBox.Show(msgSaida, "Relatório Combinações", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            mConn.Close();
            
            Console.WriteLine("\n FIM da BUSCA \n");

            return;
        }

        public string Numero2Digitos(int numero)
        {
            return numero >= 10 ? numero.ToString() : $"0{numero}";
        }

        public Tuple<string, string, string> AtualizarFiltro()
        {
            var filtro = GetFiltroRelatorio("Filtros.txt");
            lblNomeLoteria.Text = NomeLoteria + filtro.Item1;
            lblDataInicio.Text = DataInicio + filtro.Item2;
            lblDataFim.Text = DataFim + filtro.Item3;

            return filtro;
        }

        public static void RelatorioTxt(string msg, string nomeArquivo)
        {
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var fullPath = CurrentDirectory + $"\\Arquivos\\{nomeArquivo}";
            if (File.Exists(fullPath))
                File.Delete(fullPath);
            FileStream objFileStrm = File.Create(fullPath);
            objFileStrm.Close();
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                writer.WriteLine(msg);
            }
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
                var nomeLoteria = relatorio.Combinacao.FirstOrDefault().loteria_loteria;
                CriarPlanilha(excel, nomeLoteria);

                var workSheet = excel.Workbook.Worksheets[nomeLoteria];

                workSheet.Cells[1, 1].Value = "Loteria";
                workSheet.Cells[1, 2].Value = "Data de Início";
                workSheet.Cells[1, 3].Value = "Data de Fim";
                workSheet.Cells[1, 4].Value = "Quantidade de Registros";

                workSheet.Cells[2, 1].Value = nomeLoteria;
                workSheet.Cells[2, 2].Value = lblDataInicio.Text;
                workSheet.Cells[2, 3].Value = lblDataFim.Text;
                workSheet.Cells[2, 4].Value = relatorio.Combinacao.Count();

                // Define o cabeçalho da planilha(base 1)
                workSheet.Cells[4, 1].Value = "Combinação";
                workSheet.Cells[4, 2].Value = "Quantidade de Repetições";
                workSheet.Row(4).Height = 20;
                workSheet.Row(4).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                workSheet.Row(4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(4).Style.Font.Bold = true;

                int indice = 5;
                foreach (var item in relatorio.RankingCombinacoes)
                {
                    workSheet.Cells[indice, 1].Value = item.Key;
                    workSheet.Cells[indice, 2].Value = item.Value;
                    indice++;
                }

                // Ajusta o tamanho da coluna
                workSheet.Column(1).AutoFit();
                workSheet.Column(2).AutoFit();
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
    }
}
