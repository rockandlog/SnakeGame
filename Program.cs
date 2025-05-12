using System;
using System.Threading;

class Program
{
    static int width = 40;
    static int height = 20;
    static bool gameRunning = true;
    static bool multiplayer = false;

    static ConsoleKey currentDirection1 = ConsoleKey.RightArrow;
    static ConsoleKey currentDirection2 = ConsoleKey.D;

    static Thread inputThread;

    static int snake1X, snake1Y;
    static int snake2X, snake2Y;

    static int foodX, foodY;
    static int score1 = 0;
    static int score2 = 0;

    static Random rand = new Random();

    static void Main()
    {
        while (true)
        {
            ShowMenu();

            StartGame();

            Console.Clear();
            Console.WriteLine("Game Over!");
            Console.WriteLine($"Wynik Gracza 1: {score1}");
            if (multiplayer) Console.WriteLine($"Wynik Gracza 2: {score2}");
            Console.WriteLine("Czy chcesz zagrać ponownie? (T/N)");

            var key = Console.ReadKey(true).Key;
            if (key != ConsoleKey.T)
                break;
        }
    }

    static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("=== SNAKE ===");
        Console.WriteLine("1. Gra jednoosobowa");
        Console.WriteLine("2. Gra dwuosobowa");
        Console.WriteLine("3. Wyjście");

        ConsoleKey choice;
        do
        {
            choice = Console.ReadKey(true).Key;
        } while (choice != ConsoleKey.D1 && choice != ConsoleKey.D2 && choice != ConsoleKey.D3);

 feature/testing
        multiplayer = (choice == ConsoleKey.D2);
        if (choice == ConsoleKey.D3) Environment.Exit(0);

        if (choice == ConsoleKey.D1)
            multiplayer = false;
        else if (choice == ConsoleKey.D2)
            multiplayer = true;
        else
            Environment.Exit(0);
 main
    }

    static void StartGame()
    {
        gameRunning = true;

        snake1X = width / 3;
        snake1Y = height / 2;
        snake2X = 2 * width / 3;
        snake2Y = height / 2;

        score1 = 0;
        score2 = 0;

        currentDirection1 = ConsoleKey.RightArrow;
        currentDirection2 = ConsoleKey.D;

        Console.CursorVisible = false;
        Console.SetWindowSize(width, height);
        Console.SetBufferSize(width, height);

        InitializeGame();

        inputThread = new Thread(ReadInput);
        inputThread.Start();

        while (gameRunning)
        {
            Update();
 feature/testing
            Thread.Sleep(multiplayer ? 120 : 100);

            Thread.Sleep(100);
 main
        }

        inputThread.Join();
    }

    static void InitializeGame()
    {
        Console.Clear();
        DrawBorder();
        SpawnFood();
        DrawSnake1();
        if (multiplayer) DrawSnake2();
        DrawScore();
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

    static void DrawSnake1()
    {
        Console.SetCursorPosition(snake1X, snake1Y);
        Console.Write("O");
    }

    static void DrawSnake2()
    {
        Console.SetCursorPosition(snake2X, snake2Y);
        Console.Write("X");
    }

    static void ClearSnake(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(" ");
    }

    static void DrawFood()
    {
        Console.SetCursorPosition(foodX, foodY);
        Console.Write("@");
    }

    static void SpawnFood()
    {
 feature/testing
        do
        {
            foodX = rand.Next(1, width - 1);
            foodY = rand.Next(1, height - 1);
        }
        while ((foodX == snake1X && foodY == snake1Y) ||
               (multiplayer && foodX == snake2X && foodY == snake2Y));


        foodX = rand.Next(1, width - 1);
        foodY = rand.Next(1, height - 1);
 main
        DrawFood();
    }

    static void DrawScore()
    {
        Console.SetCursorPosition(2, 0);
        if (multiplayer)
            Console.Write($"P1: {score1}  P2: {score2}   ");
        else
            Console.Write($"Wynik: {score1}   ");
    }

    static void ReadInput()
    {
        while (gameRunning)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                // Gracz 1 – strzałki
                if ((key == ConsoleKey.UpArrow && currentDirection1 != ConsoleKey.DownArrow) ||
                    (key == ConsoleKey.DownArrow && currentDirection1 != ConsoleKey.UpArrow) ||
                    (key == ConsoleKey.LeftArrow && currentDirection1 != ConsoleKey.RightArrow) ||
                    (key == ConsoleKey.RightArrow && currentDirection1 != ConsoleKey.LeftArrow))
                {
                    currentDirection1 = key;
                }

                // Gracz 2 – WASD
                if (multiplayer)
                {
                    if ((key == ConsoleKey.W && currentDirection2 != ConsoleKey.S) ||
                        (key == ConsoleKey.S && currentDirection2 != ConsoleKey.W) ||
                        (key == ConsoleKey.A && currentDirection2 != ConsoleKey.D) ||
                        (key == ConsoleKey.D && currentDirection2 != ConsoleKey.A))
                    {
                        currentDirection2 = key;
                    }
                }
            }

            Thread.Sleep(10);
        }
    }

    static void Update()
    {
        ClearSnake(snake1X, snake1Y);
        if (multiplayer) ClearSnake(snake2X, snake2Y);

        // Ruch gracza 1
        switch (currentDirection1)
        {
            case ConsoleKey.UpArrow: snake1Y--; break;
            case ConsoleKey.DownArrow: snake1Y++; break;
            case ConsoleKey.LeftArrow: snake1X--; break;
            case ConsoleKey.RightArrow: snake1X++; break;
        }

 feature/testing
        // Kolizja gracza 1 ze ścianą

        // Kolizja gracza 1
 main
        if (snake1X <= 0 || snake1X >= width - 1 || snake1Y <= 0 || snake1Y >= height - 1)
        {
            gameRunning = false;
            return;
        }

 feature/testing
        // Ruch i kolizja gracza 2

        // Gracz 2 (jeśli aktywny)
 main
        if (multiplayer)
        {
            switch (currentDirection2)
            {
                case ConsoleKey.W: snake2Y--; break;
                case ConsoleKey.S: snake2Y++; break;
                case ConsoleKey.A: snake2X--; break;
                case ConsoleKey.D: snake2X++; break;
            }

            if (snake2X <= 0 || snake2X >= width - 1 || snake2Y <= 0 || snake2Y >= height - 1)
            {
                gameRunning = false;
                return;
            }
 feature/testing

            // Kolizja między graczami (głowa w głowę)
            if (snake1X == snake2X && snake1Y == snake2Y)
            {
                gameRunning = false;
                return;
            }

 main
        }

        // Zjedzenie jedzenia
        if (snake1X == foodX && snake1Y == foodY)
        {
            score1++;
            SpawnFood();
            DrawScore();
        }
        else if (multiplayer && snake2X == foodX && snake2Y == foodY)
        {
            score2++;
            SpawnFood();
            DrawScore();
        }

        DrawSnake1();
        if (multiplayer) DrawSnake2();
    }
}
