namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var problem = new _0032_LongestValidParentheses(); // TODO: 0032

            var result = problem.LongestValidParentheses(s);

            Console.WriteLine(result);
        }
    }

    /*
        var problem = new _0032_LongestValidParentheses(); // TODO: 0032

        string s = "(()";
        //string s = ")()())";
        //string s = "";

        var result = problem.LongestValidParentheses(s);
    */
}