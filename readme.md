## Task
You're given a dictionary and a test set of words. For each word in the test set find a split with the most parts, that are present in a dictionary.
Example:
```
Input: psychologie
Output: psychologie //cannot be splitted

Input: Krankenhaus
Output: k, rankenm haus //splitted into 3 words
```

## Description of the algorithm
For each letter in a word we find all words that could be a part of the initial word and build a graph.
If starting on *__i__* position we can add word **"test"**, that there's an edge from *__i__* to *__i+4__*, because the length of **"test"** is 4.
Now using this graph, we find all possible ways from *__0__* position to the *__end__* of the given word.
Now from all possible splits we find one with the most parts and it would be our answer.

Let's:
    **N** = number of words in dictionary; 
    **LEN** = avarage word size is LEN;
    **M** = length of a given word;
Then current version of the algorithm will use ```O(N*LEN + M*M)``` memory, time complexity would be ```O(M^3)```  (because of the copying the string).
But let's keep in mind, ```M``` is the length of the word (in a given dictionary average length of a word is **11**, and maximum length = **25**), so it shoudn't be a problem to have a cubic complexity.
Anyway, it's good to improve our code when we have an opportunity. 
We can introduce **Trie** ([Prefix tree](https://en.wikipedia.org/wiki/Trie)). Algorithm would be similar, except now, for each starting position we won't be brute-forcing every length, and copy the word to check if it's in our dictionary because it worsens time complexity to **O(M^3)**, plus for this word we has to check if it is present in our dictonary, even though time complexity for a look up in a HashSet is constant, it takes time anyway. But now, as we use Trie, we can just interate through our trie stucture, and that way our time complexity will be reduced to **O(M^2)**, and we will get rid of checking our hashset everytime, because now for each node in Trie we know if it's a leaf(meaning the end of the word from dictionary).
Code, which implements trie and iterating can be found in branch [```trie```](https://github.com/GlebGlushko/Split-into-words/tree/trie)


## Example:

```
dictionary: ["a", "ab", "abcd", "bc", "cd", "d"]
word: "abcd"

Graph would be like that:
0: 1, 2, 4
1: 3
2: 4
3: 4

possible paths:
0->1->3->4  //stands for ["a", "bc", "d"]
0->2->4     //stands for ["ab", "cd"] 
0->4        //stands for ["abcd"]

First path is our answer
```
## Dynamic approach
For now, we build graph and traverse it choosing the split with most parts. But we use extra memory for storing graph, for storing current split and obviously for stack calls, because our depth-first-search is recursive. Let's simplify it.
As we have to find only one split with most words, we can come up with dynamic approach. For each char in a given word we will memorize how many words we used to get there and the last ancestor we came from. Maximum words we can use to split our word into parts will be stored in ```dp[LEN]```, where ```LEN``` is the length of the word. And we can restore our split, by going from current position to ancestor until we reach the beginning. 
It doesn't improve theoretical time complexity and memory usage, but in fact, it will work faster because we don't have to traverse the graph and it will use less memory, because we don't have to store graph and call stack for a recursive approach. And actually it makes our code even shorter.
Dynamic approach can be found in the branch [```dp```](https://github.com/GlebGlushko/Split-into-words/tree/dp).

For any questions please feel free to reach out via email: **gleb.glushko10@gmail.com**, or on telegram: **@HlibHlushko** 
