using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{

    class Borad
    {
        public Borad() //default constractor
        {
            mineNum = 2;
            selX = 0;
            selY = 0;
            sizeX = 10;
            sizeY = 10;
            shown = new bool[sizeX, sizeY];
            hasMine = new bool[sizeX, sizeY];
            hasFlag = new bool[sizeX, sizeY];
            aroundMines = new int[sizeX, sizeY];
        }

        private void putFrame(int x, int y, bool del)
        {
            if (del)
            {
                Console.SetCursorPosition(x - 1, y);
                Console.Write(" ");
                Console.SetCursorPosition(x + 1, y);
                Console.Write(" ");
                Console.SetCursorPosition(x, y - 1);
                Console.Write(" ");
                Console.SetCursorPosition(x, y + 1);
                Console.Write(" ");
            }
            else
            {
                Console.SetCursorPosition(x - 1, y);
                Console.Write("|");
                Console.SetCursorPosition(x + 1, y);
                Console.Write("|");
                Console.SetCursorPosition(x, y - 1);
                Console.Write("-");
                Console.SetCursorPosition(x, y + 1);
                Console.Write("-");
            }
        }

        public void display()
        {
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    Console.SetCursorPosition(x * 2 + 1, y * 2 + 1);
                    if (shown[x, y])
                    {
                        if (hasMine[x, y])
                            Console.Write('*');
                        else
                        {
                            if (aroundMines[x, y] != 0)
                                Console.Write(aroundMines[x, y]);
                            else
                                Console.Write(' ');
                        }
                    }
                    else
                    {
                        if (hasFlag[x, y])
                            Console.Write('F');
                        else
                            Console.Write('#');

                    }
                }
            }
        }

        private Boolean isXYvalid(int x, int y)
        {
            return ((x >= 0) && (y >= 0) && (x < sizeX) && (y < sizeY));
        }

        private Boolean placeMine(int x, int y)
        {
            if ((isXYvalid(x, y)) && (!hasMine[x, y]))
            {
                hasMine[x, y] = true;
                for (int xx = -1; xx <= 1; xx++)
                    for (int yy = -1; yy <= 1; yy++)
                    {
                        if (((xx != 0) || (yy != 0)) && isXYvalid(x + xx, y + yy))
                            aroundMines[x + xx, y + yy]++;
                    }
                return true;
            }
            else
                return false;


        }

        private int rand(int range, int index)
        {
            return (int)(Math.Cos(index * 1000 + Math.Sin(index * 101)) * range);
        }

        public void makeBoard(int seed)
        {
            reveledNum = 0;

            for (int x = 0; x < sizeX; x++)
                for (int y = 0; y < sizeY; y++)
                {
                    shown[x, y] = false;
                    hasMine[x, y] = false;
                    hasFlag[x, y] = false;
                    aroundMines[x, y] = 0;
                }

            Random rnd = new Random();
            int count = 0;
            int i = 0;
            while (count < mineNum)
            {
                i++;
                if (placeMine(rnd.Next(sizeX), rnd.Next(sizeY)))
                    count++;
            }


        }

        public void putFlag(int x, int y)
        {
            if (!shown[x, y])
                hasFlag[x, y] = true;
        }

        public void removeFlag(int x, int y)
        {
            //if (!shown[x, y])
            hasFlag[x, y] = false;
        }

        public bool revelBlock(int x, int y)
        {
            if (!hasFlag[x, y])
            {
                reveledNum++;
                shown[x, y] = true;
                int newX, newY;
                if ((aroundMines[x, y] == 0) && (!hasMine[x, y]))
                {
                    for (int xx = -1; xx <= 1; xx++)
                        for (int yy = -1; yy <= 1; yy++)
                        {
                            newX = x + xx;
                            newY = y + yy;
                            if ((isXYvalid(newX, newY)) && (!shown[newX, newY]) && (!hasFlag[newX, newY]))
                                revelBlock(newX, newY);
                        }
                }
                return hasMine[x, y];
            }
            else
                return false;
        }

        public bool wonGame()
        {
            Console.WriteLine(sizeX * sizeY);
            Console.WriteLine(reveledNum);
            Console.WriteLine((sizeX * sizeY) - (reveledNum + mineNum));
            return (reveledNum + mineNum) == (sizeX * sizeY);
        }

        public bool control(ConsoleKeyInfo cki)
        {

            putFrame(selX * 2 + 1, selY * 2 + 1, true);

            if ((selX < sizeX - 1) && (cki.Key == ConsoleKey.RightArrow))
                selX++;
            if ((selX > 0) && (cki.Key == ConsoleKey.LeftArrow))
                selX--;
            if ((selY < sizeY - 1) && (cki.Key == ConsoleKey.DownArrow))
                selY++;
            if ((selY > 0) && (cki.Key == ConsoleKey.UpArrow))
                selY--;
            putFrame(selX * 2 + 1, selY * 2 + 1, false);


            if (cki.Key == ConsoleKey.Enter)
                putFlag(selX, selY);
            if (cki.Key == ConsoleKey.Backspace)
                removeFlag(selX, selY);
            if (cki.Key == ConsoleKey.Spacebar)
                return revelBlock(selX, selY);
            else
                return false;

        }

        private bool[,] shown, hasMine, hasFlag;
        private int[,] aroundMines;
        int sizeX, sizeY;
        int selX, selY;
        int mineNum, reveledNum;
    }

    class Program
    {


        static void Main(string[] args)
        {
            Borad game;
            bool exit = false;
            int lostNum = 1;
            ConsoleKeyInfo ch;

            game = new Borad();
            game.makeBoard(10);
            game.display();

            do
            {
                ch = Console.ReadKey(true);
                //newGame = game.control(ch);

                if (game.control(ch))
                {
                    game.makeBoard(10);
                    Console.SetCursorPosition(25, lostNum);
                    Console.WriteLine("you lost");
                    game.display();
                    lostNum++;

                }
                //Console.KeyAvailable
                game.display();
                exit = ch.Key == ConsoleKey.Escape;
            }
            while (!exit && !game.wonGame());
            if (game.wonGame())
                Console.WriteLine("you won!");
        }
    }
}
