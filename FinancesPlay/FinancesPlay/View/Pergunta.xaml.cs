using FinancesPlay.Model.Imagens;
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
        private Model.Perguntas.Pergunta perguntas;
        public static double Dinheiro { get; set; }
        public static double Humor { get; set; }
        public static double Conhecimento { get; set; }

        public int idPergunta = 1;
        public Pergunta()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Avatar = MainPage.Avatar;
            sfAvAvatar.ImageSource = MainPage.Avatar.Arquivo;
            Dinheiro = 0.5;
            Humor = 0.5;
            Conhecimento = 0;

        }
        protected override void OnAppearing()
        {
            try
            {
                pbDinheiro.Percentage = (float)MainPage.dinheiro;
                pbHumor.Percentage = (float)MainPage.humor;
                pbConhecimento.Percentage = (float)MainPage.conhecimento;

                if (perguntas != null && !String.IsNullOrEmpty(perguntas.Explicacao))
                {
                    DisplayAlert("Para conhecimento!", perguntas.Explicacao, "Entendi");
                }

                perguntas = MainPage.lstPergunta.Perguntas.Where(p => p.IdPergunta == idPergunta).First();

                lblPergunta.Text = perguntas.TextoPergunta;

                flAlternativas.Children.Clear();

                foreach (var alternativa in perguntas.Alternativas)
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

                idPergunta++;
            }
            catch (Exception)
            {
                lblPergunta.Text = "Fim do jogo!";
            }
        }
    }
}