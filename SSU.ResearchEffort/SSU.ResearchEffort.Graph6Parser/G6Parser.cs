using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ResearchEffort.Graph6Parser
{
    public class SmallG6Parser
    {
        private static byte[] powersOfTwo = { 32, 16, 8, 4, 2, 1 };
        public static SortedSet<int> GetDegreeSetByG6(string g6, int n)
        {
            var set = new int[n];
            byte[] asciiBytes = Encoding.ASCII.GetBytes(g6);
            if (asciiBytes[0] - 63 != n)
            {
                throw new ArgumentException("Incorrect count of verticles");
            }

            for (int i = 0; i < asciiBytes.Length; i++)
            {
                asciiBytes[i] -= 63;
            }

            int x = 1;
            int y = 0;

            for (int i = 1; i < asciiBytes.Length; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    bool isOne = (asciiBytes[i] & powersOfTwo[j]) > 0;
                    if (isOne)
                    {
                        set[x]++;
                        set[y]++;
                    }
                    y++;
                    if (y >= x)
                    {
                        x++;
                        y = 0;
                    }

                    if (x == n)
                    {
                        break;
                    }
                }
            }
            
            return new SortedSet<int>(set);
        }
    }
}
