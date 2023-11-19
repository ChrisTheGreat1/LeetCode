using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given the root of a binary tree, imagine yourself standing on the right side of it (looking horizontally across at it, not from the bottom), 
    return the values of the nodes you can see ordered from top to bottom.

    Input: root = [1,2,3,null,5,null,4]
    Output: [1,3,4]

    Input: root = [1,null,3]
    Output: [1,3]

    Input: root = []
    Output: []
 
    Constraints:

    The number of nodes in the tree is in the range [0, 100].
    -100 <= Node.val <= 100

    */
    internal class _0199_BinaryTreeRightSideView
    {
        private IList<int> RightSideView(TreeNode root)
        {
            var _result = new List<int>();

            Dfs(root, 0, ref _result);
            return _result;
        }

        private void Dfs(TreeNode root, int level, ref List<int> _result)
        {
            if (root == null) return;
            if (level >= _result.Count) _result.Add(root.val); // If the right node was put in first, the Count check will fail and not add the left node

            // At first visit right node
            Dfs(root.right, level + 1, ref _result);
            Dfs(root.left, level + 1, ref _result);
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
