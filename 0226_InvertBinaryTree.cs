using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given the root of a binary tree, invert the tree, and return its root.

    Input: root = [4,2,7,1,3,6,9]
    Output: [4,7,2,9,6,3,1]

    Input: root = [2,1,3]
    Output: [2,3,1]

    Input: root = []
    Output: []
 
    Constraints:

    The number of nodes in the tree is in the range [0, 100].
    -100 <= Node.val <= 100

    */

    internal class _0226_InvertBinaryTree
    {
        public void Result()
        {
            // root = [4,2,7,1,3,6,9]

            var node1 = new TreeNode(9, null, null);
            var node2 = new TreeNode(6, null, null);

            var node3 = new TreeNode(3, null, null);
            var node4 = new TreeNode(1, null, null);

            var node5 = new TreeNode(7, node2, node1);
            var node6 = new TreeNode(2, node4, node3);

            var node7 = new TreeNode(4, node6, node5);

            var result = InvertTree(node7);
        }

        private class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        private TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;

            var tmp = root.left;
            root.left = root.right;
            root.right = tmp;

            InvertTree(root.left);
            InvertTree(root.right);

            return root;
        }
    }
}
