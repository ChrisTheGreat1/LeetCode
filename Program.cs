namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var problem = new _0695_MaxAreaOfIsland();

            int[][] array = new int[][]
            {
                new int[] {0,0,1,0,0,0,0,1,0,0,0,0,0},
                new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0},
                new int[] {0,1,1,0,1,0,0,0,0,0,0,0,0},
                new int[] {0,1,0,0,1,1,0,0,1,0,1,0,0},
                new int[] {0,1,0,0,1,1,0,0,1,1,1,0,0},
                new int[] {0,0,0,0,0,0,0,0,0,0,1,0,0},
                new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0},
                new int[] {0,0,0,0,0,0,0,1,1,0,0,0,0}
            };

            var result = problem.MaxAreaOfIsland(array);

            Console.WriteLine(result);
        }
    }
}