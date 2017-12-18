using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Stuff
{
    class FirewallLayer
    {
        /*
         * 
         *  Day 13 firewall class
         * 
         * */
        public int Position { get; set; }
        public int Range { get; set; }
        public bool TravellingDownwards { get; set; }
        public bool EmptyLayer { get; set; }

        public FirewallLayer(int position, int range, bool downwards)
        {
            Position = position;
            Range = range;
            TravellingDownwards = downwards;
            if (range == 0)
                EmptyLayer = true;
            else
                EmptyLayer = false;
        }

        public void MoveScanner()
        {
            if (!EmptyLayer)
            {
                if (TravellingDownwards)
                {
                    Position++;

                    if (Position >= Range)
                        TravellingDownwards = false;

                }
                else
                {
                    Position--;

                    if (Position <= 0)
                        TravellingDownwards = true;
                }
            }
        }

        public int PredictPosition(int counter)
        {
            int currentPos = Position;

            if (!EmptyLayer)
            {
                for (int i = 0; i < counter; i++)
                {
                    if (TravellingDownwards)
                    {
                        currentPos++;

                        if ((currentPos + 1) > Range)
                            TravellingDownwards = false;

                    }
                    else
                    {
                        currentPos--;

                        if ((currentPos - 1) < 0)
                            TravellingDownwards = true;
                    }
                }

                return currentPos;
            }
            else
            {
                return 0;
            }
        }
    }
}
