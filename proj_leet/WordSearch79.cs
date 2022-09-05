using System;
using System.Collections.Generic;
class WorldSearch79 
{  
    public bool Exist(char[][] board, string word) 
    {
        // LinkedList<char> list = new LinkedList<char>();
        // char[] chs = word.ToCharArray();
        // foreach (var ch in chs)
        // {
        //     list.AddLast(ch);
        // }

        int N = board.Length;
        int M = board[0].Length;
        // bool[,] visit = new bool[N, M];

        bool ans = false;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                if (board[i][j] == word[0]) {
                    bool[,] visit = new bool[N, M];
                    LinkedList<char> list = new LinkedList<char>();
                    char[] chs = word.ToCharArray();
                    foreach (var ch in chs)
                    {
                        list.AddLast(ch);
                    }
                    ans = Exist(board, i, j, list, visit);
                    if (ans)
                        return ans;
                }
            }
        }
       
        return ans;
    }

    public  int count = 0;

    public  void Log(int n) {
        string space = "";
        for (int i = 0; i < n; i++) {
            space += "  ";
        }
        Console.Write(space);
    }

    public bool Exist(char[][] board, int i, int j, LinkedList<char> chars, bool[,] visit)
    {
        Log(count++);
        Console.Write("i: {0}, j : {1}   ", i, j);
        Console.WriteLine(String.Join(", ", new List<char>(chars)));

        if (chars.Count == 0) {
            --count;
            Log(count);
            Console.WriteLine("return true");
            return true;
        }

        int N = board.Length;
        int M = board[0].Length;
        if (i < 0 || i >= N || j < 0 || j >= M) {
            --count;
            Log(count);
            Console.WriteLine("return false");
            return false;
        }
            

        if (visit[i, j]) {
            Log(--count);
            Console.WriteLine("return  visit false");
            return false;
        }
          
        visit[i, j] = true;

        var ch = board[i][j];
        var first = chars.First.Value;
        if (ch != first) {
            visit[i, j] = false;
            Log(--count);
            Console.WriteLine("return ch != first false");
            return false;
        }
       

        chars.RemoveFirst();


        bool ans = false;
        ans = ans || Exist(board, i+1, j, chars, visit);

        ans = ans || Exist(board, i-1, j, chars, visit);

        ans = ans || Exist(board, i, j+1, chars, visit);

        ans = ans || Exist(board, i, j-1, chars, visit);


        chars.AddFirst(first);

        Log(--count);
        Console.WriteLine("return ans: {0}", ans);
   
        visit[i, j] = false;

        return ans;
    }

}