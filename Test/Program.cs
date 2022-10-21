using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix = MatrixInitalization();


            //CUSTOM MATRIX FOR TEST PURPOSES
            //int[][] testMatrix = new int[9][];
            //int[] firstrow = { 3, 2, 1, 2, 1, 2, 2, 1, 3 };
            //testMatrix[0] = firstrow;
            //int[] secondrow = { 2, 3, 3, 2, 0, 1, 1, 2, 1 };
            //testMatrix[1] = secondrow;
            //int[] thirdrow = { 1, 2, 1, 3, 3, 2, 1, 3, 2 };
            //testMatrix[2] = thirdrow;
            //int[] fourthrow = { 1, 1, 2, 2, 1, 1, 2, 3, 2 };
            //testMatrix[3] = fourthrow;
            //int[] fifthrow = { 2, 2, 3, 1, 2, 2, 3, 2, 3};
            //testMatrix[4] = fifthrow;
            //int[] sixthrow = { 3, 2, 2, 3, 1, 1, 3, 1, 1 };
            //testMatrix[5] = sixthrow;
            //int[] seventhrow = { 1, 3, 1, 3, 1, 2, 1, 3, 3 };
            //testMatrix[6] = seventhrow;
            //int[] eighthrow = { 3, 2, 3, 2, 2, 3, 1, 3, 3 };
            //testMatrix[7] = eighthrow;
            //int[] ninethrow = { 0, 0, 0, 2, 1, 3, 2, 1, 2};  //CONTAINS THE ONLY DUPLICATE IN THE MATRIX
            //testMatrix[8] = ninethrow;


            Console.WriteLine("Initial Array");
            for (var i = 0; i < matrix.Length; i++)
            {
                matrix[i].ToList().ForEach(x => Console.Write(x.ToString() + ' '));
                Console.WriteLine(" ");
            }

            Console.WriteLine("");


            Console.WriteLine("Correct Array");

            var correctMatrix = removeDuplicates(matrix);

            for (var i = 0; i < correctMatrix.Length; i++)
            {
                correctMatrix[i].ToList().ForEach(x => Console.Write(x.ToString() + ' '));
                Console.WriteLine(" ");
            }
        }

        public static int[][] removeDuplicates(int[][] board)
        {
            Random random = new Random();
            bool solved = true;
            for(var r = 0; r < 9; r++)
            {
                for (var c = 0; c < 7; c++)
                {
                    int num1 = board[r][c];
                    int num2 = board[r][c + 1];
                    int num3 = board[r][c + 2];
                    if (num1 == num2 && num2 == num3)
                    {
                        board[r][c] = -1;
                        board[r][c + 1] = -1;
                        board[r][c + 2] = -1;
                        solved = false;
                    }
                }
            }

            for (var c = 0; c < 9; c++)
            {
                for (var r = 0; r < 7; r++)
                {
                    int num1 = board[r][c];
                    int num2 = board[r + 1][c];
                    int num3 = board[r + 2][c];
                    if (num1 == num2 && num2 == num3)
                    {
                        board[r][c] = -1;
                        board[r + 1][c] = -1;
                        board[r + 2][c] = -1;
                        solved = false;
                    }
                }
            }

            for (var c = 0; c < 9; c++)
            {
                var index = 8;
                for (var r = 8; r >= 0; r--)
                {
                    if (board[r][c] > 0)
                    {
                        board[index][c] = board[r][c];
                        index--;
                    }
                }
                for (var r = index; r > -1; r--)
                {
                    board[r][c] = random.Next(0, 4);
                }
            }
            if (!solved)
            {
                removeDuplicates(board);
            }
            return board;
        }

        public static int[][] MatrixInitalization()
        {
            int[][] matrix = new int[9][];
            Random random = new Random();

            for (var i = 0; i < 9; i++)
            {
                int[] row = new int[9];
                for (var j = 0; j < 9; j++)
                {
                    row[j] = random.Next(0, 4);
                }
                matrix[i] = row;
            }
            return matrix;
        }
    }
}