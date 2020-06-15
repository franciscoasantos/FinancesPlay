﻿using FinancesPlay.Model.Imagens;
using FinancesPlay.Model.Perguntas;
using FinancesPlay.Model.Repositorio;
using FinancesPlay.Model.Sons;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace FinancesPlay
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static Avatar Avatar;
        public static string Nome;
        public static ListaPerguntas lstPergunta;
        public static double dinheiro { get; set; }
        public static double humor = 50;
        public static double conhecimento { get; set; }


        public MainPage()
        {
            InitializeComponent();
            
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            imgLogo.Source = ImageSource.FromResource($"{assembly.GetName().Name}.Model.Imagens.logo.png");

            Sons.carregarSons();
            Sons.intro.Play();
            lstPergunta = new Repositorio().LerJson();

        }

        public void BtComecar_Clicked(object sender, EventArgs e)
        {
            Sons.clique.Play();
            Navigation.PushAsync(new View.SelecionarAvatar());
        }
    }
}
