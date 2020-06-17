﻿using FinancesPlay.Model.Imagens;
using FinancesPlay.Model.Repositorio;
using Syncfusion.XForms.Buttons;
using Syncfusion.XForms.Graphics;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancesPlay.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pergunta : ContentPage
    {
        public static Avatar Avatar;
        private Repositorio _repo;
        private Model.Perguntas.Pergunta pergunta;
        public static double Dinheiro { get; set; }
        public static double Humor { get; set; }
        public static double Conhecimento { get; set; }

        public Pergunta()
        {
            _repo = new Repositorio();

            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            labelNome.Text = MainPage.Nome;
            Avatar = MainPage.Avatar;
            sfAvAvatar.ImageSource = MainPage.Avatar.Arquivo;
        }
        protected override void OnAppearing()
        {
            try
            {
                pbDinheiro.Progress = (float)MainPage.dinheiro;
                pbHumor.Progress = (float)MainPage.humor;
                labelHumor.Text = Resposta.RetornarEmoji();
                pbConhecimento.Progress = (float)MainPage.conhecimento;

                if (pergunta != null && !String.IsNullOrEmpty(pergunta.Explicacao))
                {
                    DisplayAlert("Para conhecimento!", pergunta.Explicacao, "Entendi");
                }

                pergunta = _repo.GetPergunta();

                lblPergunta.Text = pergunta.TextoPergunta;

                flAlternativas.Children.Clear();

                foreach (var alternativa in pergunta.Alternativas)
                {
                    SfButton botaoAlternativa = new SfButton
                    {
                        Text = alternativa.Texto,
                        Style = (Style)Application.Current.Resources["alternativa"],
                        BackgroundGradient = new SfRadialGradientBrush
                        {
                            Radius = 10,
                            GradientStops = new GradientStopCollection()
                            {
                                new SfGradientStop(){ Color = Color.FromHex("#70A288"), Offset = 0 },
                                new SfGradientStop(){ Color = Color.FromHex("#4B755F"), Offset = 1 }
                            }
                        }
                    };

                    botaoAlternativa.Clicked += (sender, args) => Navigation.PushAsync(new View.Resposta(alternativa), false);

                    flAlternativas.Children.Add(botaoAlternativa);
                }
            }
            catch (Exception ex)
            {
                Navigation.PushAsync(new View.Fim(), false);
            }
        }

        //private void final_Clicked(object sender, EventArgs e)
        //{
        //    MainPage.conhecimento = Convert.ToInt32(input.Text);
        //    Navigation.PushAsync(new View.Fim(), false);
        //}
    }
}