using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    A trie (pronounced as "try") or prefix tree is a tree data structure used to efficiently store and retrieve keys in a dataset of strings. There are various applications of this data structure, such as autocomplete and spellchecker.

    Implement the Trie class:

    Trie() Initializes the trie object.
    void insert(String word) Inserts the string word into the trie.
    boolean search(String word) Returns true if the string word is in the trie (i.e., was inserted before), and false otherwise.
    boolean startsWith(String prefix) Returns true if there is a previously inserted string word that has the prefix prefix, and false otherwise.

    Input
    ["Trie", "insert", "search", "search", "startsWith", "insert", "search"]
    [[], ["apple"], ["apple"], ["app"], ["app"], ["app"], ["app"]]
   
    Output
    [null, null, true, false, true, null, true]

    Explanation
    Trie trie = new Trie();
    trie.insert("apple");
    trie.search("apple");   // return True
    trie.search("app");     // return False
    trie.startsWith("app"); // return True
    trie.insert("app");
    trie.search("app");     // return True
 
    Constraints:

    1 <= word.length, prefix.length <= 2000
    word and prefix consist only of lowercase English letters.
    At most 3 * 10^4 calls in total will be made to insert, search, and startsWith.

    */

    /**
     * Your Trie object will be instantiated and called as such:
     * Trie obj = new Trie();
     * obj.Insert(word);
     * bool param_2 = obj.Search(word);
     * bool param_3 = obj.StartsWith(prefix);
     */

    internal class _0208_ImplementTriePrefixTree
    {
        public class TrieNode
        {
            public TrieNode()
            {
                childrenMap = new Dictionary<char, TrieNode>();
            }
            public Dictionary<char, TrieNode> childrenMap { get; set; }
            public bool isWord { get; set; }
        }

        public class Trie
        {
            private TrieNode root;

            public Trie()
            {
                root = new TrieNode();
            }

            public void Insert(string word)
            {
                var cur = root;
                foreach (var c in word)
                {
                    if (!cur.childrenMap.ContainsKey(c))
                    {
                        cur.childrenMap[c] = new TrieNode();
                    }
                    cur = cur.childrenMap[c];
                }
                cur.isWord = true;
            }

            public bool Search(string word)
            {
                var node = traverse(word);
                return node != null && node.isWord;
            }

            public bool StartsWith(string prefix)
            {
                var node = traverse(prefix);
                return node != null;
            }

            private TrieNode traverse(string path)
            {
                var cur = root;

                foreach (var c in path)
                {
                    if (cur.childrenMap.ContainsKey(c))
                    {
                        cur = cur.childrenMap[c];
                    }
                    else
                    {
                        return null;
                    }
                }
                return cur;
            }
        }
    }
}
