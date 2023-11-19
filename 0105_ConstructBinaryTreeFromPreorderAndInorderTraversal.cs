using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given two integer arrays preorder and inorder where preorder is the preorder traversal 
    of a binary tree and inorder is the inorder traversal of the same tree, construct and return the binary tree.

    Input: preorder = [3,9,20,15,7], inorder = [9,3,15,20,7]
    Output: [3,9,20,null,null,15,7]

    Input: preorder = [-1], inorder = [-1]
    Output: [-1]

    Constraints:

    1 <= preorder.length <= 3000
    inorder.length == preorder.length
    -3000 <= preorder[i], inorder[i] <= 3000
    preorder and inorder consist of unique values.
    Each value of inorder also appears in preorder.
    preorder is guaranteed to be the preorder traversal of the tree.
    inorder is guaranteed to be the inorder traversal of the tree.

    */

    internal class _0105_ConstructBinaryTreeFromPreorderAndInorderTraversal
    {
        private TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return BuildTreeHelper(0, 0, inorder.Length - 1, preorder, inorder);
        }

        private TreeNode BuildTreeHelper(int preStart, int inStart, int inEnd, int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0 && inorder.Length == 0)
                return null;

            if (preStart > preorder.Length - 1 || inStart > inEnd)
                return null;

            var rootNode = new TreeNode(preorder[preStart]);
            var mid = Array.IndexOf(inorder, preorder[preStart]);

            rootNode.left = BuildTreeHelper(preStart + 1, inStart, mid - 1, preorder, inorder);
            rootNode.right = BuildTreeHelper(preStart + mid - inStart + 1, mid + 1, inEnd, preorder, inorder);

            return rootNode;
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
