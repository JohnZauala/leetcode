using System;
using System.Collections.Generic;

//https://leetcode.cn/problems/nim-game/?favorite=ex0k24j
//292. Nim 游戏

class CanWinNim292
{
    //弄完博弈之后再做
    public bool CanWinNim(int n) 
    {
        return f(n) == "先手";
    }

    public string f(int n)
    {
        if (n <= 3)
            return "先手";

        if (g(n-1) == "后手"
        || g(n-2) == "后手"
        || g(n-3) == "后手")
            return "后手";

        return "先手";
    }

    public string g(int n)
    {
        if (n <= 3)
            return "后手";

        if (f(n-1) == "先手"
        || f(n-2) == "先手"
        || f(n-3) == "先手")
            return "先手";

        return "后手";
    }
    

    // static void Main(string[] args)
    // {
    //     int n = 10;
    //     var instance = new CanWinNim292();
    //     Console.WriteLine("CanWinNim292: {0}",instance.CanWinNim(n) );
        
    // }
}