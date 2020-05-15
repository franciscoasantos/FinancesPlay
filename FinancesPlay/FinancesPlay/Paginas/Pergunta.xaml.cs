using FinancesPlay.Desserializar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancesPlay.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pergunta : ContentPage
    {
        public Pergunta()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //Atribui lista de perguntas à variável
            var listaPergunta = MainPage.PerguntaList;
            
            int idPergunta = 1;

            var perguntas = (from pergunta in listaPergunta.Perguntas
                             where (pergunta.IdPergunta == idPergunta)
                             select pergunta).First();

            var alternativaA = perguntas.Alternativas.First(alt => alt.IdAlternativa.Equals("A"));
            var alternativaB = perguntas.Alternativas.First(alt => alt.IdAlternativa.Equals("B"));

            lblPergunta.Text = perguntas.TextoPergunta;

            btnAlternativaA.Text = alternativaA.Texto;
            btnAlternativaB.Text = alternativaB.Texto;
        }
    }
}