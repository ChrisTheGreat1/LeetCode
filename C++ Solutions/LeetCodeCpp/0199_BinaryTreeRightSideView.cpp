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

#include <vector>
#include <stack>
#include <queue>
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

class Solution {
public:
    vector<int> rightSideView(TreeNode* root) {
        if (root == NULL) {
            return {};
        }

        queue<TreeNode*> q;
        q.push(root);

        vector<int> result;

        while (!q.empty()) {
            int count = q.size();

            for (int i = count; i > 0; i--) {
                TreeNode* node = q.front();
                q.pop();

                if (i == count) {
                    result.push_back(node->val);
                }

                if (node->right != NULL) {
                    q.push(node->right);
                }
                if (node->left != NULL) {
                    q.push(node->left);
                }
            }
        }

        return result;
    }
};