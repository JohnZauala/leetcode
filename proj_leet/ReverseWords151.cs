using System;
using  System.Text;
using System.Collections.Generic;

//https://leetcode.cn/problems/reverse-words-in-a-string/
//151. 反转字符串中的单词

class ReverseWords151
{
    public string ReverseWords(string s) 
    {
        StringBuilder sb = new StringBuilder();

        int n = s.Length;
        // int left = 0;
        int right = n - 1;
        while (right >= 0)
        {
            while(right >= 0 &&s[right] == ' ') {
                right--;
            }

            int len = 0;
            while(right >= 0 && s[right] != ' ') {
                len++;
                right--;
            }

           
            sb.Append(s.Substring(right+1, len));
            sb.Append(' ');
        }

        int end = sb.Length-1;
        while(end >= 0 && sb[end] == ' ') {
            sb.Remove(end, 1);
            end--;
        }
        return sb.ToString();
    }
    
    static void Main(string[] args)
    {
        ReverseWords151 instance = new ReverseWords151();
        string s = "  hello world  ";
    
        string res = instance.ReverseWords(s);
        Console.WriteLine("151. 反转字符串中的单词:{0}++++", res);
    }
}        

