using FinancesPlay.Model.Imagens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            Navigation.PushAsync(new View.Pergunta((Avatar)cvAvatar.CurrentItem));
        }
    }
}