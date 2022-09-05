using System;
using System.Collections.Generic;

class WordBreak139 
{
    public bool WordBreak(string s, IList<string> wordDict) 
    {
        var dp = new Dictionary<string, bool>();
        return process(s, wordDict, dp);
    }

    public bool process(string rest, IList<string> wordDict, Dictionary<string, bool> dp) 
    {
        if (dp.ContainsKey(rest))
            return dp[rest];

        if (rest.Length == 0) {
            return true;
        }

        bool ans = false;
        foreach (var word in wordDict)
        {
            if (rest.Length >= word.Length) {
                if (rest.Substring(0, word.Length) == word) {
                    ans = ans ||  process(rest.Substring(word.Length), wordDict, dp);
                }
            } 
        }

        dp[rest] = ans;

        return ans;
    }

    // static void Main(string[] args)
    // {
    //     var s = "leetcode";
    //     var wordDict = new string[]{"leet", "code"};
    //     var instance = new WordBreak139();
    //     Console.WriteLine("word break: {0}", instance.WordBreak(s, wordDict));
        
    // }
}
