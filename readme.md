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
