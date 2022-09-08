using System;
using System.Collections.Generic;
using System.Linq;
//leetcode  https://leetcode.cn/problems/flatten-nested-list-iterator/?favorite=2ckc81c
/* interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
class NestedIterator
{
    IList<NestedInteger> list;
    NestedIterator iterator;
    int curIdx = -1;
    public NestedIterator(IList<NestedInteger> nestedList) {
        list = nestedList;
        curIdx = 0;
    }

    public bool HasNext() {
        if (iterator != null) {
            if (iterator.HasNext())
                return true;
        }

        while(curIdx < list.Count) {
            NestedInteger nested = list[curIdx];
            if (nested.IsInteger()) {
                return true;
            } else {
                iterator = new NestedIterator(nested.GetList());
                if (iterator.HasNext())
                    return true;
            }
            curIdx++;
        }
        
        return false;
    }

    public int Next() {
        if (iterator != null) {
            return iterator.Next();
        }

        NestedInteger nest = list[curIdx];
        if (nest.IsInteger()) {
            curIdx++;
            return nest.GetInteger();
        }
        return 0;
    }

    static void Main(string[] args)
    {
        NestedIterator randomizedSet = new NestedIterator();
        Console.WriteLine(randomizedSet.Insert(1)); // 向集合中插入 1 。返回 true 表示 1 被成功地插入。
        Console.WriteLine(randomizedSet.Remove(2)); // 返回 false ，表示集合中不存在 2 。
        Console.WriteLine(randomizedSet.Insert(2)); // 向集合中插入 2 。返回 true 。集合现在包含 [1,2] 。
        Console.WriteLine(randomizedSet.GetRandom()); // getRandom 应随机返回 1 或 2 。
        Console.WriteLine(randomizedSet.Remove(1)); // 从集合中移除 1 ，返回 true 。集合现在包含 [2] 。
        Console.WriteLine(randomizedSet.Insert(2)); // 2 已在集合中，所以返回 false 。
        Console.WriteLine(randomizedSet.GetRandom()); // 由于 2 是集合中唯一的数字，getRandom 总是返回 2 。
        
    }
}