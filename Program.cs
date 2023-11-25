namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var problem = new _0322_CoinChange();

            var coins = new int[] { 1, 2, 5 };
            var amount = 11;

            var result = problem.CoinChange(coins, amount);

            Console.WriteLine(result);
        }
    }
}