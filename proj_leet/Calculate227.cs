using System;
using System.Collections.Generic;
using System.Linq;
namespace LC
{
    //227. 基本计算器 II
    //https://leetcode.cn/problems/basic-calculator-ii/?favorite=2ckc81c
    class Calculate227
    {
        public int Calculate(string s) 
        {
            Stack<int> nums = new Stack<int>();
            Stack<char> ops = new Stack<char>();

            //3+2*2
            char[] chs = s.ToCharArray();
            int N = chs.Length;
            int cur = 0;
            for (int i = 0; i < N; i++)
            {
                if (chs[i] == ' ') 
                {
                    continue;
                } //1*2-3/4+5*6-7*8+9/10
                else if (chs[i] == '+' || chs[i] == '-' || chs[i] == '*' || chs[i] == '/')
                {

                    nums.Push(cur);
                    cur = 0;
                    while (ops.Count > 0) {
                        char op = ops.Peek();
                        if (op == '*' || op == '/' || chs[i] == '+' || chs[i] == '-')
                        {
                            if (nums.Count >= 2)
                            {
                                op = ops.Pop();
                                int num1 = nums.Pop();
                                int num2 = nums.Pop();
                                int ret = Cal(num2, num1, op);
                                // Console.WriteLine("num2: {0}, num1:{1}, op: {2}, ret:{3}", num2, num1, op, ret);
                                nums.Push(ret);
                            }
                        } else{
                            break;
                        }
                        
                    } 
                    ops.Push(chs[i]);
                }
                else 
                {
                    int num = chs[i] - '0';
                    cur = cur * 10 + num;
                   
                }
                
            }
            nums.Push(cur);
        
            int res = 0;
            while (nums.Count > 0)
            {  
                if (ops.Count > 0 && nums.Count >= 2)
                {
                    char op = ops.Pop();
                    int num1 = nums.Pop();
                    int num2 = nums.Pop();
                    int ret = Cal(num2, num1, op);
                    nums.Push(ret);
                    // Console.WriteLine("num2: {0}, num1:{1}, op: {2}, ret:{3}, res: {4}", num2, num1, op, ret, res);
                    res = ret;
                } else {
                    res = nums.Pop();
                }
            }
            return res;
        }

        public int Cal(int a, int b, char op)
        {
            switch (op)
            {
                case '+':
                    return a+b;
                case '-':
                    return a-b;
                case '*':
                    return a*b;
                case '/':
                    return a/b; 
            }
            return 1;
        }

        static void Main(string[] args)
        {
            Calculate227 instance = new Calculate227();
            string s = "1*2-3/4+5*6-7*8+9/10";
           
            Console.WriteLine("227. 基本计算器 II: {0}", instance.Calculate(s));
        
        }
    }
}
