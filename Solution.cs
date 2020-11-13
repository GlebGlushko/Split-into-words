using System.Collections.Generic;
using System.Linq;
namespace jooble
{
    public class Solution
    {
        private string[] bestSplit;
        private Dictionary<int, List<int>> graph;
        private HashSet<string> dictionary;
        public Solution(HashSet<string> dict)
        {
            dictionary = dict;
            graph = new Dictionary<int, List<int>>();
        }

        private void dfs(int current_ind, List<string> current_split, string original)
        {
            if (current_ind == original.Length)
            {
                if (bestSplit == null || bestSplit.Length < current_split.Count)
                {
                    bestSplit = new string[current_split.Count];
                    current_split.CopyTo(bestSplit);
                }
                return;
            }

            foreach (int next in graph[current_ind])
            {
                current_split.Add(original.Substring(current_ind, next - current_ind));
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
                    if (dictionary.Contains(sub))
                    {
                        graph[i].Add(i + l);
                    }
                }
            dfs(0, new List<string> { }, word);

            if (bestSplit == null) return new string[] { word };
            return bestSplit;
        }
    }
}