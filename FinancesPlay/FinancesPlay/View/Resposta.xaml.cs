using FinancesPlay.Model.Imagens;
using FinancesPlay.Model.Perguntas;
using FinancesPlay.Model.Sons;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FinancesPlay.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Resposta : ContentPage
    {
        private Alternativa Alternativa;
        public ObservableCollection<Animacao> animacoes = new ObservableCollection<Animacao>();
        public ObservableCollection<Animacao> Animacoes { get { return animacoes; } }
        public bool IsPlaying { get; set; }

        public Resposta(Alternativa Alternativa)
        {
            InitializeComponent();

            pbDinheiro.Progress = (float)MainPage.dinheiro;
            pbHumor.Progress = (float)MainPage.humor;
            labelHumor.Text = Resposta.RetornarEmoji();
            pbConhecimento.Progress = (float)MainPage.conhecimento;
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            sfAvAvatar.ImageSource = MainPage.Avatar.Arquivo;
            labelNome.Text = MainPage.Nome;


            this.Alternativa = Alternativa;
        }
        protected override void OnAppearing()
        {
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            if (Alternativa.Certa)
            {
                imageAnimacao.Source = ImageSource.FromResource($"{assembly.GetName().Name}.Model.Imagens.certa1.png");
                Sons.dinheiro.Play();
            }
            else
            {
                imageAnimacao.Source = ImageSource.FromResource($"{assembly.GetName().Name}.Model.Imagens.errada1.png");
                Sons.errado.Play();
            }

            lblDica.Text = Alternativa.Dica;

            //Métodos para incrementar os valores na barra de status
            setDinheiro(Alternativa.Dinheiro);
            setHumor(Alternativa.Humor);
            setConhecimento(Alternativa.Conhecimento);
        }

        private void setDinheiro(double valor)
        {
            MainPage.dinheiro += (valor * 1.852);
            pbDinheiro.Progress = (float)MainPage.dinheiro;
        }
        private void setHumor(double valor)
        {
            MainPage.humor += (valor * 2);
            pbHumor.Progress = (float)MainPage.humor;
        }
        private void setConhecimento(double valor)
        {
            MainPage.conhecimento += (valor * 1.3158);
            pbConhecimento.Progress = (float)MainPage.conhecimento;
        }
        private void btnContinuar_Clicked(object sender, EventArgs e)
        {
            Sons.clique.Play();
            Application.Current.MainPage.Navigation.PopAsync(false);
        }

        void criarColecaoAnimacoes()
        {
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            //Carregar avatares
            for (int i = 1; i <= 1; i++)
            {
                animacoes.Add(new Animacao
                {
                    Nome = "certa" + i + ".png",
                    Arquivo = ImageSource.FromResource($"{assembly.GetName().Name}.Model.Imagens.certa" + i + ".png"),
                });
            }
        }

        public static string RetornarEmoji()
        {
            if(MainPage.humor >= 90)
            {
                return "\U0001F929";
            }
            else if(MainPage.humor < 90 && MainPage.humor >= 75)
            {
                return "\U0001F603";
            }
            else if(MainPage.humor < 75 && MainPage.humor >= 65)
            {
                return "\U0001F642";
            }
            else if(MainPage.humor < 65 && MainPage.humor >= 55)
            {
                return "\U0001F928";
            }
            //meio
            else if(MainPage.humor < 55 && MainPage.humor >= 45)
            {
                return "\U0001F610";
            }
            else if(MainPage.humor < 45 && MainPage.humor >= 35)
            {
                return "\U0001F612";
            }
            else if(MainPage.humor < 35 && MainPage.humor >= 25)
            {
                return "\U0001F614";
            }
            else if(MainPage.humor < 25 && MainPage.humor >= 10)
            {
                return "\U0001F97A";
            }
            else if(MainPage.humor < 10)
            {
                return "\U0001F62D";
            }
            else
            {
                return "\U0001F610";
            }
        }

    }
}