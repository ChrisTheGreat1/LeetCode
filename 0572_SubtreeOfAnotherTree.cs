using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given the roots of two binary trees root and subRoot, 
    return true if there is a subtree of root with the same structure and node values of subRoot and false otherwise.

    A subtree of a binary tree tree is a tree that consists of a node in tree 
    and all of this node's descendants. The tree tree could also be considered as a subtree of itself.

    Input: root = [3,4,5,1,2], subRoot = [4,1,2]
    Output: true

    Input: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]
    Output: false

    Constraints:

    The number of nodes in the root tree is in the range [1, 2000].
    The number of nodes in the subRoot tree is in the range [1, 1000].
    -10^4 <= root.val <= 10^4
    -10^4 <= subRoot.val <= 10^4

    */

    internal class _0572_SubtreeOfAnotherTree
    {
        public void Result()
        {
            var node1 = new TreeNode(1, null, null);
            var node2 = new TreeNode(2, null, null);

            var node3 = new TreeNode(4, node1, node2);
            var node4 = new TreeNode(5, null, null);

            var tree1 = new TreeNode(3, node3, node4);

            var node5 = new TreeNode(1, null, null);
            var node6 = new TreeNode(2, null, null);

            var tree2 = new TreeNode(4, node5, node6);

            var result = IsSubtree(tree1, tree2);
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

        private bool IsSubtree(TreeNode? root, TreeNode? subRoot)
        {
            if (root == null) return root == subRoot;
            if (root.val == subRoot?.val && IsSameTree(root, subRoot)) return true;

            return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
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
