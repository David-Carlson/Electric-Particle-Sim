using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronSimulator
{
    class Position : Vector
    {

        public Position(double x, double y, double z) : base(x, y, z) { }
        public Position(double x, double y) : base(x, y) { }
        public Position(Vector v) : base(v.X, v.Y, v.Z) { }

        public void toPolar(out double theta, out double radius)
        {
            theta = getArcTan(X, Y);
            radius = Math.Sqrt(X * X + Y * Y);
        }

        public void toPolar (out double radius, out double theta, out double z)
        {
            toPolar(out theta, out radius);
            z = Z;
        }

        public void toPolar(out double radius, out double theta, out double phi) 
        {
            toPolar(out theta, out radius);
            phi = getArcTan(Z, radius);
            radius = getMagnitude();
        }

        private double getArcTan(double adjacent, double opposite) 
        {
            double theta = Math.Atan2(opposite, adjacent);
            if (theta < 0)
            {
                if (adjacent >= 0)
                    theta += Constants.tau;
                else if (adjacent < 0)
                    theta += Math.PI;
            }
            else if (theta > 0 && adjacent < 0)
                theta += Math.PI;
            else
                if (adjacent < 0)
                    theta += Math.PI;
            return theta;
        }
    }
}
