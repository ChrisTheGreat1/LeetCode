using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given a characters array tasks, representing the tasks a CPU needs to do, where each letter represents a different task. 
    Tasks could be done in any order. Each task is done in one unit of time. For each unit of time, 
    the CPU could complete either one task or just be idle.

    However, there is a non-negative integer n that represents the cooldown period between two same tasks 
    (the same letter in the array), that is that there must be at least n units of time between any two same tasks.

    Return the least number of units of times that the CPU will take to finish all the given tasks.

    Input: tasks = ["A","A","A","B","B","B"], n = 2
    Output: 8
    Explanation: 
    A -> B -> idle -> A -> B -> idle -> A -> B
    There is at least 2 units of time between any two same tasks.

    Input: tasks = ["A","A","A","B","B","B"], n = 0
    Output: 6
    Explanation: On this case any permutation of size 6 would work since n = 0.
    ["A","A","A","B","B","B"]
    ["A","B","A","B","A","B"]
    ["B","B","B","A","A","A"]
    ...
    And so on.

    Input: tasks = ["A","A","A","A","A","A","B","C","D","E","F","G"], n = 2
    Output: 16
    Explanation: 
    One possible solution is
    A -> B -> C -> A -> D -> E -> A -> F -> G -> A -> idle -> idle -> A -> idle -> idle -> A
 
    Constraints:

    1 <= task.length <= 10^4
    tasks[i] is upper-case English letter.
    The integer n is in the range [0, 100].

    */



    internal class _0621_TaskScheduler
    {
        // Use priority queue so that the most frequent letter is processed first.
        // Then use a queue to keep track of when that character can be processed again,
        // so that you can always maximize your time spent processing other letters

        private PriorityQueue<FreqClass, int> pq;
        private Dictionary<char, int> dictionary;

        public int LeastInterval(char[] tasks, int n)
        {
            // Count tasks in the array
            if (n == 0) return tasks.Length;

            dictionary = new Dictionary<char, int>();

            // Count frequency of each letter
            foreach (var task in tasks)
            {
                if (dictionary.ContainsKey(task))
                {
                    dictionary[task]++;
                }
                else dictionary.Add(task, 1);
            }

            pq = new PriorityQueue<FreqClass, int>(new MaxHeap());

            var time = 0;

            AddItemsToPQ();

            while (pq.Count > 0)
            {
                var list = new List<FreqClass>();
                var cnt = 0;
                for (var i = 0; i < n + 1; i++)
                {
                    if (pq.Count > 0)
                    {
                        var item = pq.Dequeue(); // Get most frequent item
                        cnt++;
                        //Console.WriteLine($"Dequeued {item.Task} with frequency : {item.Frequency}");
                        item.Frequency--;
                        if (item.Frequency > 0)
                            list.Add(item);
                    }
                }

                for (var i = 0; i < list.Count; i++)
                {
                    var item = list[i];
                    //Console.WriteLine($"Enqueued {item.Task} with frequency : {item.Frequency}");
                    pq.Enqueue(item, item.Frequency);
                }

                if (pq.Count == 0)
                {
                    time += cnt;
                }
                else
                {
                    time += n + 1;
                }

                //Console.WriteLine($"Done with iteration, current time: {time}");
            }

            return time;
        }

        private void AddItemsToPQ()
        {
            foreach (var keyValuePair in dictionary)
            {
                pq.Enqueue(new FreqClass(keyValuePair.Value, 0, keyValuePair.Key), keyValuePair.Value);
            }
        }

        private class MaxHeap : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y - x;
            }
        }

        private class FreqClass
        {
            public int Frequency;
            public int IdleTime;
            public char Task;

            public FreqClass(int frequency, int idleTime, char task)
            {
                Frequency = frequency;
                IdleTime = idleTime;
                Task = task;
            }
        }
    }
}
