using System;
using System.Collections.Generic;
using System.Linq;
namespace LC
{
    //204. 计数质数
    //https://leetcode.cn/problems/count-primes/?favorite=2ckc81c
    class CountPrimes204
    {
        // public int CountPrimes(int n) 
        // {
        //     int ans = 0;
        //     for (int i = 2; i < n; i++)
        //     {
        //         if (isPrime(i))
        //             ans++;
        //     }
        //     return ans;
        // }

        // public bool isPrime(int n)
        // {
        //     for (int i = 2; i*i <= n; i++)
        //     {
        //         if (n%i == 0)
        //             return false;
        //     }
        //     return true;
        // }

        public int CountPrimes(int n) 
        {
            bool[] isPrime = new bool[n];
            Array.Fill(isPrime, true);
            int ans = 0;
            for (int i = 2; i*i < n; i++)
            {
                if (isPrime[i]){
                    for (int j = i*i; j < n; j+=i)
                    {
                        //Console.WriteLine("j:{0}", j);
                        isPrime[j] = false;
                    }
                }            
            }
            
            for (int i = 2; i < n; i++)
            {
                if (isPrime[i])
                    ans++;
            }
            return ans;
        }

        // static void Main(string[] args)
        // {
        //     CountPrimes204 instance = new CountPrimes204();
        //     int s = 499979;
           
        //     Console.WriteLine("204. 计数质数: {0}", instance.CountPrimes(s));
        
        // }
    }
}
