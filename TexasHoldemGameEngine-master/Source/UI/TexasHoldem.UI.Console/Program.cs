namespace TexasHoldem.UI.Console
{
    using Mogilino;
    using System;

    using TexasHoldem.AI.SmartPlayer;
    using TexasHoldem.Logic.GameMechanics;
    using Logic.Players;
    using System.Collections.Generic;
    using System.IO;

    public static class Program
    {
        private const string ProgramName = "TexasHoldem.UI.Console (c) 2015";
        private const int GameHeight = 12;
        private const int GameWidth = 66;

        public static void Main()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BufferHeight = Console.WindowHeight = GameHeight;
            Console.BufferWidth = Console.WindowWidth = GameWidth;

            ConsoleHelper.WriteOnConsole(GameHeight - 1, GameWidth - ProgramName.Length - 1, ProgramName, ConsoleColor.Green);

            var consolePlayer1 = new ConsoleUiDecorator(new Ignat(), 0, GameWidth, 5);
            var consolePlayer2 = new ConsoleUiDecorator(new SmartPlayer(), 6, GameWidth, 5);

            var winners = new Dictionary<string, int>();

            for (int i = 0; i < 50; i++)
            {
                ITexasHoldemGame game = new TwoPlayersTexasHoldemGame(consolePlayer1, consolePlayer2);
                var winner = game.Start();
                if (!winners.ContainsKey(winner.Name))
                {
                    winners.Add(winner.Name, 1);
                }
                else
                {
                    winners[winner.Name]++;

                }

            }

            string user = "hans";

            string path = @"C:\Users\" + user + @"\Desktop\statistics.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                foreach (var item in winners)
                {
                    sw.Write(item.Key);
                    sw.Write(" - ");
                    sw.WriteLine(item.Value);
                }
                sw.WriteLine();
            }

        }
    }
}
