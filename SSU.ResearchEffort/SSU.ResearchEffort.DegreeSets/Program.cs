using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSU.ResearchEffort.Graph6Parser;

namespace SSU.ResearchEffort.DegreeSets
{
    class Program
    {
        class Stastistic
        {
            public long[] Count_of_any_with_order { get; set; }
            public long[] Count_of_FDS_graphs_with_order { get; set; }
            public long[] Min_count_of_verticles_in_graphs_with_max_degree { get; set; }

            public Stastistic(int l)
            {
                Count_of_any_with_order = new long[l];
                Count_of_FDS_graphs_with_order = new long[l];
                Min_count_of_verticles_in_graphs_with_max_degree = new long[l];
            }
        }

        static void Main(string[] args)
        {
            int k = int.Parse(args[0]);
            Stastistic result = new Stastistic(k);
            for(int i = 1; i <= k; i++)
            {
                Console.Write("#");
                StreamReader sr = new StreamReader($"D:\\Univer\\geng\\output{i}");
                while (!sr.EndOfStream)
                {
                    result.Count_of_any_with_order[i- 1]++;
                    var g6 = sr.ReadLine();
                    var set = SmallG6Parser.GetDegreeSetByG6(g6, i);
                    if (set.Max == set.Count)
                    {                        
                        result.Min_count_of_verticles_in_graphs_with_max_degree[set.Max] = 
                            result.Min_count_of_verticles_in_graphs_with_max_degree[set.Max] == 0 ? i : Math.Min(result.Min_count_of_verticles_in_graphs_with_max_degree[set.Max], i);
                        result.Count_of_FDS_graphs_with_order[i - 1]++;
                    }               
                }                 
            }

            Console.WriteLine();
            printStatistic(result);
        }

        private static void printStatistic(Stastistic result)
        {
            Console.WriteLine("№\t\tAll\t\tFull\t\tCountVert");
            for (int i = 0; i < result.Count_of_any_with_order.Length; i++)
            {
                Console.WriteLine($"{i}:\t\t{result.Count_of_any_with_order[i]}\t\t{result.Count_of_FDS_graphs_with_order[i]}\t\t{result.Min_count_of_verticles_in_graphs_with_max_degree[i]}");
            }
        }
    }
}
