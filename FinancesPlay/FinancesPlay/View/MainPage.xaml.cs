using FinancesPlay.Model.Perguntas;
using FinancesPlay.Model.Repositorio;
using FinancesPlay.Model.Sons;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace FinancesPlay
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static ListaPerguntas lstPergunta;

        public MainPage()
        {
            InitializeComponent();

            Sons.carregarSons();
            lstPergunta = new Repositorio().LerJson();
        }

        public void BtComecar_Clicked(object sender, EventArgs e)
        {
            Sons.clique.Play();

            Navigation.PushAsync(new View.SelecionarAvatar());
        }
    }
}
