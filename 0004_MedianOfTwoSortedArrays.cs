using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCode
{
    /*

    Given two sorted arrays nums1 and nums2 of size m and n respectively,
    return the median of the two sorted arrays.

    The overall run time complexity should be O(log (m+n)).

    */

    internal class _0004_MedianOfTwoSortedArrays
    {
        // Binary search solution
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            List<int> merged = new List<int>();
            int i = 0, j = 0;

            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                {
                    merged.Add(nums1[i++]);
                }
                else
                {
                    merged.Add(nums2[j++]);
                }
            }

            while (i < nums1.Length) merged.Add(nums1[i++]);
            while (j < nums2.Length) merged.Add(nums2[j++]);

            int mid = merged.Count / 2;
            if (merged.Count % 2 == 0)
            {
                return (merged[mid - 1] + merged[mid]) / 2.0;
            }
            else
            {
                return merged[mid];
            }
        }

        // My first non-optimal solution
        /*
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var nums1List = nums1.ToList();
            var nums2List = nums2.ToList();

            var numsList = nums1List;
            numsList.AddRange(nums2List);
            numsList.Sort();

            if (numsList.Count % 2 == 0)
            {
                double num1 = numsList.Take(numsList.Count / 2).Last();
                double num2 = numsList.TakeLast(numsList.Count / 2).First();
                return (num1 + num2) / 2;
            }
            else
            {
                int index = numsList.Count / 2;
                return numsList[index];
            }
        }
        */
    }
}