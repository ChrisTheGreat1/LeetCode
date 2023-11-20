namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var problem = new _0215_KthLargestElementInAnArray();

            // nums = [3,2,1,5,6,4], k = 2
            var nums = new int[] { 3, 2, 1, 5, 6, 4 };
            var k = 2;

            var result = problem.FindKthLargest(nums, k);

            Console.WriteLine(result);
        }
    }
}