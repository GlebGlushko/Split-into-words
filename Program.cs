using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;
namespace jooble
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = @"./data/dict.txt";
            HashSet<string> dictionary = new HashSet<string>();

            using (StreamReader file = new StreamReader(path))
            {
                string entry;
                while ((entry = file.ReadLine()) != null)
                {
                    if (entry != null)
                        dictionary.Add(entry.ToLower());
                    else
                        break;
                }
            }
            string request;
            while ((request = Console.ReadLine()) != null)
            {
                Solution sol = new Solution(dictionary);
                request.ToLower();
                var res = sol.splitIntoWords(request);
                int len = res.Length;
                for (int i = 0; i < len; ++i)
                {
                    Console.Write(res[i]);
                    if (i < len - 1) Console.Write(", ");
                }
                string info = " // ";
                info += (len > 1 ? $"разбили на {len} части" : $"невозможно разбить");
                Console.WriteLine(info);

            }
        }
    }

}
