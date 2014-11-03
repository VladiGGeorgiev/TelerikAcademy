using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

class FallingRocks
{
    private static String dwarf = "(0)";
    private static int dwarfSize = dwarf.Length;
    private static int dwarfPosition;
    private static int maxRocks = 5;
    private static int activeRocks = 0;
    private static int score = 0;
    private static int maxPlayers = 5;
    private static int level = 1;
    private static int sleep = 200;
    private static string[] typeRocks = new string[] { "^", "@", "*", "&", "+", "%", "$", "#", "!", ".", ";", "-" };
    private static List<Rock> rocks = new List<Rock>();
    private static List<Player> players = new List<Player>();
    private static Random rand = new Random();

    static void removeScrollBars()
    {
        Console.WindowWidth = 50;
        Console.WindowHeight = 25;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
    }

    static void setPosition()
    {
        Console.SetCursorPosition(Console.WindowHeight - 1, Console.WindowWidth / 2 - 1);
        dwarfPosition = Console.WindowWidth / 2 - 1;
        drowDwarf();
    }

    static void moveDwarf()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                if (dwarfPosition + dwarfSize < Console.WindowWidth - 1)
                {
                    dwarfPosition++;
                    drowDwarf();
                }
            }
            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (dwarfPosition > 0)
                {
                    dwarfPosition--;
                    drowDwarf();
                }
            }

        }
    }

    static void drowDwarf()
    {
        Console.SetCursorPosition(dwarfPosition, Console.WindowHeight - 1);
        Console.Write(dwarf);
    }

    static void fallingRocks()
    {
        generateNewRocks();
        drowRocks();
    }

    private static void drowRocks()
    {
        foreach (Rock r in rocks)
        {
            Console.SetCursorPosition(r.getX(), r.getY());
            for (int s = 0; s < r.getSize(); s++)
            {
                Console.Write(typeRocks[r.getType()]);
            }
            if (r.getY() < Console.WindowHeight - 1) r.setY();
        }
        int? remove = null;
        int i = 0;
        foreach (Rock r in rocks)
        {
            if (r.getY() == Console.WindowHeight - 1)
            {
                Console.SetCursorPosition(0, 15);
                if ((r.getX() >= dwarfPosition && r.getX() <= dwarfPosition + dwarfSize) ||
                    (r.getX() + r.getSize() >= dwarfPosition && r.getX() + r.getSize() <= dwarfPosition + dwarfSize))
                {
                    gameOver();
                    break;
                }
                else
                {
                    score += r.getSize();
                }
                remove = i;
                break;
            }
            i++;
        }
        if (remove.HasValue)
        {
            rocks.RemoveAt(remove.Value);
            activeRocks--;
        }
    }

    private static void generateNewRocks()
    {

        if (activeRocks < maxRocks)
        {
            activeRocks++;
            int x = rand.Next(0, Console.WindowWidth - 1);
            int t = rand.Next(0, typeRocks.Length - 1);
            Rock r = new Rock(x, 0, t);
            rocks.Add(r);
            if (score >= level * 100)
            {
                maxRocks++;
                level++;
            }
        }
    }

    private static void printScore()
    {
        Console.SetCursorPosition(0, 0);
        Console.Write("SCORE {0}", score);
        Console.SetCursorPosition(Console.WindowWidth - 8, 0);
        Console.Write("LEVEL {0,2}", level);
        Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 0);
        Console.Write("ROCKS {0,2}", maxRocks);
    }

    private static void startGame()
    {
        removeScrollBars();
        setPosition();
        score = 0;
    }

    private static void gameOver()
    {
        Console.SetCursorPosition(10, 10);
        Console.WriteLine("GAME OVER\t{0}", score);
        Console.SetCursorPosition(10, 11);
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        players.Add(new Player(name, score));
        printTopPlayers();
        Console.ReadKey();
        rocks.Clear();
        activeRocks = 0;
        maxRocks = 5;
        level = 1;
        startGame();

    }

    private static void printTopPlayers()
    {
        players.Sort();
        Console.Clear();
        int i = 1;
        Console.SetCursorPosition(10, 10);
        Console.Write("N" + " " + "Player " + "\t" + "score");
        foreach (Player p in players)
        {
            Console.SetCursorPosition(10, 11 + i);
            Console.Write(i);
            Console.SetCursorPosition(12, 11 + i);
            Console.Write("{0,10}", p.getName());
            Console.SetCursorPosition(23, 11 + i);
            Console.Write(" " + p.getScore());
            if (i == maxPlayers) break;
            i++;
        }
    }

    static void Main(string[] args)
    {
        startGame();
        while (true)
        {
            moveDwarf();
            drowDwarf();
            fallingRocks();
            printScore();
            Thread.Sleep(sleep - level * 10);
            Console.Clear();
        }
    }
}


public class Rock
{
    int x;
    int y;
    int type;
    int rockSize;
    public Rock(int x, int y, int type)
    {
        Random rand = new Random();
        this.x = x;
        this.y = y;
        this.type = type;
        rockSize = rand.Next(1, 4);
    }
    public int getX() { return this.x; }
    public int getY() { return this.y; }
    public int getType() { return this.type; }
    public int getSize() { return this.rockSize; }
    public void setY() { this.y++; }

}

public class Player : IComparable<Player>
{
    String name;
    int score;
    public Player(String name, int score)
    {
        this.name = name;
        this.score = score;
    }

    public int CompareTo(Player other)
    {
        if (this.score < other.score) return 1;
        else if (this.score > other.score) return -1;
        else return 0;
    }

    public string getName() { return this.name; }
    public int getScore() { return this.score; }
}