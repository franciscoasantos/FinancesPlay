using FinancesPlay.Desserializar;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinancesPlay
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //Chama método para carregar as perguntas
            LerJson();
        }

        public void LerJson()
        {
            string jsonFileName = "dados.json";
            string nomePasta = "Desserializar";
            ListaPerguntas objPerguntaList = new ListaPerguntas();
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{nomePasta}.{jsonFileName}");
            using (var reader = new System.IO.StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();

                //Convert Objetos JSON para uma lista generica
                objPerguntaList = JsonConvert.DeserializeObject<ListaPerguntas>(jsonString);
            }
        }

        private void BtComecar_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new Pergunta());
        }
    }
}
