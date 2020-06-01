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
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            sfAvAvatar.ImageSource = MainPage.Avatar.Arquivo;
            pbDinheiro.Percentage = (float)MainPage.dinheiro;
            pbHumor.Percentage = (float)MainPage.humor;
            pbConhecimento.Percentage = (float)MainPage.conhecimento;

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
            setHumor(Alternativa.Felicidade);
            setConhecimento(Alternativa.Conhecimento);
        }

        private void setDinheiro(double valor)
        {
            MainPage.dinheiro += (valor * 2) / 100;
            pbDinheiro.Percentage = (float)MainPage.dinheiro;
        }
        private void setHumor(double valor)
        {
            MainPage.humor += (valor * 2) / 100;
            pbHumor.Percentage = (float)MainPage.humor;
        }
        private void setConhecimento(double valor)
        {
            MainPage.conhecimento += (valor * 2) / 100;
            pbConhecimento.Percentage = (float)MainPage.conhecimento;
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

    }
}