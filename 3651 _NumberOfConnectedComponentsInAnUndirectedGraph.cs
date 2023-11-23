using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    In this problem, there is an undirected graph with n nodes. There is also an edges array. Where edges[i] = [a, b] means that there is an edge between node a and node b in the graph.

You need to return the number of connected components in that graph.


    Input:

    3
    [[0,1], [0,2]]
    Output:
    1

    Input:

    6
    [[0,1], [1,2], [2, 3], [4, 5]]
    Output:
    2

    */
    internal class _3651__NumberOfConnectedComponentsInAnUndirectedGraph
    {
        // Use union-find algorithm for finding number of connected components in graphs

        private int noOfConnectedComponents = 0;
        private int[] rank;

        public int CountComponents(int n, int[][] edges)
        {
            if (n == 0)
                return noOfConnectedComponents;

            noOfConnectedComponents = n;
            rank = new int[n];

            for (int i = 0; i < n; i++)
                rank[i] = i;

            foreach (int[] edge in edges)
                Union(edge[0], edge[1]);

            return noOfConnectedComponents;
        }

        private void Union(int x, int y)
        {
            int p1 = Find(x), p2 = Find(y);

            if (p1 != p2)
            {
                rank[p1] = p2;
                noOfConnectedComponents--;
            }
        }

        private int Find(int n)
        {
            if (rank[n] != n)
                rank[n] = Find(rank[n]);

            return rank[n];
        }
    }
}
