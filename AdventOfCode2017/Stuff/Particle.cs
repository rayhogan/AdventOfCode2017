using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Stuff
{
    class Particle
    {
        private List<ParticleProperty> properties;

        public Particle(ParticleProperty position, ParticleProperty velocity, ParticleProperty acceleration)
        {
            properties = new List<ParticleProperty>();
            properties.Add(position);
            properties.Add(velocity);
            properties.Add(acceleration);
        }

        public void PerformCalculations()
        {

            //Increase the X velocity by the X acceleration.
            properties[1].x += properties[2].x;
            //Increase the Y velocity by the Y acceleration.
            properties[1].y += properties[2].y;
            //Increase the Z velocity by the Z acceleration.
            properties[1].z += properties[2].z;
            //Increase the X position by the X velocity.
            properties[0].x += properties[1].x;
            //Increase the Y position by the Y velocity.
            properties[0].y += properties[1].y;
            //Increase the Z position by the Z velocity.
            properties[0].z += properties[1].z;
        }

        public int GetDistance()
        {

            return Math.Abs(properties[0].x)+ Math.Abs(properties[0].y)+ Math.Abs(properties[0].z);
        }

        public string GetPosition()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(properties[0].x +"|"+ properties[0].y +"|"+ properties[0].z);
            return sb.ToString();
        }
    }
}
