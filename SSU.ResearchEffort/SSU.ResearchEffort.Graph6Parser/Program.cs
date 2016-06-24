using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ResearchEffort.Graph6Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string g6 = Console.ReadLine();
            var ans = SmallG6Parser.GetDegreeSetByG6(g6, n);
            foreach(var degree in ans)
            {
                Console.Write($"{degree} ");
            }
        }
    }
}
