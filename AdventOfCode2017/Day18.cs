using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    class Day18
    {
        public static void Run()
        {
            // Read Input File
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\\Day18.txt");

            Part1(lines);
            Part2(lines);
        }

        private static Dictionary<string, long> register = new Dictionary<string, long>();
        private static void Part1(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;


            long lastPlayedSound = 0;

            // Build register
            foreach (string s in input)
            {
                string[] split = s.Split(' ');

                if (!register.ContainsKey(split[1]))
                {
                    var isNumeric = int.TryParse(split[1], out int n);

                    if (!isNumeric)
                        register.Add(split[1], 0);
                }
            }

            for (long i = 0; i < input.Count(); i++)
            {
                if (input[i].StartsWith("snd"))
                {
                    lastPlayedSound = Sound(input[i]);
                }
                else if (input[i].StartsWith("set"))
                {
                    Set(input[i], ref register);
                }
                else if (input[i].StartsWith("add"))
                {
                    Add(input[i], ref register);
                }
                else if (input[i].StartsWith("mul"))
                {
                    Multiply(input[i], ref register);
                }
                else if (input[i].StartsWith("mod"))
                {
                    Modulus(input[i], ref register);
                }
                else if (input[i].StartsWith("rcv"))
                {

                    if (Recover(input[i]))
                    {
                        Console.WriteLine("1st Recovered Value: " + lastPlayedSound);
                        i = input.Count();
                    }
                }
                else if (input[i].StartsWith("jgz"))
                {
                    i = Jump(input[i], i, ref register);
                }
                else
                    Console.WriteLine("Error: Unknown Command");
            }


        }
        private static Dictionary<string, long> registerA = new Dictionary<string, long>();
        private static Dictionary<string, long> registerB = new Dictionary<string, long>();
        private static void Part2(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            // Create the two registers
            foreach (string s in input)
            {
                string[] split = s.Split(' ');

                if (!registerA.ContainsKey(split[1]))
                {
                    var isNumeric = int.TryParse(split[1], out int n);

                    if (!isNumeric)
                    {
                        registerA.Add(split[1], 0);
                        registerB.Add(split[1], 0);
                    }
                }
            }

            // Queues
            List<long> aQueue = new List<long>();
            List<long> bQueue = new List<long>();

            // Set program value of register B
            registerB["p"] = 1;

            // Processing position values
            long aPosition = 0;
            long bPosition = 0;

            // Booleans to track if waiting for value or not
            bool aWaiting = false;
            bool bWaiting = false;

            // Other vars
            int bSendCount = 0;
            bool finished = false;

            do
            {
                // Process A
                for (long i = aPosition; i < input.Count(); i++)
                {
                    if (input[i].StartsWith("snd"))
                    {
                        Send(input[i], ref registerA, ref bQueue);
                       
                    }
                    else if (input[i].StartsWith("set"))
                    {
                        Set(input[i], ref registerA);
                    }
                    else if (input[i].StartsWith("add"))
                    {
                        Add(input[i], ref registerA);
                    }
                    else if (input[i].StartsWith("mul"))
                    {
                        Multiply(input[i], ref registerA);
                    }
                    else if (input[i].StartsWith("mod"))
                    {
                        Modulus(input[i], ref registerA);
                    }
                    else if (input[i].StartsWith("rcv"))
                    {
                        aWaiting = Receive(input[i], ref registerA, ref aQueue);
                        if (aWaiting)
                        {
                            // Readjust position
                            aPosition = i;
                            break;
                        }
                    }
                    else if (input[i].StartsWith("jgz"))
                    {
                        i = Jump(input[i], i, ref registerA);
                    }
                    else
                        Console.WriteLine("Error: Unknown Command");

                    aPosition = i;
                    
                }

                // Process B
                for (long i = bPosition; i < input.Count(); i++)
                {
                    if (input[i].StartsWith("snd"))
                    {
                        Send(input[i], ref registerB, ref aQueue);
                        bSendCount++;
                    }
                    else if (input[i].StartsWith("set"))
                    {
                        Set(input[i], ref registerB);
                    }
                    else if (input[i].StartsWith("add"))
                    {
                        Add(input[i], ref registerB);
                    }
                    else if (input[i].StartsWith("mul"))
                    {
                        Multiply(input[i], ref registerB);
                    }
                    else if (input[i].StartsWith("mod"))
                    {
                        Modulus(input[i], ref registerB);
                    }
                    else if (input[i].StartsWith("rcv"))
                    {
                        bWaiting = Receive(input[i], ref registerB, ref bQueue);
                        if (bWaiting)
                        {
                            // Readjust position
                            bPosition = i;
                            break;
                        }
                    }
                    else if (input[i].StartsWith("jgz"))
                    {
                        i = Jump(input[i], i, ref registerB);
                    }
                    else
                        Console.WriteLine("Error: Unknown Command");

                    bPosition = i;

                }


            }
            while (((bWaiting && bQueue.Count != 0) || (aWaiting && aQueue.Count != 0)) || (aPosition == input.Count() && bPosition == input.Count()));

            Console.WriteLine("Number of Sends: " + bSendCount);
        }


        private static long Sound(string input)
        {
            // Split instructions
            string[] split = input.Split(' ');

            // If value is in the register then returns it stored int
            if (register.ContainsKey(split[1]))
                return register[split[1]];
            else
                return Convert.ToInt32(split[1]); // else simply return the int value

        }

        private static void Set(string input, ref Dictionary<string, long> reg)
        {
            // Split instructions
            string[] split = input.Split(' ');


            if (reg.ContainsKey(split[2]))
                reg[split[1]] = reg[split[2]];
            else
                reg[split[1]] = Convert.ToInt32(split[2]);
        }

        private static void Add(string input, ref Dictionary<string, long> reg)
        {
            // Split instructions
            string[] split = input.Split(' ');


            if (reg.ContainsKey(split[2]))
                reg[split[1]] += reg[split[2]];
            else
                reg[split[1]] += Convert.ToInt32(split[2]);
        }

        private static void Multiply(string input, ref Dictionary<string, long> reg)
        {
            // Split instructions
            string[] split = input.Split(' ');


            if (reg.ContainsKey(split[2]))
                reg[split[1]] *= reg[split[2]];
            else
                reg[split[1]] *= Convert.ToInt32(split[2]);
        }

        private static void Modulus(string input, ref Dictionary<string, long> reg)
        {
            // Split instructions
            string[] split = input.Split(' ');


            if (reg.ContainsKey(split[2]))
                reg[split[1]] = reg[split[1]] % reg[split[2]];
            else
                reg[split[1]] = reg[split[1]] % Convert.ToInt32(split[2]);
        }
        private static bool Recover(string input)
        {
            // Split instructions
            string[] split = input.Split(' ');


            if (register.ContainsKey(split[1]))
            {
                if (register[split[1]] != 0)
                    return true;
                else
                    return false;
            }
            else
            {
                if (Convert.ToInt32(split[1]) != 0)
                    return true;
                else
                    return false;
            }
        }

        private static long Jump(string input, long i, ref Dictionary<string, long> reg)
        {
            // Split instructions
            string[] split = input.Split(' ');

            long x;
            long y;

            if (reg.ContainsKey(split[1]))
                x = reg[split[1]];
            else
                x = Convert.ToInt32(split[1]);

            if (reg.ContainsKey(split[2]))
                y = reg[split[2]];
            else
                y = Convert.ToInt32(split[2]);



            if (x > 0)
            {
                y--;

                return i += y;
            }
            else
                return i;
        }

        private static void Send(string input, ref Dictionary<string, long> reg, ref List<long> queue)
        {
            // Split instructions
            string[] split = input.Split(' ');


            if (reg.ContainsKey(split[1]))
                queue.Add(reg[split[1]]);
            else
                queue.Add(Convert.ToInt32(split[1]));
        }

        private static bool Receive(string input, ref Dictionary<string, long> reg, ref List<long> queue)
        {
            // Split instructions
            string[] split = input.Split(' ');

            if (queue.Count > 0)
            {
                reg[split[1]] = queue.First();
                queue.Remove(queue.First());

                return false;
            }
            else
                return true;

        }
    }
}
