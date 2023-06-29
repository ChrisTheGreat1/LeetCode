namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var problem = new _4_MedianOfTwoSortedArrays();

            var nums1 = new int[] { 1, 2 };
            var nums2 = new int[] { 3, 4, 5 };

            var result = problem.FindMedianSortedArrays(nums1, nums2);

            Console.WriteLine(result);
        }
    }
}