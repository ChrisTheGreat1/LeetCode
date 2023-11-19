using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given the root of a binary tree, determine if it is a valid binary search tree (BST).

    A valid BST is defined as follows:

    - The left subtree of a node contains only nodes with keys less than the node's key.
    - The right subtree of a node contains only nodes with keys greater than the node's key.
    - Both the left and right subtrees must also be binary search trees.

    Input: root = [2,1,3]
    Output: true

    Input: root = [5,1,4,null,null,3,6]
    Output: false
    Explanation: The root node's value is 5 but its right child's value is 4.
 
    Constraints:

    The number of nodes in the tree is in the range [1, 10^4].
    -2^31 <= Node.val <= 2^31 - 1

    */

    internal class _0098_ValidateBinarySearchTree
    {
        private bool IsValidBST(TreeNode root)
        {
            return Evaluate(root, long.MinValue, long.MaxValue);
        }

        private bool Evaluate(TreeNode node, long min, long max)
        {
            if (node == null)
            {
                return true;
            }

            return (
                node.val > min &&
                node.val < max &&
                Evaluate(node.left, min, node.val) && Evaluate(node.right, node.val, max)
            );
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
