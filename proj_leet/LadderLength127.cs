using System;
using System.Collections.Generic;
using System.Linq;
namespace LC
{
    //127. 单词接龙
    //https://leetcode.cn/problems/word-ladder/?favorite=2ckc81c
    class LadderLength127
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            List<bool> visited = new List<bool>();
            List<int[]> wordS = new List<int[]>(wordList.Count);
            foreach (var w in wordList)
            {
                int[] arr = ConvertToChars26(w);
                if (IsSame(arr, ConvertToChars26(beginWord)))
                    continue;

                visited.Add(false);
                wordS.Add(arr);
            }
            
            // foreach (var item in wordS)
            // {
            //     Console.WriteLine(string.Join(",", item));
            // }
            int count = LadderLength(ConvertToChars26(beginWord), ConvertToChars26(endWord), wordS, visited);
            return count == Int32.MaxValue ? 0 : count;
        }

        public int LadderLength(int[] curWord, int[] endWord, IList<int[]> wordList, List<bool> visited)
        {

        //  Console.WriteLine("cur: {0}, diff: {1}", string.Join("", curWord), DiffCharsCount(curWord,endWord));
            if (IsSame(curWord, endWord))
                return 1;

        
            int count = Int32.MaxValue;
            for (int i = 0; i < wordList.Count; i++)
            {
                if (visited[i])
                    continue;

                // Console.WriteLine("cur: {0}, diff: {1}", string.Join("", curWord), DiffCharsCount(curWord, wordList[i]));
                if (!IsDiffOneChar(curWord, wordList[i]))     
                    continue;

                // Console.WriteLine("cur: {0}, diff: {1}", string.Join("", curWord), DiffCharsCount(curWord, wordList[i]));

                visited[i] = true;
                int next = LadderLength(wordList[i], endWord, wordList, visited);
                if (next != Int32.MaxValue) {
                    count = Math.Min(count, next+1);        
                }
                visited[i] = false;
            }

            return count;
        }

        public int[] ConvertToChars26(string word)
        {
            int[] chs = new int[26];
            foreach (var ch in word)
            {
                chs[ch - 'a']++;
            }
            
            return chs;
        }

        public bool IsDiffOneChar(int[] a, int[] b)
        {
            return DiffCharsCount(a, b) == 2;
        }

        public bool IsSame(int[] a, int[] b)
        {
            return DiffCharsCount(a, b) == 0;
        }

        int DiffCharsCount(int[] a, int[] b)
        {
            int diff = 0;
            for (int i = 0; i < 26; i++)
            {
                diff += Math.Abs(a[i] - b[i]);
            }

            return diff;
        }

        // static void Main(string[] args)
        // {
        //     LadderLength127 instance = new LadderLength127();
            
        //     // string beginWord = "hit";
        //     // string endWord = "cog";
        //     // // string[] wordList = new string[]{"hot","dot","dog","lot","log","cog"};

        //     // string[] wordList = new string[]{"hot","dot","dog","lot","log"};

        //     string beginWord = "leet";
        //     string endWord = "code";
        //     string[] wordList = new string[]{"lest","leet","lose","code","lode","robe","lost"};

        //     Console.WriteLine("127. 单词接龙: {0}", instance.LadderLength(beginWord, endWord, wordList));
        
        // }
    }
}
