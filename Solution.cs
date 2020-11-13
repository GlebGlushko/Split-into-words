using System.Collections.Generic;
using System.Linq;
using System;
namespace jooble
{
    public class Solution
    {
        private int[] bestSplit;
        private Dictionary<int, List<int>> graph;
        private Trie dictionary;
        public Solution(Trie dict)
        {
            dictionary = dict;
            graph = new Dictionary<int, List<int>>();
        }

        private void dfs(int current_ind, List<int> current_split, string original)
        {
            if (current_ind == original.Length)
            {
                if (bestSplit == null || bestSplit.Length < current_split.Count)
                {
                    bestSplit = new int[current_split.Count];
                    current_split.CopyTo(bestSplit);
                }
                return;
            }

            foreach (int next in graph[current_ind])
            {
                current_split.Add(next - 1);
                dfs(next, current_split, original);
                current_split.Remove(current_split.Last());
            }

        }
        public string[] splitIntoWords(string word)
        {
            int len = word.Length;
            word = word.ToLower();

            for (int i = 0; i < len; ++i)
                graph[i] = new List<int>();

            for (int i = 0; i <= len; ++i)
                for (int l = 1; l + i <= len; ++l)
                {
                    string sub = word.Substring(i, l);
                    if (dictionary.Find(sub))
                    {
                        graph[i].Add(i + l);
                    }
                }
            dfs(0, new List<int> { }, word);

            if (bestSplit == null) return new string[] { word };
            string[] ans = new string[bestSplit.Length];
            int start = 0;
            for (int i = 0; i < bestSplit.Length; ++i)
            {
                ans[i] = word.Substring(start, bestSplit[i] - start + 1);
                start = bestSplit[i] + 1;
            }
            return ans;
        }
    }
}

//krakenhaus
//0123456789

//krankenhaus
//kran, k, en, haus // разбили на 4 части