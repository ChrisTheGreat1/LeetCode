namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var problem = new _0045_JumpGame2();

            var nums = new int[] { 2, 3, 1, 1, 4 };

            var result = problem.Jump(nums);

            Console.WriteLine(result);
        }
    }
}