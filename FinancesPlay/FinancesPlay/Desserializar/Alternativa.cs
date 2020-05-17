using System;
using System.Collections.Generic;
using System.Text;

namespace FinancesPlay.Desserializar
{
    public class Alternativa
    {
        public string IdAlternativa { get; set; }
        public string Texto { get; set; }
        public string Dica { get; set; }
        public string Explicacao { get; set; }
        public int Dinheiro { get; set; }
        public int Felicidade { get; set; }
        public int Conhecimento { get; set; }
    }
}
