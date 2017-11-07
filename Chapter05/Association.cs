using System;

namespace DependencyExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var cPlayer = new CricketPlayer("Hardik Padya");
            Bat bat = new Bat();

            cPlayer.Play(bat);
            bat.StartPlay(cPlayer);

            // Uncomment below lines and comment above two lines to see the output of codes below.
            //Console.WriteLine($"Name of the Player is: {cPlayer.GetPlayerName()}");
            //Console.WriteLine($"Brand of Bat is: {bat.GetBrandName()}");

            Console.ReadKey();
        }
    }

    public class CricketPlayer
    {
        public string PlayerName { get; set; }

        public CricketPlayer(string name)
        {
            PlayerName = name;
        }

        public void Play(Bat bat)
        {
            bat.StartPlay(this);
        }

        public string GetPlayerName()
        {
            return PlayerName;
        }
    }

    public class Bat
    {
        public string BrandName { get; set; }

        public void StartPlay(CricketPlayer player)
        {
            // Do something with the player.
            Console.WriteLine("Player Named as " + player.PlayerName + " is playing.");
            Console.ReadLine();
        }

        public string GetBrandName()
        {
            return "Some Brand Name";
        }
    }
}