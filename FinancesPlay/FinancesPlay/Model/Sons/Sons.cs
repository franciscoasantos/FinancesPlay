using Plugin.SimpleAudioPlayer;
using System.IO;
using System.Reflection;

namespace FinancesPlay.Model.Sons
{
    public class Sons
    {
        public static ISimpleAudioPlayer clique { get; set; }
        public static ISimpleAudioPlayer dinheiro { get; set; }
        public static ISimpleAudioPlayer errado { get; set; }
        public static void carregarSons()
        {
            string nomePasta = "Model.Sons";
            string soundFileName;
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream audioStream;

            //Carregar som de clique
            var clickSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            soundFileName = "click.ogg";
            audioStream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{nomePasta}.{soundFileName}");
            clickSound.Load(audioStream);
            clique = clickSound;

            //Carregar som de dinheiro
            var cashSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            soundFileName = "dinheiro.ogg";
            audioStream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{nomePasta}.{soundFileName}");
            cashSound.Load(audioStream);
            dinheiro = cashSound;

            //Carregar som de errado
            var wrongSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            soundFileName = "errado.ogg";
            audioStream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{nomePasta}.{soundFileName}");
            wrongSound.Load(audioStream);
            errado = wrongSound;
        }
    }
}
