using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*

    Given the roots of two binary trees p and q, write a function to check if they are the same or not.

    Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.

    Input: p = [1,2,3], q = [1,2,3]
    Output: true

    Input: p = [1,2], q = [1,null,2]
    Output: false

    Input: p = [1,2,1], q = [1,1,2]
    Output: false

    Constraints:

    The number of nodes in both trees is in the range [0, 100].
    -10^4 <= Node.val <= 10^4
    
    */
    internal class _0100_SameTree
    {
        public void Result()
        {
            var node1 = new TreeNode(2, null, null);
            var node2 = new TreeNode(3, null, null);

            var tree1 = new TreeNode(1, node1, node2);

            var node3 = new TreeNode(2, null, null);
            var node4 = new TreeNode(3, null, null);

            var tree2 = new TreeNode(1, node3, node4);

            var result = IsSameTree(tree1, tree2);
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

        private bool IsSameTree(TreeNode? p, TreeNode? q)
        {
            if ((p == null) && (q == null)) return true;
            if ((p == null) && (q != null)) return false;
            if ((p != null) && (q == null)) return false;
            if (p!.val != q!.val) return false;

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
    }
}
