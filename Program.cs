using System;
using System.Threading;

class Program
{
    static int width = 40;
    static int height = 20;
    static bool gameRunning = true;

    static ConsoleKey currentDirection = ConsoleKey.RightArrow;
    static Thread inputThread;

    static int snakeX = width / 2;
    static int snakeY = height / 2;

    static int foodX;
    static int foodY;

    static int score = 0;

    static Random rand = new Random();

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
            Thread.Sleep(100);
        }

        Console.Clear();
        Console.WriteLine("Game Over!");
        Console.WriteLine("Twój wynik: " + score);
    }

    static void InitializeGame()
    {
        Console.Clear();
        DrawBorder();
        SpawnFood();
        DrawSnake();
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

    static void DrawSnake()
    {
        Console.SetCursorPosition(snakeX, snakeY);
        Console.Write("O");
    }

    static void ClearSnake()
    {
        Console.SetCursorPosition(snakeX, snakeY);
        Console.Write(" ");
    }

    static void DrawFood()
    {
        Console.SetCursorPosition(foodX, foodY);
        Console.Write("@");
    }

    static void SpawnFood()
    {
        foodX = rand.Next(1, width - 1);
        foodY = rand.Next(1, height - 1);
        DrawFood();
    }

    static void DrawScore()
    {
        Console.SetCursorPosition(2, 0);
        Console.Write("Wynik: " + score + "   ");
    }

    static void ReadInput()
    {
        while (gameRunning)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

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
        ClearSnake();

        switch (currentDirection)
        {
            case ConsoleKey.UpArrow:
                snakeY--;
                break;
            case ConsoleKey.DownArrow:
                snakeY++;
                break;
            case ConsoleKey.LeftArrow:
                snakeX--;
                break;
            case ConsoleKey.RightArrow:
                snakeX++;
                break;
        }

        // Sprawdzenie, czy zjedzono jedzenie
        if (snakeX == foodX && snakeY == foodY)
        {
            score++;
            SpawnFood();
            DrawScore();
        }

        DrawSnake();
    }
}
