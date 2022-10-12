using System;
using System.Text;
using System.Collections.Generic;

//https://leetcode.cn/problems/add-strings/
//415. 字符串相加

class AddStrings415
{
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

    
    // static void Main(string[] args)
    // {
    //     string num1 = "11";
    //     string num2 = "123";
    //     // string num1 = "0";
    //     // string num2 = "0";
    //     // string num1 = "999";
    //     // string num2 = "99";
    //     var instance = new AddStrings415();
    //     Console.WriteLine("AddStrings: {0}",instance.AddStrings(num1, num2) );
        
    // }
}