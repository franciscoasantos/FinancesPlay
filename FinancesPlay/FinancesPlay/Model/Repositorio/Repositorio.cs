using FinancesPlay.Model.Perguntas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FinancesPlay.Model.Repositorio
{
    public class Repositorio
    {
        private HashSet<int> perguntasUsadas = new HashSet<int> { 0 };
        
        public ListaPerguntas LerJson()
        {
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;

            ListaPerguntas PerguntaList = new ListaPerguntas();
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.Model.Perguntas.dados.json");

            using (var reader = new System.IO.StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();

                //Convert Objetos JSON para uma lista generica
                PerguntaList = JsonConvert.DeserializeObject<ListaPerguntas>(jsonString);
            }
            return PerguntaList;
        }

        public Pergunta GetPergunta()
        {
            var idPergunta = ObterIdPerguntaAleatorio();
            perguntasUsadas.Add(idPergunta);

            return MainPage.lstPergunta.Perguntas.Where(p => p.IdPergunta == idPergunta).First();
        }
        public Alternativa GetAlternativa(Pergunta pergunta, string alternativa)
        {
            return pergunta.Alternativas.First(alt => alt.IdAlternativa.Equals(alternativa));
        }
        public int ObterIdPerguntaAleatorio()
        {
            var range = Enumerable.Range(1, MainPage.lstPergunta.Perguntas.Count).Where(i => !perguntasUsadas.Contains(i));
            var rand = new Random();

            int index = rand.Next(0, (MainPage.lstPergunta.Perguntas.Count - 1) - (perguntasUsadas.Count -1));

            return range.ElementAt(index);
        }
    }
}
