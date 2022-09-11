using System.Collections.Generic;

namespace SorteioAnalytics.Modelos
{
    public class RelatorioCombinacoes
    {
        public List<KeyValuePair<string, int>> RankingCombinacoes;
        public List<Combinacao> Combinacao;

        public RelatorioCombinacoes(List<Combinacao> combinacoes)
        {
            Combinacao = new List<Combinacao>();
        }

        public RelatorioCombinacoes(List<Combinacao> combinacoes, List<KeyValuePair<string, int>> ranking)
        {
            Combinacao = combinacoes;
            RankingCombinacoes = ranking;
        }
    }
}
