using System;
using System.Collections.Generic;

class WordBreak140 
{
    // public IList<string> WordBreak(string s, IList<string> wordDict) 
    // {

    // }

    // public bool process(string rest, IList<string> wordDict, string path, List<string> res) 
    // {
    //     if (dp.ContainsKey(rest))
    //         return dp[rest];

    //     if (rest.Length == 0) {
    //         return true;
    //     }

    //     bool ans = false;
    //     foreach (var word in wordDict)
    //     {
    //         if (rest.Length >= word.Length) {
    //             if (rest.Substring(0, word.Length) == word) {
    //                 ans = ans ||  process(rest.Substring(word.Length), wordDict, dp);
    //             }
    //         } 
    //     }

    //     dp[rest] = ans;

    //     return ans;
    // }

    // static void Main(string[] args)
    // {
    //     var s = "leetcode";
    //     var wordDict = new string[]{"leet", "code"};
    //     var instance = new WordBreak139();
    //     Console.WriteLine("word break: {0}", instance.WordBreak(s, wordDict));
        
    // }
}
