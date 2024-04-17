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

#include <iostream>
#include <vector>
#include <stack>
#include <string>
#include <unordered_set>

using namespace std;

 struct TreeNode {
     int val;
     TreeNode *left;
     TreeNode *right;
     TreeNode() : val(0), left(nullptr), right(nullptr) {}
     TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
     TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
 };

 class _0226_InvertBinaryTree {
 public:
     TreeNode* invertTree(TreeNode* root) {
         if (root == NULL) {
             return NULL;
         }
         swap(root->left, root->right);
         invertTree(root->left);
         invertTree(root->right);
         return root;
     }
 };