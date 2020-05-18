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
            NavigationPage.SetHasBackButton(this, false);
            sfAvAvatar.ImageSource = Paginas.Pergunta.Avatar.Arquivo;
            pbDinheiro.Percentage = (float)Paginas.Pergunta.dinheiro;
            pbHumor.Percentage = (float)Paginas.Pergunta.humor;
            pbConhecimento.Percentage = (float)Paginas.Pergunta.conhecimento;

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
            Pergunta.dinheiro += (valor * 2) / 100;
            pbDinheiro.Percentage = (float)Pergunta.dinheiro;
        }
        private void setHumor(double valor)
        {
            Pergunta.humor += (valor * 2) / 100;
            pbHumor.Percentage = (float)Pergunta.humor;
        }
        private void setConhecimento(double valor)
        {
            Pergunta.conhecimento += (valor * 2) / 100;
            pbConhecimento.Percentage = (float)Pergunta.conhecimento;
        }
        private void btnContinuar_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Alternativa.Explicacao))
            {
                DisplayAlert("É bom saber!", Alternativa.Explicacao, "Entendi");
            }
            Sons.clique.Play();
            Application.Current.MainPage.Navigation.PopAsync(false);
        }
    }
}