using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2017
{
    class Day3
    {
        public static void Day3_Output()
        {
            Console.WriteLine($"Part One :");
            Console.WriteLine($"Distance for 12 : {Day3_SpiralMemory_PartOne(12)}");
            Console.WriteLine($"Distance for 23 : {Day3_SpiralMemory_PartOne(23)}");
            Console.WriteLine($"Distance for 49 : {Day3_SpiralMemory_PartOne(49)}");
            Console.WriteLine($"Distance for 53 : {Day3_SpiralMemory_PartOne(53)}");
            Console.WriteLine($"Distance for 1024 : {Day3_SpiralMemory_PartOne(1024)}");
            Console.WriteLine($"Distance for 312051 : {Day3_SpiralMemory_PartOne(312051)}"); 
            Console.WriteLine($"Part Two :");
            Console.WriteLine($"Next value for 28 : {Day3_SpiralMemory_PartTwo(28)}");
            Console.WriteLine($"Next value for 130 : {Day3_SpiralMemory_PartTwo(130)}");
            Console.WriteLine($"Next value for 355 : {Day3_SpiralMemory_PartTwo(355)}");
            Console.WriteLine($"Next value for 747 : {Day3_SpiralMemory_PartTwo(747)}");
            Console.WriteLine($"Next value for 312051 : {Day3_SpiralMemory_PartTwo(312051)}");
            Console.Read();
        }
        public static int Day3_SpiralMemory_PartOne(int puzzleInput)
        {
            float PuzzleInput = puzzleInput - 1;
            int Sector = Day3_FindSector(puzzleInput);
            int StartOfSector = 0;
            for(int i =0;i<Sector; i++)
            {
                StartOfSector += i * 8;
            }
            StartOfSector += Sector + 1;
            int distance = (puzzleInput - StartOfSector) % (Sector * 2);
            if(distance > Sector)
            {
                distance = Sector * 2 - distance;
            }

            return Math.Abs(distance) + Sector;
        }
        public static int Day3_FindSector(int puzzleInput)
        {
            float PuzzleInput = puzzleInput - 1;
            int Sector = 1;
            while (PuzzleInput / (8 * Sector) > 1)
            {
                PuzzleInput = PuzzleInput - (8 * Sector);
                Sector++;
                float testor = PuzzleInput / (8 * Sector);
            }
            return Sector;
        }

        public static int Day3_SpiralMemory_PartTwo(int puzzleInput)
        {
            int Size =(1 + Day3_FindSector(puzzleInput))*2 + 1;
            int[,] MyValues = new int[Size, Size];
            int currentValue = 1;
            int iteration = 1;
            int X_Position = Size / 2 + 1;
            int Y_Position = Size / 2 + 1;
            MyValues[X_Position, Y_Position] = 1;
            while (currentValue < puzzleInput)
            {
                for(int i = 0; i < iteration*2-1; i++)
                {
                    X_Position++;
                    MyValues[X_Position, Y_Position] = MyValues[X_Position - 1, Y_Position + 1] + MyValues[X_Position, Y_Position + 1] + MyValues[X_Position + 1, Y_Position + 1]
                        + MyValues[X_Position - 1, Y_Position] + MyValues[X_Position + 1, Y_Position]
                        + MyValues[X_Position - 1, Y_Position - 1] + MyValues[X_Position, Y_Position - 1] + MyValues[X_Position +1, Y_Position - 1];
                    currentValue = MyValues[X_Position, Y_Position];
                    if (currentValue >= puzzleInput)
                    {
                        break;
                    }
                }
                if (currentValue >= puzzleInput)
                {
                    break;
                }
                for (int i = 0; i < iteration*2-1; i++)
                {
                    Y_Position++;
                    MyValues[X_Position, Y_Position] = MyValues[X_Position - 1, Y_Position + 1] + MyValues[X_Position, Y_Position + 1] + MyValues[X_Position + 1, Y_Position + 1]
                        + MyValues[X_Position - 1, Y_Position] + MyValues[X_Position + 1, Y_Position]
                        + MyValues[X_Position - 1, Y_Position - 1] + MyValues[X_Position, Y_Position - 1] + MyValues[X_Position + 1, Y_Position - 1];
                    currentValue = MyValues[X_Position, Y_Position];
                    if (currentValue >= puzzleInput)
                    {
                        break;
                    }
                }
                if (currentValue >= puzzleInput)
                {
                    break;
                }
                for (int i = 0; i < iteration * 2; i++)
                {
                    X_Position--;
                    MyValues[X_Position, Y_Position] = MyValues[X_Position - 1, Y_Position + 1] + MyValues[X_Position, Y_Position + 1] + MyValues[X_Position + 1, Y_Position + 1]
                        + MyValues[X_Position - 1, Y_Position] + MyValues[X_Position + 1, Y_Position]
                        + MyValues[X_Position - 1, Y_Position - 1] + MyValues[X_Position, Y_Position - 1] + MyValues[X_Position + 1, Y_Position - 1];
                    currentValue = MyValues[X_Position, Y_Position];
                    if (currentValue >= puzzleInput)
                    {
                        break;
                    }
                }
                if (currentValue >= puzzleInput)
                {
                    break;
                }
                for (int i = 0; i < iteration * 2; i++)
                {
                    Y_Position--;
                    MyValues[X_Position, Y_Position] = MyValues[X_Position - 1, Y_Position + 1] + MyValues[X_Position, Y_Position + 1] + MyValues[X_Position + 1, Y_Position + 1]
                        + MyValues[X_Position - 1, Y_Position] + MyValues[X_Position + 1, Y_Position]
                        + MyValues[X_Position - 1, Y_Position - 1] + MyValues[X_Position, Y_Position - 1] + MyValues[X_Position + 1, Y_Position - 1];
                    currentValue = MyValues[X_Position, Y_Position];
                    if (currentValue >= puzzleInput)
                    {
                        break;
                    }
                }
                if (currentValue >= puzzleInput)
                {
                    break;
                }
                iteration++;
            }
            return currentValue;
        }
    }
}
