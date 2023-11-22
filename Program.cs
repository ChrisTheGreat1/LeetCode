namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var problem = new _0621_TaskScheduler();

            // tasks = ["A","A","A","A","A","A","B","C","D","E","F","G"], n = 2
            var tasks = new char[] { 'A', 'A', 'A', 'A', 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
            var n= 2;

            var result = problem.LeastInterval(tasks, n);

            Console.WriteLine(result);
        }
    }
}