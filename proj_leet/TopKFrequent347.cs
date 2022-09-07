using System;
using System.Collections.Generic;
using System.Linq;

class TopKFrequent347
{
    public int[] TopKFrequent(int[] nums, int k) 
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (!dict.ContainsKey(num)) {
                dict.Add(num, 1);
            } else {
                dict[num]++;
            }
        }

        var list = dict.ToList();
        list.Sort((a, b)=>{
            return b.Value - a.Value;
        });

        var res = new List<int>();
        if (list.Count >= k) {
            for (int i = 0; i < k; i++)
            {
                res.Add(list[i].Key);
            }
        }

        return res.ToArray();
    }
    

    // static void Main(string[] args)
    // {
    //     var nums = {1,1,1,2,2,3};
    //     var k = 2;
    //     var instance = new TopKFrequent347();
    //     Console.WriteLine("TopKFrequent: {0}", String.Join(",", instance.TopKFrequent(nums, k)) );
        
    // }
}