using System;
using System.Collections.Generic;
using System.Linq;
namespace LC
{
    //134. 加油站
    //https://leetcode.cn/problems/gas-station/
    class CanCompleteCircuit134
    {
        public int CanCompleteCircuit(int[] gas, int[] cost) 
        {
            int N = gas.Length;
            for (int i = 0; i < N;)
            {
                int count = 0;
                int gasAll = 0;
                int costAll = 0;
                int j = i;
                while (count < N)
                {
                    
                    j = j % N;
                    // Console.WriteLine("i: {0}, j:{1}, count:{2}", i, j, count);
                    gasAll += gas[j];
                    costAll += cost[j];
                    if (gasAll < costAll) {
                        break;
                    }
                    count++;
                    j++;
                }
                if (count == N) 
                {
                    return i;
                } else 
                {
                    i = i + count + 1;
                }
            }

            return -1;
        }

        static void Main(string[] args)
        {
            CanCompleteCircuit134 instance = new CanCompleteCircuit134();
            int[] gas = new int[]{1,2,3,4,5};
            int[] cost = new int[]{3,4,5,1,2};
           
            Console.WriteLine("开始加油站:{0}", instance.CanCompleteCircuit(gas, cost));
        
        }
    }
}
