namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var problem = new _11_ContainerWithMostWater();

            //int[] height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            int[] height = new int[] { 1, 1 };

            var result = problem.MaxArea(height);

            Console.WriteLine(result);
        }
    }
}