using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given a binary tree, determine if it is height-balanced.

    A height-balanced binary tree is a binary tree in which the depth of the two subtrees of every node never differs by more than one.

    Input: root = [3,9,20,null,null,15,7]
    Output: true

    Input: root = [1,2,2,3,3,null,null,4,4]
    Output: false

    Input: root = []
    Output: true

    Constraints:

    The number of nodes in the tree is in the range [0, 5000].
    -10^4 <= Node.val <= 10^4

    */

    internal class _0110_BalancedBinaryTree
    {
        public void Result()
        {
            var node1 = new TreeNode(15, null, null);
            var node2 = new TreeNode(7, null, null);

            var node3 = new TreeNode(20, node1, node2);
            var node4 = new TreeNode(9, null, null);

            var node5 = new TreeNode(3, node4, node3);

            var result = IsBalanced(node5);
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

        private int Dfs(TreeNode? root, ref bool result)
        {
            if (root == null)
            {
                return -1;
            }

            var leftDepth = Dfs(root.left, ref result);
            var rightDepth = Dfs(root.right, ref result);

            result = result && (Math.Abs(rightDepth - leftDepth) <= 1);

            return Math.Max(leftDepth, rightDepth) + 1;
        }

        private bool IsBalanced(TreeNode root)
        {
            var result = true;
            Dfs(root, ref result);
            return result;
        }
    }
}
