using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Form1()
        {
            InitializeComponent();
            AtualizarFiltro();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filtro = AtualizarFiltro(); ;
            var resultados = BuscaCombinacoes(filtro);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AtualizarFiltro();
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

        public Dictionary<string, int> BuscaCombinacoes(Tuple<string, string, string> filtro)
        {
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
                    return relatorio;
                }
                var cont = 0;
                while (mySqlData.Read())
                {
                    var estacao = mySqlData.GetString(2);
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

                }
                Console.WriteLine($"Total: {cont}");

                var relatorioOrdenado = relatorio.OrderByDescending(it => it.Value);
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

            return relatorio;
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

    }
}
