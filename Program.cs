using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;
namespace jooble
{
    class Program
    {
        static (string, string) parse(string req)
        {
            return (req[0].ToString() + req[1], req.Substring(3, req.Length - 3));
        }
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
            const string test_path = @"./data/de-test-words.tsv";
            const string res_path = @"./data/de-test-words_result.tsv";
            using (StreamReader file = new StreamReader(test_path))
            using (StreamWriter output = new StreamWriter(res_path))
            {
                output.WriteLine(file.ReadLine());

                while ((request = file.ReadLine()) != null)
                // while ((request = Console.ReadLine()) != null)
                {
                    var tup = parse(request);
                    string countryCode = tup.Item1;
                    string word = tup.Item2;
                    Solution sol = new Solution(dictionary);
                    request.ToLower();
                    var res = sol.splitIntoWords(word);
                    int len = res.Length;
                    output.Write($"{countryCode}    ");
                    for (int i = 0; i < len; ++i)
                    {
                        // Console.Write(res[i]);
                        // if (i < len - 1) Console.Write(", ");
                        output.Write(res[i]);
                        if (i < len - 1) output.Write(", ");
                    }
                    string info = " // ";
                    info += (len > 1 ? $"разбили на {len} части" : $"невозможно разбить");
                    output.WriteLine(info);

                }
            }
        }
    }

}
