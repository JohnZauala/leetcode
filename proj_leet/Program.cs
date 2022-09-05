using System;

namespace proj_leet
{


    class Program
    {
        //01 背包问题测试
        // 输入: N = 3, V = 5, v = [4,2,3], w = [4,2,3]
        // 输出: 5
        // 解释: 不选第一件物品，选择第二件和第三件物品，可使价值最大。
        //体积v[]  价值：w[]
        // static void Main(string[] args)
        // {
        //     int N = 7, V = 20;
        //     int[] v = new int[] {4, 2, 3, 5, 1, 6, 7};
        //     int[] w = new int[] {4, 2, 3, 6, 2, 5, 9};
        //     Console.WriteLine("dp: {0}", Solution.Dp1(N, w, v, 0, V));
        //     Console.WriteLine("max: {0}", Solution.maxValue(N, V, v, w));
        //     Console.WriteLine("dp2: {0}", Solution.Dp2(N, V, v, w));
        //     Console.WriteLine("dp3: {0}", Solution.Dp3(N, V, v, w));
        //     Console.WriteLine("dp4: {0}", Solution.Dp4(N, V, v, w));
            
        // }

        //完全背包问题测试
        // static void Main(string[] args)
        // {
        //     // int N = 7, V = 20;
        //     // int[] v = new int[] {4, 2, 3, 5, 1, 6, 7};
        //     // int[] w = new int[] {4, 2, 3, 6, 2, 5, 9};

        //     // Console.WriteLine("max: {0}", AllPack.maxValue(N, V, v, w));
        //     // Console.WriteLine("dp1: {0}", AllPack.Dp1(N, v, w, 0, V));
        //     // Console.WriteLine("dp2: {0}", AllPack.Dp2(N, v, w, V));
            
        //     // Console.WriteLine("dp2: {0}", Solution.Dp2(N, V, v, w));
        //     // Console.WriteLine("dp3: {0}", Solution.Dp3(N, V, v, w));
        //     // Console.WriteLine("dp4: {0}", Solution.Dp4(N, V, v, w));

        //     // Console.WriteLine("dp0: {0}", Square279.NumSquares(13));

        //     WorldSearch79 worldSearch79 = new WorldSearch79();
        //     // char[][] board = new char[][]{new char[]{'A','B','C','E'},new char[]{'S','F','C','S'},new char[]{'A','D','E','E'}};
        //     // string word = new string("ABCB");
        //     // char[][] board = new char[][]{new char[]{'a'}};
        //     // string word = "a";

        //      char[][] board = new char[][]{new char[]{'a','b'},new char[]{'c','d'}};
        //     string word = new string("cdba");
        // //   char[][] board = new char[][]{new char[]{'a'},new char[]{'b'}};
        // //     string word = new string("ba");
        //     Console.WriteLine("exist0: {0}", worldSearch79.Exist(board, word));
            
            
        // }

        static void Main(string[] args)
        {
            // var s = "leetcode";
            // var wordDict = new string[]{"leet", "code"};

            // var s = "applepenapple";
            // var wordDict = new string[]{"apple", "pen"};

            var s = "catsandog";
            var wordDict = new string[]{"cats", "dog", "sand", "and", "cat"};

            var instance = new WordBreak139();
            Console.WriteLine("word break: {0}", instance.WordBreak(s, wordDict));
            
        }
    }
}
