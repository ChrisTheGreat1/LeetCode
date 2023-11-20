namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var problem = new _0040_CombinationSum2();

            var nums = new int[] { 2, 5, 2, 1, 2 };

            var result = problem.CombinationSum2(nums, 5);

            Console.WriteLine(result);
        }
    }
}