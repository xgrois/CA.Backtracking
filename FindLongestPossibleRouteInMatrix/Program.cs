using System;

namespace FindLongestPossibleRouteInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("::: Longest path and longest route :::");

            // Input 0-1 matrix

            //int[,] mat = new int[,]
            //{
            //    { 1, 0, 1, 1, 1, 1, 0, 1, 1, 1 },
            //    { 1, 0, 1, 0, 1, 1, 1, 0, 1, 1 },
            //    { 1, 1, 1, 0, 1, 1, 0, 1, 0, 1 },
            //    { 0, 0, 0, 0, 1, 0, 0, 1, 0, 0 },
            //    { 1, 0, 0, 0, 1, 1, 1, 1, 1, 1 },
            //    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            //    { 1, 0, 0, 0, 1, 0, 0, 1, 0, 1 },
            //    { 1, 0, 1, 1, 1, 1, 0, 0, 1, 1 },
            //    { 1, 1, 0, 0, 1, 0, 0, 0, 0, 1 },
            //    { 1, 0, 1, 1, 1, 1, 0, 1, 0, 0 }
            //};

//            int[,] mat = new int[,]
//{
//                { 1, 0, 1, 1, 1, 1, 0, 1, 1, 1 },
//                { 1, 0, 1, 0, 1, 1, 1, 0, 1, 1 },
//                { 1, 1, 1, 0, 1, 1, 1, 1, 0, 1 },
//                { 0, 0, 0, 0, 1, 0, 0, 1, 0, 0 },
//                { 1, 0, 0, 0, 1, 1, 1, 1, 1, 1 },
//                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
//                { 1, 0, 0, 0, 1, 0, 0, 1, 0, 1 },
//                { 1, 0, 1, 1, 1, 1, 0, 0, 1, 1 },
//                { 1, 1, 0, 0, 1, 0, 0, 0, 0, 1 },
//                { 1, 0, 1, 1, 1, 1, 0, 1, 0, 0 }
//};

            int[,] mat = new int[,]
{
                { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 },
                { 1, 1, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 0, 0, 0, 0, 1, 0, 0, 1, 0, 1 },
                { 1, 0, 0, 0, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                { 1, 0, 0, 0, 1, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 1, 1, 1, 0, 0, 1, 1 },
                { 1, 1, 0, 0, 1, 0, 0, 0, 0, 1 },
                { 1, 0, 1, 1, 1, 1, 0, 1, 0, 0 }
};

            //            int[,] mat = new int[,]
            //{
            //                            { 1, 0, 1, 1, 1 },
            //                            { 1, 1, 0, 1, 1 },
            //                            { 0, 1, 1, 1, 0 },
            //                            { 1, 1, 1, 1, 1 },
            //                            { 0, 1, 1, 0, 1 },
            //                            { 1, 1, 0, 1, 1 },
            //};

            //            int[,] mat = new int[,]
            //{
            //                                        { 1, 0, 1, 1 },
            //                                        { 1, 1, 0, 1 },
            //                                        { 1, 1, 1, 1 },
            //                                        { 1, 1, 0, 1 },

            //};

            //            int[,] mat = new int[,]
            //{
            //                            { 1, 1 },
            //                            { 0, 0 },


            //            };

            //            int[,] mat = new int[,]
            //{
            //                { 0 }


            //};

            //            int[,] mat = new int[,]
            //{
            //                            { 1, 1, 1, 1 },
            //                            { 1, 0, 1, 1 },
            //                            { 0, 1, 0, 1 },
            //                            { 1, 1, 1, 1 }, 
            //};

            int a = 0, b = 0, c = 7, d = 5;
            Console.WriteLine($"Length of longest path from  ({a},{b}) to (?,?) = {Solution.LengthOfLongestPath(mat, a, b)}");
            Console.WriteLine($"Length of longest route from ({a},{b}) to ({c},{d}) = {Solution.LengthOfLongestRoute(mat, a, b, c, d)}");
        }
    }

    public class Solution
    {
        public static int LengthOfLongestPath(int[,] mat, int a, int b)
        {
            int N = mat.GetLength(0);
            int M = mat.GetLength(1);
            bool[,] visited = new bool[N, M];
            visited[a, b] = true;
            return LengthOfLongestPath(mat, a, b, N, M, visited);
        }

        static int LengthOfLongestPath(int[,] mat, int i, int j, int N, int M, bool[,] visited)
        {
            int left = 0, up = 0, right = 0, down = 0;

            if (isSafe(i, j - 1, N, M) && !visited[i, j - 1] && mat[i, j - 1] == 1)
            {
                visited[i, j - 1] = true;
                left = 1 + LengthOfLongestPath(mat, i, j - 1, N, M, visited);
                visited[i, j - 1] = false;
            }
            if (isSafe(i - 1, j, N, M) && !visited[i - 1, j] && mat[i - 1, j] == 1)
            {
                visited[i - 1, j] = true;
                up = 1 + LengthOfLongestPath(mat, i - 1, j, N, M, visited);
                visited[i - 1, j] = false;
            }
            if (isSafe(i, j + 1, N, M) && !visited[i, j + 1] && mat[i, j + 1] == 1)
            {
                visited[i, j + 1] = true;
                right = 1 + LengthOfLongestPath(mat, i, j + 1, N, M, visited);
                visited[i, j + 1] = false;
            }
            if (isSafe(i + 1, j, N, M) && !visited[i + 1, j] && mat[i + 1, j] == 1)
            {
                visited[i + 1, j] = true;
                down = 1 + LengthOfLongestPath(mat, i + 1, j, N, M, visited);
                visited[i + 1, j] = false;
            }

            return MaxOf(left, up, right, down);
        }

        public static int LengthOfLongestRoute(int[,] mat, int i, int j, int x, int y)
        {
            int N = mat.GetLength(0);
            int M = mat.GetLength(1);
            bool[,] visited = new bool[N, M];
            visited[i, j] = true;
            return LengthOfLongestRoute(mat, i, j, x, y, N, M, visited);
        }
        static int LengthOfLongestRoute(int[,] mat, int i, int j, int x, int y, int N, int M, bool[,] visited)
        {

            if (i == x && j == y) return 0; // We are in our destination cell, return 0 and do not continue recursion from here

            // We can continue recursion from this cell
            int left = 0, up = 0, right = 0, down = 0;

            if (isSafe(i, j - 1, N, M) && !visited[i, j - 1] && mat[i, j - 1] == 1)
            {
                visited[i, j - 1] = true;
                left = 1 + LengthOfLongestRoute(mat, i, j - 1, x, y, N, M, visited);
                visited[i, j - 1] = false;
            }
            if (isSafe(i - 1, j, N, M) && !visited[i - 1, j] && mat[i - 1, j] == 1)
            {
                visited[i - 1, j] = true;
                up = 1 + LengthOfLongestRoute(mat, i - 1, j, x, y, N, M, visited);
                visited[i - 1, j] = false;
            }
            if (isSafe(i, j + 1, N, M) && !visited[i, j + 1] && mat[i, j + 1] == 1)
            {
                visited[i, j + 1] = true;
                right = 1 + LengthOfLongestRoute(mat, i, j + 1, x, y, N, M, visited);
                visited[i, j + 1] = false;
            }
            if (isSafe(i + 1, j, N, M) && !visited[i + 1, j] && mat[i + 1, j] == 1)
            {
                visited[i + 1, j] = true;
                down = 1 + LengthOfLongestRoute(mat, i + 1, j, x, y, N, M, visited);
                visited[i + 1, j] = false;
            }

            int max = MaxOf(left, up, right, down);

            if (mat[i, j] == 1 && max == 0) // termination cell != than the destinty, assign "-inf"
                return int.MinValue;
            else return max;
        }

        private static int MaxOf(int left, int up, int right, int down)
        {
            return Math.Max(left, Math.Max(up, Math.Max(right, down)));
        }

        private static bool isSafe(int i, int j, int N, int M)
        {
            return (0 <= i) && (i < N) && (0 <= j) && (j < M);
        }
    }
}
