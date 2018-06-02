using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Stuff
{
    /*
     * Day 21 image processing class
     * */

    class ImageProcessor
    {

        private string[] canvas = new string[] {
            ".#.",
            "..#",
            "###",
        };

        private int size = 3;

        private List<string> ruleStructue = new List<string>();
        private List<string> ruleOutput = new List<string>();
        public ImageProcessor(string[] rules)
        {
            // configure rule book
            foreach (string s in rules)
            {
                BuildRuleBook(s);
            }

        }

        private void BuildRuleBook(string s)
        {
            string[] split = s.Split('=');

            //Add Initial
            string rule = split[0].Trim(' ');
            string output = split[1].Trim('>').Trim(' ');

            if (!ruleStructue.Contains(rule))
            {
                ruleStructue.Add(rule);
                ruleOutput.Add(output);
            }

            for (int i = 0; i < 3; i++)
            {
                s = Rotate(rule);

                if (!ruleStructue.Contains(s))
                {
                    ruleStructue.Add(s);
                    ruleOutput.Add(output);
                }

                if (!ruleStructue.Contains(Flip(s)))
                {
                    ruleStructue.Add(Flip(s));
                    ruleOutput.Add(output);
                }

                if (!ruleStructue.Contains(Swap(s)))
                {
                    ruleStructue.Add(Swap(s));
                    ruleOutput.Add(output);
                }

                rule = s;
            }


        }

        public void Draw()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(canvas[i][j]);
                }
                Console.WriteLine();
            }
        }

        public void Mutate()
        {
            if (size % 2 == 0)
                FirstRule();
            else if (size % 3 == 0)
                SecondRule();
            else
                throw new Exception("ERROR MUTATING GRID");
        }

        private void FirstRule()
        {
            List<string> squares = new List<string>();
            int iterations = size / 2;

            int x = 0;
            int y = 0;

            // Process it for how many squares we've identified
            for (int i = 0; i < iterations; i++)
            {

                for (int j = 0; j < iterations; j++)
                {
                    StringBuilder square = new StringBuilder();
                    for (int _x = 0; _x < 2; _x++)
                    {
                        for (int _y = 0; _y < 2; _y++)
                        {
                            square.Append(canvas[_x + x][_y + y]);
                        }
                        square.Append("/");
                    }
                    squares.Add(square.ToString());

                    y += 2;
                }
                x += 2;
                y = 0;

            }

            string[] clipboard = new string[canvas.Length / 2 * 3];

            x = 0;
            // Rebuild the grid
            for (int i = 0; i < squares.Count; i++)
            {
                string square = ConsultRuleBook(squares[i]);

                if (square == "") // original square
                {
                    string[] split = squares[i].Split('/');


                    for (int j = 0; j < split.Length; j++)
                    {
                        clipboard[j + x] = clipboard[j + x] + "" + split[j];
                    }
                }
                else // Expand to 3x3
                {
                    string[] split = square.Split('/');
                    for (int j = 0; j < split.Length; j++)
                    {
                        clipboard[j + x] = clipboard[j + x] + "" + split[j];
                    }
                }

                if (i != 0 && (i + 1) % iterations == 0)
                    x += 3;

            }

            size = clipboard.Length;
            canvas = clipboard;

        }

        private void SecondRule()
        {
            List<string> squares = new List<string>();
            int iterations = size / 3;

            int x = 0;
            int y = 0;

            // Process it for how many squares we've identified
            for (int i = 0; i < iterations; i++)
            {

                for (int j = 0; j < iterations; j++)
                {
                    StringBuilder square = new StringBuilder();
                    for (int _x = 0; _x < 3; _x++)
                    {
                        for (int _y = 0; _y < 3; _y++)
                        {
                            square.Append(canvas[_x + x][_y + y]);
                        }
                        square.Append("/");
                    }
                    squares.Add(square.ToString());

                    y += 3;
                }
                x += 3;
                y = 0;

            }

            string[] clipboard = new string[canvas.Length / 3 * 4];

            x = 0;
            // Rebuild the grid
            for (int i = 0; i < squares.Count; i++)
            {

                string square = ConsultRuleBook(squares[i]);

                if (square == "") // original square
                {
                    string[] split = squares[i].Split('/');


                    for (int j = 0; j < split.Length; j++)
                    {
                        clipboard[j + x] = clipboard[j + x] + "" + split[j];
                    }
                }
                else // Expand to 4x4
                {
                    string[] split = square.Split('/');
                    for (int j = 0; j < split.Length; j++)
                    {
                        clipboard[j + x] = clipboard[j + x] + "" + split[j];
                    }
                }

                if (i != 0 && (i + 1) % iterations == 0)
                    x += 4;

            }

            size = clipboard.Length;
            canvas = clipboard;

        }

        private string ConsultRuleBook(string square)
        {

            if (ruleStructue.Contains(square.TrimEnd('/')))
            {
                return ruleOutput[ruleStructue.IndexOf(square.TrimEnd('/'))];
            }
            else
                return "";
        }

        private string Rotate(string input)
        {
            string[] split = input.Split('/');
            char[] duplicate = input.ToCharArray();


            if (split.Count() == 2)
            {
                duplicate[0] = input.ToCharArray()[3];
                duplicate[1] = input.ToCharArray()[0];
                duplicate[3] = input.ToCharArray()[4];
                duplicate[4] = input.ToCharArray()[1];
            }
            else if (split.Count() == 3)
            {
                duplicate[0] = input.ToCharArray()[8];
                duplicate[1] = input.ToCharArray()[4];
                duplicate[2] = input.ToCharArray()[0];
                duplicate[4] = input.ToCharArray()[9];
                duplicate[5] = input.ToCharArray()[5];
                duplicate[6] = input.ToCharArray()[1];
                duplicate[8] = input.ToCharArray()[10];
                duplicate[9] = input.ToCharArray()[6];
                duplicate[10] = input.ToCharArray()[2];
            }
            else
            {
                throw new Exception("ERROR");
            }

            // Reconstruct & return
            StringBuilder output = new StringBuilder();
            foreach (char c in duplicate)
            {
                output.Append(c);
            }
            return output.ToString();
        }

        private string Flip(string input)
        {
            string[] split = input.Split('/');
            char[] duplicate = input.ToCharArray();


            if (split.Count() == 2)
            {
                duplicate[0] = input.ToCharArray()[3];
                duplicate[1] = input.ToCharArray()[4];
                duplicate[3] = input.ToCharArray()[0];
                duplicate[4] = input.ToCharArray()[1];
            }
            else if (split.Count() == 3)
            {
                duplicate[0] = input.ToCharArray()[8];
                duplicate[1] = input.ToCharArray()[9];
                duplicate[2] = input.ToCharArray()[10];
                duplicate[4] = input.ToCharArray()[4];
                duplicate[5] = input.ToCharArray()[5];
                duplicate[6] = input.ToCharArray()[6];
                duplicate[8] = input.ToCharArray()[0];
                duplicate[9] = input.ToCharArray()[1];
                duplicate[10] = input.ToCharArray()[2];
            }
            else
            {
                throw new Exception("ERROR");
            }

            // Reconstruct & return
            StringBuilder output = new StringBuilder();
            foreach (char c in duplicate)
            {
                output.Append(c);
            }
            return output.ToString();
        }

        private string Swap(string input)
        {
            string[] split = input.Split('/');
            char[] duplicate = input.ToCharArray();


            if (split.Count() == 2)
            {
                duplicate[0] = input.ToCharArray()[1];
                duplicate[1] = input.ToCharArray()[0];
                duplicate[3] = input.ToCharArray()[4];
                duplicate[4] = input.ToCharArray()[3];
            }
            else if (split.Count() == 3)
            {
                duplicate[0] = input.ToCharArray()[2];
                duplicate[1] = input.ToCharArray()[1];
                duplicate[2] = input.ToCharArray()[0];
                duplicate[4] = input.ToCharArray()[6];
                duplicate[5] = input.ToCharArray()[5];
                duplicate[6] = input.ToCharArray()[4];
                duplicate[8] = input.ToCharArray()[10];
                duplicate[9] = input.ToCharArray()[9];
                duplicate[10] = input.ToCharArray()[8];
            }
            else
            {
                throw new Exception("ERROR");
            }

            // Reconstruct & return
            StringBuilder output = new StringBuilder();
            foreach (char c in duplicate)
            {
                output.Append(c);
            }
            return output.ToString();
        }

        public int CountLights()
        {
            int count = 0;
            for (int i = 0; i < canvas.Length; i++)
            {
                for (int j = 0; j < canvas.Length; j++)
                {
                    if (canvas[i][j] == '#')
                        count++;
                }
            }

            return count;
        }
    }
}
