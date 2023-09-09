namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var problem = new _0020_ValidParentheses();

            //var s = "()";
            //var s = "()[]{}";
            //var s = "(]";
            var s = "(())";

            var result = problem.IsValid(s);

            Console.WriteLine(result);
        }
    }
}