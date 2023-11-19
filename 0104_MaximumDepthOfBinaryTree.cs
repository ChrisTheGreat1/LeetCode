using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given the root of a binary tree, return its maximum depth.

    A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

    Input: root = [3,9,20,null,null,15,7]
    Output: 3

    Input: root = [1,null,2]
    Output: 2

    Constraints:

    The number of nodes in the tree is in the range [0, 10^4].
    -100 <= Node.val <= 100

    */

    internal class _0104_MaximumDepthOfBinaryTree
    {
        public void Result()
        {
            var node1 = new TreeNode(7, null, null);
            var node2 = new TreeNode(15, null, null);

            var node3 = new TreeNode(20, node2, node1);

            var node4 = new TreeNode(9, null, null);

            var node5 = new TreeNode(3, node4, node3);

            var result = MaxDepth(node5);
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

        private int MaxDepth(TreeNode? root)
        {
            if (root == null) return 0;

            return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
        }
    }
}
