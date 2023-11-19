using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).

    Input: root = [3,9,20,null,null,15,7]
    Output: [[3],[9,20],[15,7]]

    Input: root = [1]
    Output: [[1]]

    Input: root = []
    Output: []
 
    Constraints:

    The number of nodes in the tree is in the range [0, 2000].
    -1000 <= Node.val <= 1000

    */
    internal class _0102_BinaryTreeLevelOrderTraversal
    {
        // Perform a Bread-First-Search on the binary tree.
        // Use a queue to add each tree level element from left to right.
        // Upon dequeueing the last item, add it's children to the queue.

        private IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null) return result;

            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (true)
            {
                var curLevelCount = q.Count;
                if (curLevelCount == 0) break;
                var curNodes = new List<int>();
                while (curLevelCount > 0)
                {
                    var cur = q.Dequeue();
                    curNodes.Add(cur.val);

                    if (cur.left != null)
                        q.Enqueue(cur.left);

                    if (cur.right != null)
                        q.Enqueue(cur.right);
                    curLevelCount--;
                }
                result.Add(curNodes);
            }

            return result;
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
