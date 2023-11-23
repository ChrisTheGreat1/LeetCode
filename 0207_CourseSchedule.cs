using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. 
    You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must 
    take course bi first if you want to take course ai.

    For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
    Return true if you can finish all courses. Otherwise, return false.

    Input: numCourses = 2, prerequisites = [[1,0]]
    Output: true
    Explanation: There are a total of 2 courses to take. 
    To take course 1 you should have finished course 0. So it is possible.


    Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
    Output: false
    Explanation: There are a total of 2 courses to take. 
    To take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.
 

    Constraints:

    1 <= numCourses <= 2000
    0 <= prerequisites.length <= 5000
    prerequisites[i].length == 2
    0 <= ai, bi < numCourses
    All the pairs prerequisites[i] are unique.

    */

    internal class _0207_CourseSchedule
    {
        // Model the input as a tree (ex. 1 --> 0). Perform DFS and store each traversed node in a visited set
        // If you navigate to a node that is already in the set, that means a loop is occurring and you have reached
        // an impossible to complete condition.

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            IDictionary<int, List<int>> preMap = new Dictionary<int, List<int>>();
            HashSet<int> visited = new HashSet<int>();

            for (int i = 0; i < numCourses; i++)
            {
                preMap.Add(i, new List<int>());
            }

            foreach (int[] course in prerequisites)
            {
                int courseToTake = course[0];
                int courseDependOn = course[1];
                preMap[courseToTake].Add(courseDependOn);
            }

            foreach (int c in Enumerable.Range(0, numCourses))
            {
                if (!DfsGraph(preMap, visited, c))
                {
                    return false;
                }
            }
            return true;
        }
        public bool DfsGraph(IDictionary<int, List<int>> preMap, HashSet<int> visited, int crs)
        {
            if (visited.Contains(crs))
            {
                return false;
            }
            if (preMap[crs] == new List<int>())
            {
                return true;
            }
            visited.Add(crs);
            foreach (var pre in preMap[crs])
            {
                if (!DfsGraph(preMap, visited, pre))
                {
                    return false;
                }
            }
            visited.Remove(crs);
            preMap[crs] = new List<int>();
            return true;
        }
    }
}
