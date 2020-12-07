using System;

namespace FindShortestPathLengthInAMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("::: Find Shortest Path Length In A Maze :::");

            int[,] mat = new int[,]
            {
                { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1 },
                { 0, 1, 1, 1, 1, 1, 0, 1, 0, 1 },
                { 0, 0, 1, 0, 1, 1, 1, 0, 0, 1 },
                { 1, 0, 1, 1, 1, 0, 1, 1, 0, 1 },
                { 0, 0, 0, 1, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 1, 1, 0, 0, 1, 1, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 1, 0, 1 },
                { 0, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
                { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1 },
                { 0, 0, 1, 0, 0, 1, 1, 0, 0, 1 },
            };
            int sr = 0, sc = 0, dr = 9, dc = 2;
            int len = Solution.ShortestPathLength(mat,sr,sc,dr,dc);

            if (len == mat.GetLength(0) * mat.GetLength(1))
                Console.WriteLine($"Destination ({dr},{dc}) cannot be reached from ({sr},{sc}).");
            else
                Console.WriteLine($"Shortest path length from ({sr},{sc}) to ({dr},{dc}) is: {len}");
        }
    }


    class Solution
    {
        internal static int ShortestPathLength(int[,] mat, int sr, int sc, int dr, int dc)
        {
            int N = mat.GetLength(0);
            int M = mat.GetLength(1);

            bool[,] visited = new bool[N,M];

            visited[sr, sc] = true;

            return ProcessCell(mat, N, M, sr, sc, dr, dc, visited);
        }

        private static int ProcessCell(int[,] mat, int N, int M, int i, int j, int dr, int dc, bool[,] visited)
        {

            if ((i == dr) && (j == dc)) { return 0; }

            // Maximum shortest possible path traverses all entries and would have N*M - 1 lenght
            // This way we avoid using +infinity or related
            int maxShortest = N * M;

            // Explore Left
            int left = maxShortest;
            if (!OutOfBound(i, j - 1, N, M) && !visited[i, j - 1] && (mat[i, j - 1] != 0))
            {
                visited[i, j - 1] = true;
                left = 1 + ProcessCell(mat, N, M, i, j - 1, dr, dc, visited);
                visited[i, j - 1] = false;
            }     

            // Explore Up
            int up = maxShortest;
            if (!OutOfBound(i - 1, j, N, M) && !visited[i - 1, j] && (mat[i - 1, j] != 0))
            {
                visited[i - 1, j] = true;
                up = 1 + ProcessCell(mat, N, M, i - 1, j, dr, dc, visited);
                visited[i - 1, j] = false;
            }

            // Explore Right
            int right = maxShortest;
            if (!OutOfBound(i, j + 1, N, M) && !visited[i, j + 1] && (mat[i, j + 1] != 0))
            {
                visited[i, j + 1] = true;
                right = 1 + ProcessCell(mat, N, M, i, j + 1, dr, dc, visited);
                visited[i, j + 1] = false;
            } 
            
            // Explore Down
            int down = maxShortest;
            if (!OutOfBound(i + 1, j, N, M) && !visited[i + 1, j] && (mat[i + 1, j] != 0))
            {
                visited[i + 1, j] = true;
                down = 1 + ProcessCell(mat, N, M, i + 1, j, dr, dc, visited);
                visited[i + 1, j] = false;
            }


            return Math.Min(left, Math.Min(up, Math.Min(right, down)));
        }

        private static bool OutOfBound(int i, int j, int N, int M)
        {
            return (i < 0) || (i >= N) || (j < 0) || (j >= M);
        }
    }
}
