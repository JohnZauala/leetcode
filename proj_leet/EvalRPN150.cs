using System;
using System.Collections.Generic;

class EvalRPN150
{
    public int EvalRPN(string[] tokens) 
    {
        int N = tokens.Length;
        var stack = new Stack<string>();
        stack.Push(tokens[0]);
        int i = 1;
        while(stack.Count > 0 && i < N) {
            var cur = tokens[i];
            if (cur == "+" || cur == "-" || cur == "*" ||cur == "/") {
                var pre = stack.Pop();
                var prep = stack.Pop();
                int preZ = Convert.ToInt32(pre);
                int prepZ = Convert.ToInt32(prep);
                int res = 0;
                switch (cur)
                {   
                    case "+":
                        res = prepZ+preZ;
                        break;
                    case "-":
                        res = prepZ-preZ;
                        break;
                    case "*":
                        res = prepZ*preZ; 
                        break;
                    case "/":
                        res = prepZ/preZ;
                        break;
                }
                stack.Push(res.ToString());
            } else {
                stack.Push(cur);
            }
            
            i++;
        }
        return Convert.ToInt32(stack.Pop());
    }

    // static void Main(string[] args)
    // {
    //     var tokens = ["2","1","+","3","*"];
    //     var instance = new EvalRPN150();
    //     Console.WriteLine("word break: {0}", instance.EvalRPN(tokens));
        
    // }
}