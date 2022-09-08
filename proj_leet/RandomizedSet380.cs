using System;
using System.Collections.Generic;
using System.Linq;

class RandomizedSet380
{
    List<int> list;
    Dictionary<int, int> indexDict;
    Random rd;
    public RandomizedSet380() {
        list = new List<int>();
        indexDict = new Dictionary<int, int>();
        rd = new Random();
    }
    
    public bool Insert(int val) {
        if (indexDict.ContainsKey(val)) {
            return false;
        }

        list.Add(val);
        indexDict.Add(val, list.Count-1);
        return true;
    }
    
    public bool Remove(int val) {
        if (!indexDict.ContainsKey(val)) {
            return false;
        }

        int idx = indexDict[val];
        list[idx] = list.Last();
        
        indexDict[list[idx]] = idx;
        
        list.RemoveAt(list.Count - 1);
        indexDict.Remove(val);
        return true;
    }
    
    public int GetRandom() {
        int idx = rd.Next(list.Count);
        return list[idx];
    }

    static void Main(string[] args)
    {
        RandomizedSet380 randomizedSet = new RandomizedSet380();
        Console.WriteLine(randomizedSet.Insert(1)); // 向集合中插入 1 。返回 true 表示 1 被成功地插入。
        Console.WriteLine(randomizedSet.Remove(2)); // 返回 false ，表示集合中不存在 2 。
        Console.WriteLine(randomizedSet.Insert(2)); // 向集合中插入 2 。返回 true 。集合现在包含 [1,2] 。
        Console.WriteLine(randomizedSet.GetRandom()); // getRandom 应随机返回 1 或 2 。
        Console.WriteLine(randomizedSet.Remove(1)); // 从集合中移除 1 ，返回 true 。集合现在包含 [2] 。
        Console.WriteLine(randomizedSet.Insert(2)); // 2 已在集合中，所以返回 false 。
        Console.WriteLine(randomizedSet.GetRandom()); // 由于 2 是集合中唯一的数字，getRandom 总是返回 2 。
        
    }
}