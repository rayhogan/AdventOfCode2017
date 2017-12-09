using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    class Day3
    {
        public static void Run()
        {
            Part1(347991);
            Part2(347991);
        }

        private static void Part1(int value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;


            Tuple<int, int> cordinates = FindCoordinates(value);
            Console.WriteLine("Moves Required: " + Math.Abs(CalculatePath(0, 0, cordinates.Item1, cordinates.Item2)));

        }

        private static void Part2(int value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Largest Sum: " + SumCoordinates(value));
        }

        private static int SumCoordinates(int value)
        {
            // Create list of tuples
            Dictionary<Tuple<int, int>, int> coOrdinates = new Dictionary<Tuple<int, int>, int>();

            // Add in starting co-ordinate
            coOrdinates.Add(new Tuple<int, int>(0, 0), 1);

            // Track current position
            int xPos = 0;
            int yPos = 0;

            // Last sum
            int lastSum = 0;
            //What direction are we going in? 
            // 0 = right
            // 1 = up
            // 2 = left
            // 3 = down
            int currentDirection = 0;

            // Loop through
            while (lastSum < value)
            {
                Tuple<int, int> newEntry = new Tuple<int, int>(xPos, yPos);

                if (currentDirection == 0) // Right
                {

                    newEntry = new Tuple<int, int>(xPos, yPos + 1);

                    bool denied = false;


                    if (coOrdinates.ContainsKey(newEntry))
                    {
                        xPos--;
                        newEntry = new Tuple<int, int>(xPos, yPos);
                        denied = true;
                    }
                    else
                    {
                        yPos++;
                    }

                    lastSum = AttemptCalucation(xPos, yPos, coOrdinates);
                    coOrdinates.Add(newEntry, lastSum);

                    if (!denied)
                        currentDirection++;

                }
                else if (currentDirection == 1) // Up
                {
                    newEntry = new Tuple<int, int>(xPos + 1, yPos);
                    bool denied = false;


                    if (coOrdinates.ContainsKey(newEntry))
                    {
                        yPos++;
                        newEntry = new Tuple<int, int>(xPos, yPos);
                        denied = true;
                    }
                    else
                    {
                        xPos++;
                    }

                    lastSum = AttemptCalucation(xPos, yPos, coOrdinates);
                    coOrdinates.Add(newEntry, lastSum);

                    if (!denied)
                        currentDirection++;
                }
                else if (currentDirection == 2) // Left
                {
                    newEntry = new Tuple<int, int>(xPos, yPos - 1);
                    bool denied = false;


                    if (coOrdinates.ContainsKey(newEntry))
                    {
                        xPos++;
                        newEntry = new Tuple<int, int>(xPos, yPos);
                        denied = true;
                    }
                    else
                    {
                        yPos--;
                    }

                    lastSum = AttemptCalucation(xPos, yPos, coOrdinates);
                    coOrdinates.Add(newEntry, lastSum);

                    if (!denied)
                        currentDirection++;
                }
                else if (currentDirection == 3) // Down
                {
                    newEntry = new Tuple<int, int>(xPos - 1, yPos);
                    bool denied = false;

                    if (coOrdinates.ContainsKey(newEntry))
                    {
                        yPos--;
                        newEntry = new Tuple<int, int>(xPos, yPos);
                        denied = true;
                    }
                    else
                    {
                        xPos--;
                    }

                    lastSum = AttemptCalucation(xPos, yPos, coOrdinates);
                    coOrdinates.Add(newEntry, lastSum);

                    if (!denied)
                        currentDirection = 0;
                }

            }

            return lastSum;

        }

        private static int AttemptCalucation(int x, int y, Dictionary<Tuple<int, int>, int> list)
        {
            int sum = 0;

            try { sum += list[new Tuple<int, int>(x + 1, y)]; } catch (Exception ex) { }
            try { sum += list[new Tuple<int, int>(x - 1, y)]; } catch (Exception ex) { }
            try { sum += list[new Tuple<int, int>(x, y - 1)]; } catch (Exception ex) { }
            try { sum += list[new Tuple<int, int>(x, y + 1)]; } catch (Exception ex) { }
            try { sum += list[new Tuple<int, int>(x - 1, y - 1)]; } catch (Exception ex) { }
            try { sum += list[new Tuple<int, int>(x - 1, y + 1)]; } catch (Exception ex) { }
            try { sum += list[new Tuple<int, int>(x + 1, y + 1)]; } catch (Exception ex) { }
            try { sum += list[new Tuple<int, int>(x + 1, y - 1)]; } catch (Exception ex) { }

            return sum;
        }

        private static Tuple<int, int> FindCoordinates(int value)
        {
            // Track current position
            int xPos = 0;
            int yPos = 0;

            //WHat direction are we going in? 
            // 0 = right
            // 1 = up
            // 2 = left
            // 3 = down
            int currentDirection = 0;
            int width = 0;
            int moves = 1;

            // Loop through
            for (int i = 0; i < value; i++)
            {


                if (currentDirection == 0) // Right
                {
                    width++;
                    yPos += width;

                    currentDirection++;

                }
                else if (currentDirection == 1) // Up
                {
                    xPos += width;
                    currentDirection++;
                }
                else if (currentDirection == 2) // Left
                {
                    width++;
                    yPos -= width;
                    currentDirection++;
                }
                else if (currentDirection == 3) // Down
                {
                    xPos -= width;

                    currentDirection = 0;
                }

                moves += width;
                i += width;
                i--;


            }

            if ((currentDirection - 1) <= 0)
            {
                yPos -= (moves - value);
            }
            else if ((currentDirection - 1) == 1)
            {
                xPos -= (moves - value);
            }
            else if ((currentDirection - 1) == 2)
            {
                yPos += (moves - value);
            }
            else if ((currentDirection - 1) == 3)
            {
                xPos += (moves - value);
            }
            return new Tuple<int, int>(xPos, yPos);
        }

        private static int CalculatePath(int p1, int p2, int q1, int q2)
        {
            return (p1 - Math.Abs(q1)) + (p2 - Math.Abs(q2));
        }
    }
}
