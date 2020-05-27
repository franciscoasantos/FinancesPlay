using FinancesPlay.Model.Perguntas;
using FinancesPlay.Model.Sons;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancesPlay.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Resposta : ContentPage
    {
        private Alternativa Alternativa;
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
            if (Alternativa.Certa)
            {
                Sons.dinheiro.Play();
            }
            else
            {
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
    }
}