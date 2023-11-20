using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Design a data structure that supports adding new words and finding if a string matches any previously added string.

    Implement the WordDictionary class:

    WordDictionary() Initializes the object.
    void addWord(word) Adds word to the data structure, it can be matched later.
    bool search(word) Returns true if there is any string in the data structure that matches word or false otherwise. word may contain dots '.' where dots can be matched with any letter.

    Input
    ["WordDictionary","addWord","addWord","addWord","search","search","search","search"]
    [[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]
    
    Output
    [null,null,null,null,false,true,true,true]

    Explanation
    WordDictionary wordDictionary = new WordDictionary();
    wordDictionary.addWord("bad");
    wordDictionary.addWord("dad");
    wordDictionary.addWord("mad");
    wordDictionary.search("pad"); // return False
    wordDictionary.search("bad"); // return True
    wordDictionary.search(".ad"); // return True
    wordDictionary.search("b.."); // return True
 

    Constraints:

    1 <= word.length <= 25
    word in addWord consists of lowercase English letters.
    word in search consist of '.' or lowercase English letters.
    There will be at most 2 dots in word for search queries.
    At most 10^4 calls will be made to addWord and search.

    */

    /**
     * Your WordDictionary object will be instantiated and called as such:
     * WordDictionary obj = new WordDictionary();
     * obj.AddWord(word);
     * bool param_2 = obj.Search(word);
     */

    internal class _0211_DesignAddAndSearchWordsDataStructure
    {
        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children;
            public bool EndOfWord;

            public TrieNode()
            {
                Children = new Dictionary<char, TrieNode>();
                EndOfWord = false;
            }
        }

        public class WordDictionary
        {
            public TrieNode root;

            public WordDictionary()
            {
                root = new TrieNode();
            }

            public void AddWord(string word)
            {
                var current = root;
                for (var i = 0; i < word.Length; i++)
                {
                    if (!current.Children.ContainsKey(word[i]))
                    {
                        var newNode = new TrieNode();
                        current.Children.Add(word[i], newNode);
                    }
                    current = current.Children[word[i]];
                }
                current.EndOfWord = true;
            }

            public bool Search(string word)
            {
                return dfs(0, root, word);
            }

            private bool dfs(int index, TrieNode root, string word)
            {
                var currentNode = root;

                for (var i = index; i < word.Length; i++)
                {
                    var letter = word[i];
                    if (letter == '.')
                    {
                        foreach (var (key, value) in currentNode.Children)
                        {
                            if (dfs(i + 1, value, word))
                            {
                                return true;
                            }
                        }

                        return false;
                    }
                    else
                    {
                        if (!currentNode.Children.ContainsKey(letter))
                        {
                            return false;
                        }
                        currentNode = currentNode.Children[letter];
                    }
                }
                return currentNode.EndOfWord;
            }
        }
    }
}
