﻿using FinancesPlay.Desserializar;
using System;
using FinancesPlay.Paginas;
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
        private Alternativa Alternativa;
        public Resposta(Alternativa Alternativa)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            this.Alternativa = Alternativa;

            lblDica.Text = Alternativa.Dica;

            //Métodos para incrementar os valores na barra de status
            setDinheiro(Alternativa.Dinheiro);
            setHumor(Alternativa.Felicidade);
            setConhecimento(Alternativa.Conhecimento);
        }
        
        private void setDinheiro(double valor)
        {
            Pergunta.dinheiro += (valor * 2) / 100;
            pbDinheiro.ProgressTo(pbDinheiro.Progress += Pergunta.dinheiro, 500, Easing.Linear);
        }
        private void setHumor(double valor)
        {
            Pergunta.humor += (valor * 2) / 100;
            pbHumor.ProgressTo(pbHumor.Progress += Pergunta.humor, 500, Easing.Linear);
        }
        private void setConhecimento(double valor)
        {
            Pergunta.conhecimento += (valor * 2) / 100;
            pbConhecimento.ProgressTo(pbConhecimento.Progress += Pergunta.conhecimento, 500, Easing.Linear);
        }
        private void btnContinuar_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Alternativa.Explicacao))
            {
                DisplayAlert("É bom saber!", Alternativa.Explicacao, "Entendi");
            }
            Sons.clique.Play();
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}