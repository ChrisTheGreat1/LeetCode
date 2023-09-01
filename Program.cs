namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var problem = new _0022_GenerateParentheses();

            var result = problem.GenerateParenthesis(2);

            Console.WriteLine(result);
        }
    }
}