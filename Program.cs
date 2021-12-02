using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;

namespace AOC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AOC_01a());
            Console.WriteLine(AOC_01b());
            Console.WriteLine(AOC_02a());
            Console.WriteLine(AOC_02b());
        }

        // DAY 02
        class Instruction
        {
            public string dir = "";
            public int units = 0;

            public Instruction(string d, int u)
            {
                dir = d;
                units = u;
            }
        }

        static long AOC_02b()
        {
            long len =0 , dep = 0, aim = 0;
            foreach (var l in File.ReadLines("data/02.txt")
                .Select(t=>new Instruction(t.Split(' ')[0], int.Parse(t.Split(' ')[1]))))
            {
                if (l.dir == "forward")
                {
                    len += l.units;
                    dep += aim * l.units;
                }
                else if (l.dir == "up")
                    aim -= l.units;
                else if (l.dir == "down")
                    aim += l.units;
            }

            return len * dep;
        }
        
        static long AOC_02a()
        {
            long len =0 , dep = 0;
            foreach (var l in File.ReadLines("data/02.txt")
                .Select(t=>new Instruction(t.Split(' ')[0], int.Parse(t.Split(' ')[1]))))
            {
                if (l.dir == "forward")
                    len += l.units;
                else if (l.dir == "up")
                    dep -= l.units;
                else if (l.dir == "down")
                    dep += l.units;
            }

            return len * dep;
        }

        // DAY 01
        class Counter{
            public int entries = 0;
            public int total = 0;

            public Counter(int e, int t)
            {
                entries = e;
                total = t;
            }
        }
        static int AOC_01b()
        {
            List<Counter> a = new List<Counter>();
            
            int idx = 0;
            foreach (var l in File.ReadLines("data/01.txt"))
            {
                int cur = int.Parse(l);
                a.Add(new Counter(1, cur));
                if (idx > 0 && a[idx - 1].entries < 3)
                {
                    a[idx - 1].entries++;
                    a[idx - 1].total += cur;
                }

                if (idx > 1 && a[idx - 2].entries < 3)
                {
                    a[idx - 2].entries++;
                    a[idx - 2].total += cur;
                }

                idx++;
            }

            return GetDiffCount(a.Select(c=>c.total));
        }

        static int GetDiffCount(IEnumerable<int> nums)
        {
            int res = 0;
            int prev = int.MaxValue;
            int cur;
            foreach (var l in nums)
            {
                cur = l;
                if (cur > prev)
                    res++;

                prev = cur;
            }

            return res;
        }

        static int AOC_01a()
        {
            return GetDiffCount(File.ReadLines("data/01.txt").Select(r=>int.Parse(r)));
        }
    }
}