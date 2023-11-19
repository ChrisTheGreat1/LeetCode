using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given the root of a binary search tree, and an integer k, 
    return the kth smallest value (1-indexed) of all the values of the nodes in the tree.

    Input: root = [3,1,4,null,2], k = 1
    Output: 1

    Input: root = [5,3,6,2,4,null,null,1], k = 3
    Output: 3

    Constraints:

    The number of nodes in the tree is n.
    1 <= k <= n <= 10^4
    0 <= Node.val <= 10^4

    */
    internal class _0230_KthSmallestElementInBST
    {
        private int KthSmallest(TreeNode root, int k)
        {
            int i = 0, solution = 0;

            DFSinorder(root);

            return solution;

            void DFSinorder(TreeNode node)
            {
                if (node == null) return;
                DFSinorder(node.left);
                i++;
                if (i == k) solution = node.val;
                DFSinorder(node.right);
            }
        }

        private class TreeNode
        {
            public int val;
            public TreeNode? left;
            public TreeNode? right;
            public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}
