using System;
using System.Collections.Generic;

class FindOrder210
{
    public int[] FindOrder(int numCourses, int[][] prerequisites) 
    {
        int[] indegree = new int[numCourses];
        Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

        for (int i = 0; i < prerequisites.Length; i++)
        {
            int[] item = prerequisites[i];
            indegree[item[0]]++;
            if (!dic.ContainsKey(item[1]))
            {
                dic.Add(item[1], new List<int>());
            } 

            dic[item[1]].Add(item[0]);
        }


        int count = 0;
        List<int> res = new List<int>();
        for (int i = 0; i < numCourses; i++)
        {
            int course = -1;
            for (int j = 0; j < indegree.Length; j++)
            {
                if (indegree[j] == 0) {
                    indegree[j] = -1;
                    course = j;
                    res.Add(course);
                    break;
                }
            } 

            if (course == -1)
                return new int[0];

            if (dic.ContainsKey(course))
            {
                List<int> l = dic[course];
                foreach (var item in l)
                {
                    indegree[item]--;
                }
            }
            count++;
            if (count == numCourses) {
                return res.ToArray();
            }

        }
        return res.ToArray();
    }

    // static void Main(string[] args)
    // {
    //     // int numCourses = 4;
    //     // int[][] prerequisites = new int[][]{new int[]{1,0},new int[]{2,0},new int[]{3,1},new int[]{3,2}};

    //     int numCourses = 1;
    //     int[][] prerequisites = new int[][]{};
    //     var instance = new FindOrder210();
    //     Console.WriteLine("FindOrder210: {0}", string.Join(",", instance.FindOrder(numCourses, prerequisites)) );
        
    // }
}