using Plugin.SimpleAudioPlayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace FinancesPlay
{
    class Sons
    {
        public static ISimpleAudioPlayer clique { get; set; }
        public static void carregarSons()
        {
            string soundFileName = "click.ogg";
            string nomePasta = "Sons";

            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            var clickSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();

            Stream audioStream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{nomePasta}.{soundFileName}");
            clickSound.Load(audioStream);

            clique = clickSound;
        }
    }
}
