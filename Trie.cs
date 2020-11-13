using System.Collections.Generic;

namespace jooble
{
    class Node
    {
        public bool isLeaf = false;
        public Dictionary<char, Node> children;
        public Node()
        {
            children = new Dictionary<char, Node>();
        }
    }
    public class Trie
    {
        private Node root;
        public Trie()
        {
            root = new Node();
        }
        public void Insert(string word)
        {
            Node cur = root;
            foreach (char ch in word)
            {
                if (!cur.children.ContainsKey(ch))
                {
                    cur.children[ch] = new Node();
                }
                cur = cur.children[ch];
            }
            cur.isLeaf = true;
        }
        public bool Find(string word)
        {
            Node cur = root;
            int i = 0;
            while (i < word.Length)
            {
                if (cur.children.ContainsKey(word[i]))
                    cur = cur.children[word[i++]];
                else
                    return false;
            }
            return cur.isLeaf;
        }
    }
}