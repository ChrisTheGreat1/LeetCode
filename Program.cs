namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var problem = new _16_3SumClosest();

            int[] nums = new int[] { -1, 2, 1, -4 };
            //int[] nums = new int[] { 0, 0, 0 };
            //int[] nums = new int[] { 1, 2, 3 };

            var result = problem.ThreeSumClosest(nums, 1);

            Console.WriteLine(result);
        }
    }
}