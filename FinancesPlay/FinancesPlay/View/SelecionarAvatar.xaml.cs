using FinancesPlay.Model.Imagens;
using FinancesPlay.Model.Sons;
using Syncfusion.XForms.TextInputLayout;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancesPlay.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelecionarAvatar : ContentPage
    {
        public ObservableCollection<Avatar> avatares = new ObservableCollection<Avatar>();
        public ObservableCollection<Avatar> Avatares { get { return avatares; } }

        public SelecionarAvatar()
        {
            InitializeComponent();
            criarColecaoAvatar();
        }
        void criarColecaoAvatar()
        {
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            cvAvatar.ItemsSource = avatares;
            //Carregar avatares
            for (int i = 1; i <= 8; i++)
            {
                avatares.Add(new Avatar
                {
                    Nome = "avatar" + i + ".png",
                    Arquivo = ImageSource.FromResource($"{assembly.GetName().Name}.Model.Imagens.avatar" + i + ".png"),
                });
            }
        }
        private void btnEscolher_Clicked(object sender, EventArgs e)
        {
            Sons.clique.Play();
            MainPage.Avatar = (Avatar)cvAvatar.CurrentItem;
            MainPage.Nome = inputNome.Text;
            Navigation.PushAsync(new View.Pergunta());
        }
    }
}