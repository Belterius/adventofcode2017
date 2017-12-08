using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2017
{
    class Day4
    {
        public static void Day4_Output()
        {

            string[] file = File.ReadAllLines("C:\\Users\\belterius\\Desktop\\AdventOfCodeDay4.txt");

            Console.WriteLine($"Part One :");
            Console.WriteLine($"Number of valid passphrase : {Day4_CorruptionPassphrase_PartOne(file)}");
            Console.WriteLine($"Part Two :");
            Console.WriteLine($"Number of valid passphrase : {Day4_CorruptionPassphrase_PartTwo(file)}");
            Console.Read();
        }

        public static int Day4_CorruptionPassphrase_PartOne(string[] file)
        {
            var lines = file.Select(line => line.Split(' '));
            var linesValue = lines.Select(line => line.Count());
            var linesDistinct = lines.Select(line => line.Distinct().Count());
            int ValidPassphrase = 0;
            for(int i=0; i < linesValue.Count(); i++)
            {
                if(linesValue.ElementAt(i) == linesDistinct.ElementAt(i))
                {
                    ValidPassphrase++;
                }
            }
            return ValidPassphrase;
        }
        public static int Day4_CorruptionPassphrase_PartTwo(string[] file)
        {
            var lines = file.Select(i => i.Split(' ').Select(s => String.Concat(s.OrderBy(c => c))).Distinct().Count());
            var linesDistinct = file.Select(i => i.Split(' ').Select(s => String.Concat(s.OrderBy(c => c))).Count());
            int ValidPassphrase = 0;
            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines.ElementAt(i) == linesDistinct.ElementAt(i))
                {
                    ValidPassphrase++;
                }
            }
            return ValidPassphrase;
        }
        
    }
}
