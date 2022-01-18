using System;

namespace TicTacTieConsole
{
    class Program
    {
        static void Main()
        {
            TicTacToeEngine.TicTacToeEngine TTTEngine = new TicTacToeEngine.TicTacToeEngine();
            Console.WriteLine(TTTEngine.Board());

            String input = Console.ReadLine();

            while (input != "quit")
            {
                if (input != "reset")
                {
                    if (int.TryParse(input, out int value))
                    {
                        if (TTTEngine.ChooseCell(value))
                        {
                            TTTEngine.AssignCell(value);
                            TTTEngine.CheckWinner();
                            Console.WriteLine(TTTEngine.Board());
                        }
                        input = Console.ReadLine();
                    }
                }
                else
                {
                    TTTEngine.Reset();
                    Console.Clear();
                    Console.WriteLine(TTTEngine.Board());
                    input = Console.ReadLine();
                }
            }
        }
    }
}
