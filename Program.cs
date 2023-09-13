namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var problem = new _0074_Search2dMatrix();

            var nums = new int[][]
                       {
                           new int[] {1, 3, 5, 7},
                           new int[] {10, 11, 16, 20},
                           new int[] {23, 30, 34, 60}
                       };
            var target = 3;
            //var target = 13;

            var result = problem.SearchMatrix(nums, target);

            Console.WriteLine(result);
        }
    }
}