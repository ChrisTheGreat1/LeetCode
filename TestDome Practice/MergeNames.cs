using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomePractice
{
/*

Implement the UniqueNames method. When passed two arrays of names, it will return an array
containing the names that appear in either or both arrays. The returned array should have no
duplicates.

*/

    internal static class MergeNames
    {
        public static string[] UniqueNames(string[] names1, string[] names2)
        {
            // string[] test = { "test" };

            var combined = new List<string>();

            combined.AddRange(names1);
            combined.AddRange(names2);

            return combined.Distinct().ToArray();
        }

        public static void Main_MergeNames()
        {
            string[] names1 = new string[] { "Ava", "Emma", "Olivia" };
            string[] names2 = new string[] { "Olivia", "Sophia", "Emma" };
            Console.WriteLine(string.Join(", ", MergeNames.UniqueNames(names1, names2))); // should print Ava, Emma, Olivia, Sophia
        }
    }
}
