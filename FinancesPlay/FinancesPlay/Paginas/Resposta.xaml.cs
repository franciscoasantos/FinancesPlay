using FinancesPlay.Desserializar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancesPlay.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Resposta : ContentPage
    {
        public Resposta(Alternativa Alternativa)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            lblDica.Text = Alternativa.Dica;
        }

        private void btnContinuar_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PopModalAsync();

        }
    }
}