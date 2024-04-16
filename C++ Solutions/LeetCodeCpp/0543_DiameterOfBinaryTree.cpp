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

#include <vector>
#include <stack>
#include <string>
#include <unordered_set>

using namespace std;

struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode() : val(0), left(nullptr), right(nullptr) {}
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode* left, TreeNode* right) : val(x), left(left), right(right) {}
};

class _0543_DiameterOfBinaryTree {
public:
    int diameterOfBinaryTree(TreeNode* root) {
        int result = 0;
        dfs(root, result);
        return result;
    }
private:
    int dfs(TreeNode* root, int& result) {
        if (root == NULL) {
            return 0;
        }

        int left = dfs(root->left, result);
        int right = dfs(root->right, result);

        result = max(result, left + right);
        return 1 + max(left, right);
    }
};