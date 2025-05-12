using System;
using System.Threading;

class Program
{
    static int width = 40;
    static int height = 20;
    static bool gameRunning = true;

    static ConsoleKey currentDirection = ConsoleKey.RightArrow;
    static Thread inputThread;

    static void Main()
    {
        Console.CursorVisible = false;
        Console.SetWindowSize(width, height);
        Console.SetBufferSize(width, height);

        InitializeGame();

        inputThread = new Thread(ReadInput);
        inputThread.Start();

        while (gameRunning)
        {
            Update();
            Thread.Sleep(100); // odświeżanie co 100 ms
        }

        Console.Clear();
        Console.WriteLine("Game Over!");
    }

    static void InitializeGame()
    {
        Console.Clear();
        DrawBorder();
    }

    static void DrawBorder()
    {
        for (int x = 0; x < width; x++)
        {
            Console.SetCursorPosition(x, 0);
            Console.Write("#");

            Console.SetCursorPosition(x, height - 1);
            Console.Write("#");
        }

        for (int y = 0; y < height; y++)
        {
            Console.SetCursorPosition(0, y);
            Console.Write("#");

            Console.SetCursorPosition(width - 1, y);
            Console.Write("#");
        }
    }

    static void ReadInput()
    {
        while (gameRunning)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                // Blokujemy możliwość cofania się
                if ((key == ConsoleKey.UpArrow && currentDirection != ConsoleKey.DownArrow) ||
                    (key == ConsoleKey.DownArrow && currentDirection != ConsoleKey.UpArrow) ||
                    (key == ConsoleKey.LeftArrow && currentDirection != ConsoleKey.RightArrow) ||
                    (key == ConsoleKey.RightArrow && currentDirection != ConsoleKey.LeftArrow))
                {
                    currentDirection = key;
                }
            }

            Thread.Sleep(10);
        }
    }

    static void Update()
    {
        // Na razie nic – tu będzie logika ruchu węża w przyszłości
    }
}
