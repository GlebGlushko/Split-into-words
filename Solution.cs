using System.Collections.Generic;
using System.Linq;
using System;
namespace jooble
{
    public class Solution
    {
        private int[] dp;
        private int[] ancestor;
        private Trie dictionary;
        public Solution(Trie dict)
        {
            dictionary = dict;
        }

        public string[] splitIntoWords(string word)
        {
            int len = word.Length;
            word = word.ToLower();

            dp = new int[len + 1];
            ancestor = new int[len + 1];
            Array.Fill(ancestor, -1);
            dp[0] = 1;

            for (int i = 0; i < len; ++i)
            {
                if (dp[i] == 0 || !dictionary.root.children.ContainsKey(word[i])) continue;
                Node cur = dictionary.root.children[word[i]];

                for (int l = 0; i + l < len; ++l)
                {
                    if (cur.isLeaf)
                    {
                        if (dp[i + l + 1] < dp[i] + 1)
                        {
                            dp[i + l + 1] = dp[i] + 1;
                            ancestor[i + l + 1] = i;
                        }
                    }
                    if (i + l + 1 < len && cur.children.ContainsKey(word[i + l + 1]))
                        cur = cur.children[word[i + l + 1]];
                    else break;
                }

            }

            if (dp[len] == 0) return new string[] { word };
            string[] ans = new string[dp[len] - 1];
            int rp = len;
            int lp = ancestor[len];
            int it = dp[len] - 2;
            while (lp != -1)
            {
                ans[it--] = word.Substring(lp, rp - lp);
                rp = lp;
                lp = ancestor[lp];
            }
            return ans;
        }
    }
}

//krakenhaus
//0123456789

//krankenhaus
//kran, k, en, haus // разбили на 4 части