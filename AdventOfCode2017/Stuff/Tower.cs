using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Stuff
{
    class Tower
    {
        /*
         * 
         *  Day 7 Tower Class
         * 
         * */
        private int _weight { get; set; }
        private string _name { get; set; }

        private List<Tower> children;

        public Tower(string name, int weight)
        {
            _weight = weight;
            _name = name;

            children = new List<Tower>();
        }

        public void AddChild(Tower t)
        {
            children.Add(t);
        }

        public int CalculateTotalWeight()
        {
            int sum = 0;
            foreach (Tower t in children)
            {
                sum += t.CalculateTotalWeight();
            }

            sum += _weight;

            return sum;
        }

        public List<Tower> GetChildrenNodes()
        {
            return children;
        }

        public override string ToString()
        {
            return "Tower: " + _name + " Weight: " + _weight;
        }

        public int GetWeight()
        {
            return _weight;
        }

        public void FindAnomaly(int difference)
        {
            List<int> sums = new List<int>();
            foreach (Tower t in GetChildrenNodes())
            {
                sums.Add(t.CalculateTotalWeight());
            }

            if (sums.Count > 1)
            {
                var distinctTest = sums.GroupBy(i => i)
                    .Where(g => g.Count() == 1)
                    .Select(g => g.Key);

                ;

                if(distinctTest.Count() == 0)
                {
                    Console.WriteLine(ToString());
                    Console.WriteLine("Expected Weight: " +(GetWeight()+difference));
                }
                else
                {
                    GetChildrenNodes()[sums.IndexOf(distinctTest.First())].FindAnomaly(difference);
                }

                

            }
            else
            {
                Console.WriteLine("Childless Node: "+ToString());
            }


        }

    }
}
