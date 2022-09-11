using System.Collections.Generic;

namespace SorteioAnalytics.Modelos
{
    public class RelatorioCombinacoes
    {
        public List<Combinacao> Combinacao;
        public List<KeyValuePair<string, int>> RankingCombinacoes;
        public List<KeyValuePair<string, int>> RankingDezenas;
        public List<KeyValuePair<string, int>> RankingCentenas;        

        public RelatorioCombinacoes(List<Combinacao> combinacoes, List<KeyValuePair<string, int>> rankingComb, List<KeyValuePair<string, int>> rankingDezenas, List<KeyValuePair<string, int>> rankingCentenas)
        {
            Combinacao = combinacoes;
            RankingCombinacoes = rankingComb;
            RankingDezenas = rankingDezenas;
            RankingCentenas = rankingCentenas;
        }
    }
}
