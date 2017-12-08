using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2017
{
    class Day5
    {
        public static void Day5_Output()
        {

            string[] file = File.ReadAllLines("C:\\Users\\belterius\\Desktop\\AdventOfCodeDay5.txt");

            Console.WriteLine($"Part One :");
            Console.WriteLine($"Number of jump to exit : {Day5_TwistyTrampolines_PartOne(file)}");
            Console.WriteLine($"Part Two :");
            Console.WriteLine($"Number of jump to exit : {Day5_TwistyTrampolines_PartTwo(file)}");
            Console.Read();
        }

        public static int Day5_TwistyTrampolines_PartOne(string[] file)
        {
            int jump = 0;
            int currentIndex = 0;
            int[] MyMaze = file.Select(s => int.Parse(s)).ToArray();

            try
            {
                while (true)
                {
                    MyMaze[currentIndex]++;
                    currentIndex = currentIndex + MyMaze[currentIndex] - 1;
                    jump++;
                }
            }
            catch (Exception ex)
            {

                return jump;
            }
        }

        public static int Day5_TwistyTrampolines_PartTwo(string[] file)
        {
            int jump = 0;
            int currentIndex = 0;
            int[] MyMaze = file.Select(s => int.Parse(s)).ToArray();

            try
            {
                while (true)
                {
                    if (MyMaze[currentIndex] > 3)
                        MyMaze[currentIndex]--;
                    else
                        MyMaze[currentIndex]++;
                    currentIndex = currentIndex + MyMaze[currentIndex] - 1;
                    jump++;
                }
            }
            catch (Exception ex)
            {

                return jump;
            }
        }
    }
}
