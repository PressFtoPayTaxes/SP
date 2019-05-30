using System;
using System.Threading;
using System.Media;
using System.IO;

namespace ThreadsPartOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread musicThread = new Thread(PlayMusic);
            musicThread.IsBackground = true;
            musicThread.Start("shrek_09. Smash Mouth - All Star.wav");

            Console.WriteLine("Enter your text here:");

            var text = new TextForSaving();
            text.FilePath = "text.txt";
            text.Text = Console.ReadLine();

            Thread savingThread = new Thread(SavingInFile);
            savingThread.Start(text);
        }

        private static void PlayMusic(object audioFile)
        {
            var audio = audioFile as string;
            var player = new SoundPlayer(audio);
            player.PlayLooping();
        }

        private static void SavingInFile(object textForSaving)
        {
            var text = textForSaving as TextForSaving;

            using (var writer = new StreamWriter(text.FilePath))
            {
                writer.WriteLine(text.Text);
            }
        }
    }
}
