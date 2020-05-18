using FinancesPlay.Desserializar;
using FinancesPlay.Imagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
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
        public static Avatar Avatar;

        public int idPergunta = 1;
        public Pergunta(Avatar avatar)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Avatar = avatar;
            sfAvAvatar.ImageSource = avatar.Arquivo;
            dinheiro = 0.5;
            humor = 0.5;
            conhecimento = 0;
            
        }
        protected override void OnAppearing()
        {
            try
            {
                pbDinheiro.Percentage = (float)dinheiro;
                pbHumor.Percentage = (float)humor;
                pbConhecimento.Percentage = (float)conhecimento;

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
            Navigation.PushAsync(new Paginas.Resposta(this.alternativaA),false);
        }

        private void btnAlternativaB_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Paginas.Resposta(this.alternativaB),false);
        }
    }
}