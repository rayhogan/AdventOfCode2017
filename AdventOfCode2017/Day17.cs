using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    class Day17
    {

        public static void Run()
        {
            int input = 337;
            Part1(input);
            Part2(input);
        }

        private static void Part1(int input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            List<int> spinlock = new List<int>();
            int currentPosition = 0;
            int currentCounter = 0;

            spinlock.Add(currentPosition);

            currentCounter++;

            do
            {
                currentPosition = GetNextIndex(currentPosition, spinlock.Count, input);
                if ((currentPosition + 1) >= spinlock.Count)
                    spinlock.Add(currentCounter);
                else
                    spinlock.Insert((currentPosition + 1), currentCounter);

                currentCounter++;
                currentPosition++;

            }
            while (currentCounter <= 2017);

            Console.WriteLine("Value: " + spinlock[currentPosition + 1]);


        }

        private static void Part2(int input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            int currentPosition = 1;
            int currentCounter = 2;
            int size = 2;
            int valueNextTo0 = 1;

            do
            {
                currentPosition = GetNextIndex(currentPosition, size, input);

                if (currentPosition == 0)
                    valueNextTo0 = currentCounter;

                currentCounter++;
                currentPosition++;
                size++;


            }
            while (currentCounter <= 50000000);

            Console.WriteLine("Value: " + valueNextTo0);
        }

        private static int GetNextIndex(int currentIndex, int currentSize, int steps)
        {        
            currentIndex += (steps % currentSize);

            if (currentIndex >= currentSize)
                currentIndex -= currentSize;
            
            return currentIndex;
        }
    }
}
