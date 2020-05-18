using FinancesPlay.Desserializar;
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
        public static ListaPerguntas lstPergunta = LerJson();

        public MainPage()
        {
            InitializeComponent();
            Sons.carregarSons();
        }
        public static ListaPerguntas LerJson()
        {
            string jsonFileName = "dados.json";
            string nomePasta = "Desserializar";
            ListaPerguntas PerguntaList = new ListaPerguntas();
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{nomePasta}.{jsonFileName}");
            using (var reader = new System.IO.StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();

                //Convert Objetos JSON para uma lista generica
                PerguntaList = JsonConvert.DeserializeObject<ListaPerguntas>(jsonString);
            }
            return PerguntaList;
        }

        public void BtComecar_Clicked(object sender, EventArgs e)
        {
            Sons.clique.Play();

            Navigation.PushAsync(new Paginas.SelecionarAvatar());
        }
    }
}
