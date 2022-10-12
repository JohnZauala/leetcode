using System;
using System.Text;
using System.Collections.Generic;

//https://leetcode.cn/problems/multiply-strings/description/
//43. 字符串相乘

class Multiply43
{
    public string Multiply(string num1, string num2) 
    {
        int len1 = num1.Length;
        int len2 = num2.Length;

        if (num1[0] == '0' || num2[0] == '0')
            return "0";

        List<string> list = new List<string>();
        int carry = 0;
        for (int i = len1-1; i >= 0; i--)
        {
            int a = num1[i] - '0';
            if (a == 0)
                continue;
            carry = 0;
            StringBuilder sb = new StringBuilder(new string('0', len1-1-i));
            for (int j = len2-1; j >= 0; j--)
            {
                int b = num2[j] - '0';
        
                int t = a * b + carry; 
                int c = t%10;
                sb.Insert(0, c);
                carry = t/10;
            }
            if (carry > 0) {
                sb.Insert(0, carry);
            }

            list.Add(sb.ToString());
        }

        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);   
        }
        string pre = list[0];
        for (int i = 1; i < list.Count; i++)
        {

            pre = AddStrings(pre, list[i]);
        }

        if (pre[0] == '0')
            pre = "0";
        return pre;
    }

    public string AddStrings(string num1, string num2) 
    {
        int len1 = num1.Length;
        int len2 = num2.Length;

        StringBuilder sb = new StringBuilder();
        int carry = 0;
        
        int i = len1-1;
        int j = len2-1;
        while (i >= 0 || j >= 0)
        {
            int a = i >= 0 ? num1[i] - '0' : 0;
            int b = j >= 0 ? num2[j] - '0' : 0;

            int t = a+b+carry;
            int c = (t)%10;
            sb.Insert(0, c);

            carry = (t)/10;
            
            i--;
            j--;
            
        }

        if (carry > 0) {
             sb.Insert(0, carry);
        }

        return sb.ToString();
    }

    
    static void Main(string[] args)
    {
        // string num1 = "11";
        // string num2 = "123";
        string num1 = "6";
        string num2 = "501";
        // string num1 = "999";
        // string num2 = "99";
        var instance = new Multiply43();
        Console.WriteLine("Multiply43: {0}",instance.Multiply(num1, num2) );
        
    }
}