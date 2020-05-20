using FinancesPlay.Model.Imagens;
using FinancesPlay.Model.Perguntas;
using FinancesPlay.Model.Repositorio;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancesPlay.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pergunta : ContentPage
    {
        public Alternativa alternativaA { get; set; }
        public Alternativa alternativaB { get; set; }

        public Repositorio Repositorio;

        public int idPergunta = 1;
        public Pergunta(Avatar avatar)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            sfAvAvatar.ImageSource = avatar.Arquivo;
            
            MainPage.Avatar = avatar;
            MainPage.dinheiro = 0.5;
            MainPage.humor = 0.5;
            MainPage.conhecimento = 0;
            
            Repositorio = new Repositorio();
        }
        protected override void OnAppearing()
        {
            
            try
            {
                pbDinheiro.Percentage = (float)MainPage.dinheiro;
                pbHumor.Percentage = (float)MainPage.humor;
                pbConhecimento.Percentage = (float)MainPage.conhecimento;

                var pergunta = Repositorio.GetPerguntaById(idPergunta);

                alternativaA = Repositorio.GetAlternativa(pergunta, "A");
                alternativaB = Repositorio.GetAlternativa(pergunta, "B");

                lblPergunta.Text = pergunta.TextoPergunta;
                btnAlternativaA.Text = alternativaA.Texto;
                btnAlternativaB.Text = alternativaB.Texto;

                idPergunta++;
            }
            catch (Exception e)
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
    }
}