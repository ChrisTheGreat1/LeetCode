using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given the root of a binary tree, return the length of the diameter of the tree.

    The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.

    The length of a path between two nodes is represented by the number of edges between them.

    Input: root = [1,2,3,4,5]
    Output: 3
    Explanation: 3 is the length of the path [4,2,1,3] or [5,2,1,3].

    Input: root = [1,2]
    Output: 1

    Constraints:

    The number of nodes in the tree is in the range [1, 10^4].
    -100 <= Node.val <= 100

    */

    internal class _0543_DiameterOfBinaryTree
    {
        public void Result()
        {
            var node1 = new TreeNode(4, null, null);
            var node2 = new TreeNode(5, null, null);

            var node3 = new TreeNode(2, node1, node2);
            var node4 = new TreeNode(3, null, null);

            var node5 = new TreeNode(1, node3, node4);

            var result = DiameterOfBinaryTree(node5);
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

        private int DiameterOfBinaryTree(TreeNode? root)
        {
            var max = 0;
            DepthFirstSearch(root, ref max);

            return max;
        }

        private int DepthFirstSearch(TreeNode? root, ref int max)
        {
            if (root == null) return 0;

            max = Math.Max(max, DepthFirstSearch(root.left, ref max) + DepthFirstSearch(root.right, ref max));

            return 1 + Math.Max(DepthFirstSearch(root.left, ref max), DepthFirstSearch(root.right, ref max));
        }
    }
}
