using System;
using System.Collections.Generic;
using System.Text;

namespace FinancesPlay.Model.Perguntas
{
    public class Alternativa
    {
        public string IdAlternativa { get; set; }
        public string Texto { get; set; }
        public string Dica { get; set; }
        public int Dinheiro { get; set; }
        public int Humor { get; set; }
        public int Conhecimento { get; set; }
        public bool Certa { get; set; }
    }
}
