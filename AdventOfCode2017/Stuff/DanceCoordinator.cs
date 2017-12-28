using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Stuff
{
    class DanceCoordinator
    {
        private List<char> dancers = new List<char>();

        public DanceCoordinator(char[] input)
        {
            foreach (char i in input)
                dancers.Add(i);
        }

        public void ProcessCommand(string command)
        {
            if (command.StartsWith("s"))
                Spin(command);
            else if (command.StartsWith("x"))
                Exchange(command);
            else if (command.StartsWith("p"))
                Partner(command);
            else
                Console.WriteLine("Error, unknown command");

        }

        private void Spin(string command)
        {
            command = command.Remove(0,1);
            int places = Convert.ToInt32(command);
            List<char> clipboard = new List<char>();

            for (int i = dancers.Count - places; i < dancers.Count; i++)
            {
                clipboard.Add(dancers[i]);
            }

            for (int i = 0; i < dancers.Count - places; i++)
            {
                clipboard.Add(dancers[i]);
            }

            dancers = clipboard;
        }

        private void Exchange(string command)
        {
            // Pull apart the command
            command = command.Remove(0, 1);
            string[] split = command.Split('/');
            int pos1 = Convert.ToInt32(split[0]);
            int pos2 = Convert.ToInt32(split[1]);

            //Clipboard
            List<char> clipboard = new List<char>(dancers);


            clipboard[pos1] = dancers[pos2];
            clipboard[pos2] = dancers[pos1];

            dancers = clipboard;
        }

        private void Partner(string command)
        {
            // Pull apart the command
            command = command.Remove(0, 1);
            char[] split = command.ToCharArray();
            int pos1 = dancers.IndexOf(split[0]);
            int pos2 = dancers.IndexOf(split[2]);

            //Clipboard
            List<char> clipboard = new List<char>(dancers);

            clipboard[pos1] = dancers[pos2];
            clipboard[pos2] = dancers[pos1];

            dancers = clipboard;
        }

       public string PrintOrder()
        {
            StringBuilder sb = new StringBuilder();

            foreach (char i in dancers)
            {
                sb.Append(i);
            }

            return sb.ToString();
        }

        public void Reset(char[] input)
        {
            dancers.Clear();
            foreach (char i in input)
                dancers.Add(i);
        }
    }
}
