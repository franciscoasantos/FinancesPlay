﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FinancesPlay.Model.Perguntas
{
    public class Pergunta
    {
        public int IdPergunta { get; set; }
        public string TextoPergunta { get; set; }
        public List<Alternativa> Alternativas { get; set; }
    }
}