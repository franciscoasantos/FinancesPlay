using System;
using System.Collections.Generic;
using System.Text;

namespace FinancesPlay.Desserializar
{
    public class Pergunta
    {
        public int IdPergunta { get; set; }
        public string TextoPergunta { get; set; }
        public string Explicacao { get; set; }
        public IList<Alternativa> Alternativas { get; set; }
    }
}
