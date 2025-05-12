using System;
using System.Threading;

class Program
{
    static int width = 40;
    static int height = 20;
    static bool gameRunning = true;

    static ConsoleKey currentDirection = ConsoleKey.RightArrow;
    static Thread inputThread;

 feature/menu
    static int snakeX;
    static int snakeY;


    static int snakeX = width / 2;
    static int snakeY = height / 2;

 feature/collision

 feature/score
 main
 main
    static int foodX;
    static int foodY;

    static int score = 0;

    static Random rand = new Random();

 feature/menu

 feature/collision


 feature/food
    static int foodX;
    static int foodY;

    static Random rand = new Random();

 main
 main
 main
 main
    static void Main()
    {
        while (true)
        {
            ShowMenu();

            StartGame();

            Console.Clear();
            Console.WriteLine("Game Over!");
            Console.WriteLine("Twój wynik: " + score);
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
        Console.WriteLine("1. Start");
        Console.WriteLine("2. Wyjście");

        ConsoleKey choice;
        do
        {
            choice = Console.ReadKey(true).Key;
        } while (choice != ConsoleKey.D1 && choice != ConsoleKey.D2);

        if (choice == ConsoleKey.D2)
            Environment.Exit(0);
    }

    static void StartGame()
    {
        gameRunning = true;
        snakeX = width / 2;
        snakeY = height / 2;
        score = 0;
        currentDirection = ConsoleKey.RightArrow;

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

 feature/menu
        inputThread.Join();

        Console.Clear();
        Console.WriteLine("Game Over!");
        Console.WriteLine("Twój wynik: " + score);
 main
    }

    static void InitializeGame()
    {
        Console.Clear();
        DrawBorder();
 feature/menu
        SpawnFood();
        DrawSnake();
        DrawScore();

 feature/collision
        SpawnFood();
        DrawSnake();
        DrawScore();

 feature/score
        SpawnFood();
        DrawSnake();
        DrawScore();

 feature/food
        SpawnFood();
        DrawSnake();

        DrawSnake(); // Rysujemy węża na starcie
 main
 main
 main
 main
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

 feature/menu

 feature/collision

 feature/score

 feature/food
 main
 main
 main
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

 feature/menu

 feature/collision
    static void DrawScore()
    {
        Console.SetCursorPosition(2, 0); // przeniesione na górę ekranu
        Console.Write("Wynik: " + score + "   ");
    }


 feature/score
 main
    static void DrawScore()
    {
        Console.SetCursorPosition(2, 0);
        Console.Write("Wynik: " + score + "   ");
    }

 feature/menu


 main
 main
 main
 main
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

 feature/menu

 feature/collision
        
 main
        if (snakeX <= 0 || snakeX >= width - 1 || snakeY <= 0 || snakeY >= height - 1)
        {
            gameRunning = false;
            return;
        }

 feature/menu

        

 feature/score
        // Sprawdzenie, czy zjedzono jedzenie
 main
 main
        if (snakeX == foodX && snakeY == foodY)
        {
            score++;
            SpawnFood();
            DrawScore();
        }

 feature/menu

 feature/collision

 feature/food
        // Sprawdzenie, czy wąż zjadł jedzenie
        if (snakeX == foodX && snakeY == foodY)
        {
            SpawnFood(); 
        }

 main
 main
 main
 main
        DrawSnake();
    }
}
