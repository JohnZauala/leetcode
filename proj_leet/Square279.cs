using System;
class Square279
{
    public static int NumSquares(int n) {
        int max = (int)Math.Sqrt(n);
        // Console.WriteLine("max{0}", max);
        return NumSquares(1, max, n);
    }

    public static int count = 0;

    public static void Log(int n) {
        string space = "";
        for (int i = 0; i < n; i++) {
            space += "  ";
        }
        Console.Write(space);
    }

    //i .. 自由尝试，返回需要的最少数量
    public static int NumSquares(int i, int max, int rest) {
        Log(count++);
        Console.WriteLine("i: {0}, rest: {1}", i, rest);
         if (rest == 0) {
            Log(count--);
            Console.WriteLine("return 0");
            return 0;
        }

        if (rest < 0 || i > max) {
            Log(count--);
            Console.WriteLine("return -1");
            return -1;
        }

    
        int p1 = Int32.MaxValue;
        for (int zhang = 0; zhang * i*i <= rest; zhang++) {
            int p2 = NumSquares(i+1, max, rest - zhang * i*i);
            Console.WriteLine("p2 {0}", p2);
            if (p2 != -1) {
                p2 += zhang;
                p1 = Math.Min(p2, p1);
            }
            
        }

        // int p1 = NumSquares(i+1, max, rest);
        // int p2 = NumSquares(i+1, max, rest - i*i);
        // if (p2 != -1) {
        //     p2 = p2 + 1;
        // }

         
        int res = (p1 == Int32.MaxValue) ? -1 : p1;
        Log(count--);
        Console.WriteLine("return {0}", res);
        return res;
    }
}