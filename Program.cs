using System;
using System.Diagnostics;
using System.Drawing;

namespace CERule101
{
    class Program
    {
        public static char[,] patterns = {//array with paterns
                {'*','*','*',' ' },//111
                {'*','*',' ','*' },//110
                {'*',' ','*','*'},//101
                {'*',' ',' ',' ' },//100
                {' ','*','*','*' },//011
                {' ','*',' ','*' },//010
                {' ',' ','*','*' },//001
                {' ',' ',' ',' ' },//000
            };
        public static void Show<T>(T[] A, bool debug)//Print function
        {
            if (debug) Console.WriteLine("Show func:");
            foreach (var item in A)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
     
        public static char[] GenerateRow(int number)
        {
            Random rnd = new Random();
            char[] arr = new char[number];
            for (int i = 0; i < number; i++)
            {
                if (rnd.Next(2) == 1)
                {
                    arr[i] = '*';
                }
                else arr[i] = ' ';

            }
            return arr;
        }
        private static char MatchPattern(char[] row)
        {
            for (int i = 0; i < patterns.GetLength(0); i++)
            {
                if (patterns[i, 0] == row[0] && patterns[i, 1] == row[1] && patterns[i, 2] == row[2])
                {
                    return patterns[i, 3];
                }
            }
            return ' ';
        }


        public static char[] ProcessRow(char[] row)
        {
            char[] newrow = new char[row.Length];
            newrow[0] = ' ';
            for (int i = 1; i < row.Length - 1; i++)
            {
                char[] temp = { row[i], row[i], row[i + 1] };
                newrow[i] = MatchPattern(temp);
            }
            return newrow;
        }
        static void Main()
        {
            char[] startrow = GenerateRow(50);
            Show(startrow, false);
            char[] nextrow = ProcessRow(startrow);
            Show(nextrow, false);
            for (int i=0;i<100 ;i++ )
            {
                nextrow = ProcessRow(nextrow);
                Show(nextrow, false);
            }
        }
    }
}
