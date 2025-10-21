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
                Console.WriteLine("3. background");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option(the number): ");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    GameOfLife();  // Start
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                }
                else if (input == "4")
                {
                    Console.WriteLine("Goodbye!");  // Exit
                    break;
                }
                else if (input == "2")
                {
                    Drawing();
                }
                else if (input == "3")
                {
                    ASCII2();
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
            // setup
            int width = 40, height = 20;
            bool[,] board = new bool[height, width];
            Random rand = new Random();

            Console.CursorVisible = false;
            Console.Clear(); // clear board

            // make board
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (rand.Next(4) == 0)
                    {
                        board[y, x] = true;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("█");
                    }
                    else
                    {
                        board[y, x] = false;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            int generation = 0; // gen count

            // loop
            while (true)
            {
                // quit key
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Q)
                        break;
                }

                int live = 0, dead = 0; // counts

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int count = 0; // neighbors
                        for (int yy = -1; yy <= 1; yy++)
                        {
                            for (int xx = -1; xx <= 1; xx++)
                            {
                                if (xx == 0 && yy == 0) continue;
                                int nx = x + xx, ny = y + yy;
                                if (nx >= 0 && ny >= 0 && nx < width && ny < height)
                                {
                                    if (board[ny, nx]) count++;
                                }
                            }
                        }

                        bool alive = board[y, x];
                        if (alive && (count < 2 || count > 3))
                        {
                            board[y, x] = false;
                            Console.SetCursorPosition(x, y);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(" ");
                        }
                        else if (!alive && count == 3)
                        {
                            board[y, x] = true;
                            Console.SetCursorPosition(x, y);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("█");
                        }

                        if (board[y, x]) live++;
                        else dead++;
                    }
                }

                // info line
                Console.ResetColor();
                Console.SetCursorPosition(0, height + 1);
                Console.WriteLine($"Generation: {generation}  Live: {live}  Dead: {dead}   (Press Q to return to menu)   ");

                generation++;
                Thread.Sleep(200); // wait
            }

            Console.ResetColor();
            Console.SetCursorPosition(0, height + 3);
            Console.WriteLine("Returning to menu...");
            Thread.Sleep(1000); // short pause
        }
        static void Drawing()
        {
            // Frames
            string[] frames = new string[]
            {
@"
      .-.
     (o.o)
      |=|
     __|__
   //.=|=.\\
  // .=|=. \\
  || .=|=. ||
  || (_=_) ||
  () || || ()
     || ||
     () ()
     || ||
     || ||
    ==' '==
",
@"
      .-.
     (o.o)
      |=|
     __|__
   //.=|=.\\
  // .=|=. \\
  || .=|=. ||
  || (_=_) ||
  () // || ()
    //  ||
   ()   ()
   ||   ||
   ||   ||
  =='   '==
",
@"
      .-.
     (o.o)
      |=|
     __|__
   //.=|=.\\
  // .=|=. \\
  || .=|=. ||
  || (_=_) ||
  () || \\ ()
     ||  \\
     ()   ()
     ||   ||
     ||   ||
    =='   '==
"
            };

            int frameIndex = 0;

            // Loop
            while (true)
            {
                // Key check
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Escape)
                        break;
                }

                // Draw frame
                Console.Clear();
                Console.WriteLine(frames[frameIndex]);
                frameIndex = (frameIndex + 1) % frames.Length;
                Thread.Sleep(300);
            }

            // Return
            Console.Clear();
            Console.WriteLine("Returning...");
            Thread.Sleep(800);
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
        static void ASCII2()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;

            string[] cave = new string[]
            {
        "              __    _    _      __",
        "         ___/  \\__/ \\__/ \\____/  \\___",
        "       _/                              \\_",
        "     _/                                  \\_",
        "    /                                      \\",
        "   /     ^       ^       ^        ^         \\",
        "  /                                          \\",
        " /                                            \\",
        "/______________________________________________\\",
            };

            foreach (string line in cave)
                Console.WriteLine(line);

            Console.ResetColor();
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey(true);
        }
    }
    

}