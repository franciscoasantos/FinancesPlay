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
        public Alternativa alternativaA { get; set; }
        public Alternativa alternativaB { get; set; }
        public static double dinheiro { get; set; }
        public static double humor { get; set; }
        public static double conhecimento { get; set; }

        public int idPergunta = 1;
        public Pergunta()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        protected override void OnAppearing()
        {
            try
            {
                pbDinheiro.ProgressTo(pbDinheiro.Progress += dinheiro, 500, Easing.Linear);
                pbHumor.ProgressTo(pbHumor.Progress += humor, 500, Easing.Linear);
                pbConhecimento.ProgressTo(pbConhecimento.Progress += conhecimento, 500, Easing.Linear);

                var perguntas = (from pergunta in MainPage.lstPergunta.Perguntas
                                 where (pergunta.IdPergunta == idPergunta)
                                 select pergunta).First();

                this.alternativaA = perguntas.Alternativas.First(alt => alt.IdAlternativa.Equals("A"));
                this.alternativaB = perguntas.Alternativas.First(alt => alt.IdAlternativa.Equals("B"));

                lblPergunta.Text = perguntas.TextoPergunta;

                btnAlternativaA.Text = this.alternativaA.Texto;
                btnAlternativaB.Text = this.alternativaB.Texto;

                idPergunta++;
            }
            catch (Exception)
            {
                lblPergunta.Text = "Fim do jogo!";
                btnAlternativaA.IsVisible = false;
                btnAlternativaB.IsVisible = false;
            }
        }

        private void btnAlternativaA_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Paginas.Resposta(this.alternativaA));
        }

        private void btnAlternativaB_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Paginas.Resposta(this.alternativaB));
        }
    }
}