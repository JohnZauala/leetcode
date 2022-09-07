using System;
using System.Collections.Generic;

class Course207
{
    public bool CanFinish(int numCourses, int[][] prerequisites) 
    {
        int[] indegree = new int[numCourses];

        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

        foreach (int[] item in prerequisites)
        {
            indegree[item[0]]++;
            if (!dict.ContainsKey(item[1])) {
                dict.Add(item[1], new List<int>{item[0]});
            } else
            {
                dict[item[1]].Add(item[0]);
            }
        }

        Queue<int> q = new Queue<int>();
        for (int i = 0; i < numCourses; i++) {
            if (indegree[i] == 0) {
                q.Enqueue(i);
            }
        }

        int count = 0;
        while(q.Count > 0) {
            count++;
            int front = q.Dequeue();
            
            if (dict.ContainsKey(front)) {
                List<int> dep = dict[front];
                foreach (var i in dep)
                {
                    indegree[i]--;
                    if (indegree[i] == 0) {
                        q.Enqueue(i);
                    }
                }
            }
            
        }

        return count == numCourses;
    }
    

    // static void Main(string[] args)
    // {
    //     var numCourses = 2;
    //     var prerequisites = new int[]{{1,0},{0,1}}
    //     var instance = new Course207();
    //     Console.WriteLine("CanFinish: {0}", instance.CanFinish(numCourses, prerequisites));
        
    // }
}