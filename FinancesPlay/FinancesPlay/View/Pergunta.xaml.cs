using FinancesPlay.Model;
using FinancesPlay.Model.Imagens;
using FinancesPlay.Model.Perguntas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancesPlay.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pergunta : ContentPage
    {
        public Alternativa alternativaA { get; set; }
        public Alternativa alternativaB { get; set; }
        public Alternativa alternativaC { get; set; }
        public static double dinheiro { get; set; }
        public static double humor { get; set; }
        public static double conhecimento { get; set; }
        public static Avatar Avatar;
        private Model.Perguntas.Pergunta perguntas;

        public int idPergunta = 1;
        public Pergunta()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Avatar = MainPage.Avatar;
            sfAvAvatar.ImageSource = MainPage.Avatar.Arquivo;
            dinheiro = 0.5;
            humor = 0.5;
            conhecimento = 0;
            
        }
        protected override void OnAppearing()
        {
            try
            {
                pbDinheiro.Percentage = (float)MainPage.dinheiro;
                pbHumor.Percentage = (float)MainPage.humor;
                pbConhecimento.Percentage = (float)MainPage.conhecimento;

                if (perguntas != null && !String.IsNullOrEmpty(perguntas.Explicacao))
                {
                    DisplayAlert("Para conhecimento!", perguntas.Explicacao, "Entendi");
                }

                perguntas = (from pergunta in MainPage.lstPergunta.Perguntas
                                 where (pergunta.IdPergunta == idPergunta)
                                 select pergunta).First();

                this.alternativaA = perguntas.Alternativas.First(alt => alt.IdAlternativa.Equals("A"));
                this.alternativaB = perguntas.Alternativas.First(alt => alt.IdAlternativa.Equals("B"));
                this.alternativaC = perguntas.Alternativas.First(alt => alt.IdAlternativa.Equals("C"));

                lblPergunta.Text = perguntas.TextoPergunta;

                btnAlternativaA.Text = this.alternativaA.Texto;
                btnAlternativaB.Text = this.alternativaB.Texto;
                btnAlternativaC.Text = this.alternativaC.Texto;

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
            Navigation.PushAsync(new View.Resposta(this.alternativaA),false);
        }

        private void btnAlternativaB_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.Resposta(this.alternativaB),false);
        }

        private void btnAlternativaC_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.Resposta(this.alternativaC), false);
        }
    }
}