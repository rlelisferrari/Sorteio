using System;
using System.Collections.Generic;

namespace Sorteio
{
    public class resultadoFinal
    {
        public int id_loteria;
        public string extracao_loteria;
        public string loteria_loteria;
        public string data_loteria;
        public List<int> sorteios;
        public string comb1;
        public string comb2;
        public string comb3;
        public string comb4;
        public string comb5;
        public string comb6;
        public string comb7;
        public string comb8;
        public string comb9;
        public string comb10;

        public resultadoFinal(int id, string extracao, string loteria, DateTime data)
        {
            id_loteria = id;
            extracao_loteria = extracao;
            loteria_loteria = loteria;
            data_loteria =  $"{data.Year}/{data.Month}/{data.Day}";
            sorteios = new List<int>();
        }
    }
}
