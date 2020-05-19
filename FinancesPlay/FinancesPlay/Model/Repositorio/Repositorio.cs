using FinancesPlay.Model.Perguntas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FinancesPlay.Model.Repositorio
{
    public class Repositorio
    {
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

        public Pergunta GetPerguntaById(int idPergunta)
        {
            return (from pergunta in MainPage.lstPergunta.Perguntas
                             where (pergunta.IdPergunta == idPergunta)
                             select pergunta).First();
        }
        public Alternativa GetAlternativa(Pergunta pergunta, string alternativa)
        {
            return pergunta.Alternativas.First(alt => alt.IdAlternativa.Equals(alternativa));
        }
    }
}
