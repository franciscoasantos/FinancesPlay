using Syncfusion.XForms.ProgressBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FinancesPlay.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Fim : ContentPage
    {
        public Fim()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            var conhecimento = MainPage.conhecimento;

            if (conhecimento < 25)
            {
                labelTexto.Text = "Infelizmente, sua pontuação foi muito baixa. Com o conhecimento atual que você possui é muito fácil ficar endividado, tente jogar o novamente ou buscar ajuda profissonal. É muito provável que no futuro, você passará alguma dificuldade financeira.";
                imageFim.Source = ObterImagemFinal("25");
            }
            else if (conhecimento >= 25 && conhecimento < 50)
            {
                labelTexto.Text = "Você possui um conhecimento básico, porém não é o suficiente para ficar livre das dívidas. Talvez você passará alguma dificuldade financeira no futuro.";
                imageFim.Source = ObterImagemFinal("50");
            }
            else if (conhecimento >= 50 && conhecimento < 75)
            {
                labelTexto.Text = "Você possui um conhecimento bom. É provável que no futuro, você não saiba a melhor forma de investir seu dinheiro.";
                imageFim.Source = ObterImagemFinal("75");
            }
            else if (conhecimento >= 75)
            {
                labelTexto.Text = "Excelente! Você possui um ótimo conhecimento financeiro, é bem provável que no futuro você consiga ter uma boa receita de investimentos e será bem difícil de ter alguma instabilidade financeira.";
                imageFim.Source = ObterImagemFinal("100");
            }
        }
        public ImageSource ObterImagemFinal(string nome)
        {
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            return ImageSource.FromResource($"{assembly.GetName().Name}.Model.Imagens.{nome}.png");
        }
    }
}