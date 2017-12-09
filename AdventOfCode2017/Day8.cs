using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    class Day8
    {
        public static void Run()
        {
            // Read Input File
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Inputs\\Day8.txt");

            Part1AndTwo(lines);
        }

        private static void Part1AndTwo(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            // Set up Register
            Dictionary<string, int> register = SetupRegister(input);

            // Int to store highest value ever (for part II)
            int highestValueEver = 0;

            // Loop through instructions
            foreach (string s in input)
            {

                // Split the instructions
                string[] split = s.Split(' ');

                //The left side
                string action = split[1];
                int value = Int32.Parse(split[2]);
                string actionRegister = split[0];

                // The right side
                string conditionOperator = split[5];
                int conditionValue = Int32.Parse(split[6]);
                string conditionRegister = split[4];

                // Do we have to compute the instruction?
                bool conditionTrue = false;
                switch (conditionOperator)
                {
                    case "==":
                        if (register[conditionRegister] == conditionValue)
                        {
                            conditionTrue = true;
                        }
                        break;
                    case "!=":
                        if (register[conditionRegister] != conditionValue)
                        {
                            conditionTrue = true;
                        }
                        break;
                    case ">=":
                        if (register[conditionRegister] >= conditionValue)
                        {
                            conditionTrue = true;
                        }
                        break;
                    case "<=":
                        if (register[conditionRegister] <= conditionValue)
                        {
                            conditionTrue = true;
                        }
                        break;
                    case "<":
                        if (register[conditionRegister] < conditionValue)
                        {
                            conditionTrue = true;
                        }
                        break;
                    case ">":
                        if (register[conditionRegister] > conditionValue)
                        {
                            conditionTrue = true;
                        }
                        break;
                    default:
                        Console.WriteLine("Unknown condition statement: " + s);
                        break;
                }

                // Carry out the action if required
                if (conditionTrue)
                {
                    if (action.Equals("inc"))
                    {
                        register[actionRegister] += value;
                    }
                    else
                    {
                        register[actionRegister] -= value;
                    }

                    if (register[actionRegister] > highestValueEver)
                        highestValueEver = register[actionRegister];
                }

            }

            // Print highest value
            Console.WriteLine("Highest Value in Register: " + GetHighestRegisterValue(register));


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Highest Value Ever: " + highestValueEver);



        }


        private static Dictionary<string, int> SetupRegister(string[] input)
        {
            Dictionary<string, int> register = new Dictionary<string, int>();

            foreach (string s in input)
            {
                string[] split = s.Split(' ');

                if (!register.ContainsKey(split[0]))
                    register.Add(split[0], 0);

                if (!register.ContainsKey(split[4]))
                    register.Add(split[4], 0);
            }

            return register;
        }

        private static int GetHighestRegisterValue(Dictionary<string,int> registerValues)
        {
            int high = 0;

            foreach (var r in registerValues)
            {
                if (r.Value > high)
                    high = r.Value;
            }

            return high;
        }
    }
}
