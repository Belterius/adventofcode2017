using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2017
{
    class Day2
    {
        public static void Day2_Output()
        {
            Console.WriteLine($"Part One :");
            Console.WriteLine($"Sum of my spreadsheet : {Day2_CorruptionChecksum_PartOne("C:\\Users\\loic\\Desktop\\adventDay2.txt")}");
            Console.WriteLine($"Part Two :");
            Console.WriteLine($"Sum of my spreadsheet : {Day2_CorruptionChecksum_PartTwo("C:\\Users\\loic\\Desktop\\adventDay2.txt")}");
            Console.Read();
        }

        public static int Day2_CorruptionChecksum_PartOne(string path)
        {
            int checksum = 0;

            string[] file = File.ReadAllLines(path);
            var lines = file.Select(line => line.Split('\t'));
            var linesValue = lines.Select(line => line.Select(x => int.Parse(x)));
            var lineSum = linesValue.Select(line => line.Max() - line.Min());

            return lineSum.Sum();
        }
        public static int Day2_CorruptionChecksum_PartTwo(string path)
        {
            int checksum = 0;

            string[] file = File.ReadAllLines(path);
            var lines = file.Select(line => line.Split('\t'));
            var linesValue = lines.Select(line => line.Select(x => int.Parse(x)));
            return Day2_EvenlyDivise(linesValue.Select(line => line.ToArray()));
        }

        private static int Day2_EvenlyDivise(IEnumerable<int[]> enumerable)
        {
            int correctResult = 0;

            foreach (int[] i in enumerable)
            {
                foreach (int value in i)
                {
                    foreach (int valueCompare in i)
                    {
                        int resultDiv = divisibleValue(value, valueCompare);
                        if (resultDiv > 1)
                        {
                            correctResult += resultDiv;
                            break;
                        }
                    }
                }
            }


            return correctResult;
        }

        private static int divisibleValue(int a, int b)
        {
            if (a > b)
            {
                if (a % b == 0)
                {
                    return a / b;
                }
            }
            if (b < a)
            {
                if (b % a == 0)
                {
                    return b / a;
                }
            }
            return 0;
        }

    }
}
