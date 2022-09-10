using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Sorteio
{
    class Program
    {
        static private string servidor = "localhost";
        static private string database = "loteria_lotep";
        static private string usuario = "root";
        static private string senha = "";

        static void Main(string[] args)
        {
            var resultados = BuscaSorteios();          

            EscreveBanco(resultados);

            Console.WriteLine("FINALIZADO!!!");
            Console.ReadLine();
        }

        private static void EscreveBanco(Dictionary<int, resultadoFinal> resultados)
        {
            var mConn = new MySqlConnection($" Persist Security Info=False;server={servidor};database={database};uid={usuario};server = {servidor}; database = {database}; uid = {usuario}; pwd = {senha}");

            //primeiro deletar os dados da tabela
            try
            {
                mConn.Open();
                var sqlCommandDel = "delete from combinacoes";
                var command = new MySqlCommand(sqlCommandDel, mConn);
                command.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            finally
            {
                mConn.Close();
            }

            //Inserir novos itens
            foreach (var item in resultados)
            {
                try
                {
                    mConn.Open();

                    if (mConn.State == ConnectionState.Open)
                    {
                        var comb = ObterCombinacoes(item.Value);
                        var sqlCommand = "INSERT INTO `combinacoes`(`extracao_loteria`, `loteria_loteria`, `data_loteria`, `resultado1_loteria`, `resultado2_loteria`, `resultado3_loteria`, `resultado4_loteria`, `resultado5_loteria`," +
                        "`combinacao1`, `combinacao2`, `combinacao3`, `combinacao4`, `combinacao5`, `combinacao6`, `combinacao7`, `combinacao8`, `combinacao9`, `combinacao10`)" +
                        $" VALUES ('{item.Value.extracao_loteria}', '{item.Value.loteria_loteria}','{item.Value.data_loteria}'," +
                        $"'{item.Value.sorteios[0]}','{item.Value.sorteios[1]}','{item.Value.sorteios[2]}','{item.Value.sorteios[3]}','{item.Value.sorteios[4]}'," +
                        $"'{item.Value.comb1}'," +
                        $"'{item.Value.comb2}'," +
                        $"'{item.Value.comb3}'," +
                        $"'{item.Value.comb4}'," +
                        $"'{item.Value.comb5}'," +
                        $"'{item.Value.comb6}'," +
                        $"'{item.Value.comb7}'," +
                        $"'{item.Value.comb8}'," +
                        $"'{item.Value.comb9}'," +
                        $"'{item.Value.comb10}')";

                        var command = new MySqlCommand(sqlCommand, mConn);
                        command.ExecuteReader();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                }
                finally
                {
                    mConn.Close();
                }                
            }
        }

        public static List<List<string>> ObterCombinacoes(resultadoFinal sorteio)
        {
            Console.WriteLine($"\nSorteio {sorteio.id_loteria} | Extração: {sorteio.extracao_loteria} | loteria: {sorteio.loteria_loteria}");
            Console.WriteLine($"Data {sorteio.data_loteria.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Resultados:");
            Console.WriteLine($"{sorteio.sorteios[0]}");
            Console.WriteLine($"{sorteio.sorteios[1]}");
            Console.WriteLine($"{sorteio.sorteios[2]}");
            Console.WriteLine($"{sorteio.sorteios[3]}");
            Console.WriteLine($"{sorteio.sorteios[4]}");

            Console.WriteLine($"\nAs dezenas dos sorteios são:");

            var sorteioDezenas = new List<string>();
            foreach (var item in sorteio.sorteios)
            {
                var dezena = item % 100;
                var dezenaTxt = dezena >= 10 ? dezena.ToString() : "0"+dezena ;
                sorteioDezenas.Add(dezenaTxt);
                Console.WriteLine(dezenaTxt);
            }

            Console.WriteLine("\nAs possíveis combinações são:");
            var comb1 = new List<string> { sorteioDezenas[0], sorteioDezenas[1], sorteioDezenas[2] };
            var comb2 = new List<string> { sorteioDezenas[0], sorteioDezenas[1], sorteioDezenas[3] };
            var comb3 = new List<string> { sorteioDezenas[0], sorteioDezenas[1], sorteioDezenas[4] };
            var comb4 = new List<string> { sorteioDezenas[0], sorteioDezenas[2], sorteioDezenas[3] };
            var comb5 = new List<string> { sorteioDezenas[0], sorteioDezenas[2], sorteioDezenas[4] };
            var comb6 = new List<string> { sorteioDezenas[0], sorteioDezenas[3], sorteioDezenas[4] };
            var comb7 = new List<string> { sorteioDezenas[1], sorteioDezenas[2], sorteioDezenas[3] };
            var comb8 = new List<string> { sorteioDezenas[1], sorteioDezenas[2], sorteioDezenas[4] };
            var comb9 = new List<string> { sorteioDezenas[1], sorteioDezenas[3], sorteioDezenas[4] };
            var comb10 = new List<string> { sorteioDezenas[2], sorteioDezenas[3], sorteioDezenas[4] };

            sorteio.comb1 = $"{ sorteioDezenas[0]} x {sorteioDezenas[1]} x {sorteioDezenas[2]}";
            sorteio.comb2 = $"{ sorteioDezenas[0]} x {sorteioDezenas[1]} x {sorteioDezenas[3]}";
            sorteio.comb3 = $"{ sorteioDezenas[0]} x {sorteioDezenas[1]} x {sorteioDezenas[4]}";
            sorteio.comb4 = $"{ sorteioDezenas[0]} x {sorteioDezenas[2]} x {sorteioDezenas[3]}";
            sorteio.comb5 = $"{ sorteioDezenas[0]} x {sorteioDezenas[2]} x {sorteioDezenas[4]}";
            sorteio.comb6 = $"{ sorteioDezenas[0]} x {sorteioDezenas[3]} x {sorteioDezenas[4]}";
            sorteio.comb7 = $"{ sorteioDezenas[1]} x {sorteioDezenas[2]} x {sorteioDezenas[3]}";
            sorteio.comb8 = $"{ sorteioDezenas[1]} x {sorteioDezenas[2]} x {sorteioDezenas[4]}";
            sorteio.comb9 = $"{ sorteioDezenas[1]} x {sorteioDezenas[3]} x {sorteioDezenas[4]}";
            sorteio.comb10 = $"{ sorteioDezenas[1]} x {sorteioDezenas[3]} x {sorteioDezenas[4]}";

            var combinacoes53 = new List<List<string>>() {
                comb1 ,
                comb2 ,
                comb3 ,
                comb4 ,
                comb5 ,
                comb6 ,
                comb7 ,
                comb8 ,
                comb9 ,
                comb10};

            var j = 1;
            foreach (var item in combinacoes53)
            {
                Console.WriteLine($"combinação {j} : {item[0]}x{item[1]}x{item[2]}");
                
                j++;
            }

            return combinacoes53;
        }

        public static Dictionary<int, resultadoFinal> BuscaSorteios()
        {
            var resultadosLoteria = new Dictionary<int, resultadoFinal>();
            var mConn = new MySqlConnection($" Persist Security Info=False;server={servidor};database={database};uid={usuario};server = {servidor}; database = {database}; uid = {usuario}; pwd = {senha}");
            try
            {
                mConn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            if (mConn.State == ConnectionState.Open)
            {
                var sqlCommand = "SELECT * FROM resultados";
                var command = new MySqlCommand(sqlCommand, mConn);
                var mySqlData = command.ExecuteReader();

                while(mySqlData.Read())
                {                    
                    var id = Convert.ToInt32(mySqlData.GetString(0));
                    var extracao = mySqlData.GetString(1);
                    var loteria = mySqlData.GetString(2);
                    var data = Convert.ToDateTime(mySqlData.GetString(3));
                    var results = new resultadoFinal(id, extracao, loteria, data);
                    var result1 = Convert.ToInt32(mySqlData.GetString(6));
                    var result2 = Convert.ToInt32(mySqlData.GetString(11));
                    var result3 = Convert.ToInt32(mySqlData.GetString(16));
                    var result4 = Convert.ToInt32(mySqlData.GetString(21));
                    var x = mySqlData.GetString(26);
                    var result5 = Convert.ToInt32(x);
                    results.sorteios = new List<int>() { result1, result2, result3, result4, result5 };
                    resultadosLoteria[id] = results;
                }
            }
            Console.WriteLine("\n FIM da BUSCA \n");

            Console.WriteLine($"Foram lidos {resultadosLoteria.Count} itens");
            Console.WriteLine("Pressione uma tecla p/ continuar");
            Console.ReadLine();
            return resultadosLoteria;
        }

        public static List<int> GetSorteios(string nomeArquivo)
        {
            var sorteios = new List<int>();
            var CurrentDirectory = Directory.GetCurrentDirectory();

            foreach (string line in File.ReadLines(CurrentDirectory + $"\\Arquivos\\{nomeArquivo}"))
            {
                var sorteio = Convert.ToInt32(line);
                sorteios.Add(sorteio);
            }

            return sorteios;
        }

        public static void EscreveArquivo(List<List<int>> combinacoes, string nomeArquivo)
        {
            var CurrentDirectory = Directory.GetCurrentDirectory();
            var fullPath = CurrentDirectory + $"\\Arquivos\\{nomeArquivo}";
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                var j = 1;
                foreach (var item in combinacoes)
                {
                    writer.WriteLine($"combinação {j} : {item[0]}x{item[1]}x{item[2]}");
                    j++;
                }
            }
        }
    }
}
