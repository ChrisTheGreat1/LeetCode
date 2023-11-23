using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    In this problem, a tree is an undirected graph that is connected and has no cycles.

    You are given a graph that started as a tree with n nodes labeled from 1 to n, with one additional edge added. 
    The added edge has two different vertices chosen from 1 to n, and was not an edge that already existed. 
    The graph is represented as an array edges of length n where edges[i] = [ai, bi] indicates that there is an 
    edge between nodes ai and bi in the graph.

    Return an edge that can be removed so that the resulting graph is a tree of n nodes. If there are multiple 
    answers, return the answer that occurs last in the input.

    Input: edges = [[1,2],[1,3],[2,3]]
    Output: [2,3]

    Input: edges = [[1,2],[2,3],[3,4],[1,4],[1,5]]
    Output: [1,4]
 

    Constraints:

    n == edges.length
    3 <= n <= 1000
    edges[i].length == 2
    1 <= ai < bi <= edges.length
    ai != bi
    There are no repeated edges.
    The given graph is connected.

    */
    internal class _0684_RedundantConnection
    {
        // DFS solution would be O(n^2)
        // Union-find solution is O(n)

        // Cycles will exist if the number of edges = number of nodes

        public int[] FindRedundantConnection(int[][] edges)
        {
            var nodes = edges.Length;
            int[] parent = new int[nodes + 1];
            int[] rank = new int[nodes + 1];

            for (int i = 0; i < nodes; i++)
            {
                parent[i] = i;
                rank[i] = 1;
            }

            int findParent(int n)
            {
                var p = parent[n];

                while (p != parent[p])
                {
                    parent[p] = parent[parent[p]];
                    p = parent[p];
                }

                return p;
            }
            bool union(int n1, int n2)
            {
                (int p1, int p2) = (findParent(n1), findParent(n2));

                if (p1 == p2) return false;

                if (rank[p1] > rank[p2])
                {
                    parent[p2] = p1;
                    rank[p1] += rank[p2];
                }
                else
                {
                    parent[p1] = p2;
                    rank[p2] += rank[p1];
                }

                return true;
            }

            foreach (var edge in edges)
            {
                if (union(edge[0], edge[1]) is false)
                    return edge;
            }

            return new int[2];
        }
    }
}
