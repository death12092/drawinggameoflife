using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace game_of_life
{
    class Program
    {
        static void Main()
        {
            // Menu loop
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Menu ===");
                Console.WriteLine("1. game of life");
                Console.WriteLine("2. ascii art");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    GameOfLife();  // Start
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                }
                else if (input == "3")
                {
                    Console.WriteLine("Goodbye!");  // Exit
                    break;
                }
                else if (input == "2")
                {
                    Drawing();
                }
                else
                {
                    Console.WriteLine("Invalid option.");  // Error
                    Console.ReadKey();
                }
            }
        }

        static void GameOfLife()
        {
            int rows = 20, cols = 40;
            bool[,] board = new bool[rows, cols];
            var rand = new Random();

            // Init board
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    board[r, c] = rand.NextDouble() < 0.3;

            // Game loop
            while (true)
            {
                Console.Clear();

                // Display
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                        Console.Write(board[r, c] ? '█' : '.');
                    Console.WriteLine();
                }

                bool[,] next = new bool[rows, cols];

                // Next gen
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        int neighbors = 0;

                        // Count neighbors
                        for (int dr = -1; dr <= 1; dr++)
                            for (int dc = -1; dc <= 1; dc++)
                            {
                                if (dr == 0 && dc == 0) continue;
                                int nr = r + dr, nc = c + dc;
                                if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && board[nr, nc])
                                    neighbors++;
                            }

                        // Rules
                        next[r, c] = board[r, c] ? neighbors == 2 || neighbors == 3 : neighbors == 3;
                    }
                }

                board = next;

                // Exit key
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                    break;

                Thread.Sleep(200);  // Delay
            }
        }
        static void Drawing()
        {

        }
        static void state1()
        {

        }
        static void state2()
        {

        }
        static void state3()
        {

        }

    }

}