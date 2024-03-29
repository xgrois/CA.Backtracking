﻿using System;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("::: Sudoku Solver :::");

            int[,] mat = new int[,] {
         { 3, 0, 6, 5, 0, 8, 4, 0, 0},
         { 5, 2, 0, 0, 0, 0, 0, 0, 0},
         { 0, 8, 7, 0, 0, 0, 0, 3, 1},
         { 0, 0, 3, 0, 1, 0, 0, 8, 0},
         { 9, 0, 0, 8, 6, 3, 0, 0, 5},
         { 0, 5, 0, 0, 9, 0, 6, 0, 0},
         { 1, 3, 0, 0, 0, 0, 2, 5, 0},
         { 0, 0, 0, 0, 0, 0, 0, 7, 4},
         { 0, 0, 5, 2, 0, 6, 3, 0, 0}
            };

            //3 1 6 5 7 8 4 9 2
            //5 2 9 1 3 4 7 6 8
            //4 8 7 6 2 9 5 3 1
            //2 6 3 4 1 5 9 8 7
            //9 7 4 8 6 3 1 2 5
            //8 5 1 7 9 2 6 4 3
            //1 3 8 9 4 7 2 5 6
            //6 9 2 3 5 1 8 7 4
            //7 4 5 2 8 6 3 1 9

            //   // Considered hard
            //   int[,] mat = new int[,] {
            //{ 0, 0, 0, 7, 0, 0, 0, 3, 0},
            //{ 0, 0, 0, 6, 0, 8, 0, 0, 0},
            //{ 0, 0, 0, 3, 5, 0, 6, 0, 8},
            //{ 5, 1, 0, 4, 8, 7, 2, 0, 0},
            //{ 0, 2, 0, 1, 3, 5, 8, 0, 0},
            //{ 0, 0, 7, 2, 6, 9, 0, 0, 0},
            //{ 9, 5, 0, 8, 0, 3, 0, 0, 0},
            //{ 2, 0, 4, 5, 7, 0, 9, 8, 0},
            //{ 8, 7, 0, 9, 0, 0, 0, 4, 3}
            //   };

            //1 6 8 7 9 2 4 3 5
            //3 4 5 6 1 8 7 9 2
            //7 9 2 3 5 4 6 1 8
            //5 1 3 4 8 7 2 6 9
            //6 2 9 1 3 5 8 7 4
            //4 8 7 2 6 9 3 5 1
            //9 5 6 8 4 3 1 2 7
            //2 3 4 5 7 1 9 8 6
            //8 7 1 9 2 6 5 4 3


            Solution.SolveCell(mat,0,0);

            Print(mat);

        }

        private static void Print(int[,] mat)
        {
            int N = mat.GetLength(0);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"{mat[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }

    class Solution
    {
        public static bool SolveCell(int[,] mat, int r, int c)
        {
            //int N = mat.GetLength(0);
            //int M = mat.GetLength(1);
            //if (M != N) return mat;
            if (r == mat.GetLength(0)) return true;

            int next_r = r, next_c = c + 1;
            if (c == mat.GetLength(0) - 1) { next_r = r + 1; next_c = 0; }


            if (mat[r, c] == 0)
            {
                for (int x = 1; x <= 9; x++)
                {
                    if (IsSafe(mat, r, c, x))
                    {
                        // Try x and continue
                        mat[r, c] = x;
                        if (SolveCell(mat, next_r, next_c))
                            return true;
                        mat[r, c] = 0;
                    }

                }
                return false;
            }


            return SolveCell(mat, next_r, next_c);


        }

        public static bool IsSafe(int[,] mat, int r, int c, int x)
        {

            int N = mat.GetLength(0);

            // Check col
            for (int i = 0; i < N; i++)
            {
                if (mat[r, i] == x) return false;
            }

            // Check row
            for (int i = 0; i < N; i++)
            {
                if (mat[i, c] == x) return false;
            }

            // Check block
            int ri = r - r % 3;
            int ci = c - c % 3;
            for (int i = ri; i < ri + 3; i++)
            {
                for (int j = ci; j < ci + 3; j++)
                {
                    if (mat[i,j] == x) return false;
                }
            }

            return true;
        }
    }


}
