namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var problem = new _0309_BestTimeToBuyAndSellStockWithCooldown();

            var prices = new int[] { 1, 2, 3, 0, 2 };

            var result = problem.MaxProfit(prices);

            Console.WriteLine(result);
        }
    }
}