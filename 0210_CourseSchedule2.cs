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
    Return the ordering of courses you should take to finish all courses. If there are many valid 
    answers, return any of them. If it is impossible to finish all courses, return an empty array.


    Input: numCourses = 2, prerequisites = [[1,0]]
    Output: [0,1]
    Explanation: There are a total of 2 courses to take. To take course 1 you should have finished course 0. 
    So the correct course order is [0,1].


    Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
    Output: [0,2,1,3]
    Explanation: There are a total of 4 courses to take. To take course 3 you should have finished both 
    courses 1 and 2. Both courses 1 and 2 should be taken after you finished course 0.
    So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3].


    Input: numCourses = 1, prerequisites = []
    Output: [0]
 

    Constraints:

    1 <= numCourses <= 2000
    0 <= prerequisites.length <= numCourses * (numCourses - 1)
    prerequisites[i].length == 2
    0 <= ai, bi < numCourses
    ai != bi
    All the pairs [ai, bi] are distinct.

    */
    internal class _0210_CourseSchedule2
    {
        List<int> output = null;
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            IDictionary<int, List<int>> preMap = new Dictionary<int, List<int>>();
            HashSet<int> visited = new HashSet<int>();
            HashSet<int> cycle = new HashSet<int>();
            output = new List<int>();
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
                if (DfsGraphTopologicalSort(preMap, visited, cycle, c) == false)
                {
                    return Array.Empty<int>();
                }
            }
            return output.ToArray();
        }

        public bool DfsGraphTopologicalSort(IDictionary<int, List<int>> preMap, HashSet<int> visited, HashSet<int> cycle, int crs)
        {
            if (cycle.Contains(crs)) return false;
            if (visited.Contains(crs)) return true;

            if (preMap[crs] == new List<int>())
            {
                return true;
            }
            cycle.Add(crs);
            foreach (var pre in preMap[crs])
            {
                if (DfsGraphTopologicalSort(preMap, visited, cycle, pre) == false)
                {
                    return false;
                }
            }
            cycle.Remove(crs);
            visited.Add(crs);
            output.Add(crs);
            return true;
        }
    }
}
