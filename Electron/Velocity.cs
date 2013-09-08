using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronSimulator
{
    class Velocity : Vector
    {
        public Velocity(double x, double y, double z) : base(x, y, z) { }
        public Velocity(double x, double y) : base(x, y) { }
        public Velocity(Vector v) : base(v.X, v.Y, v.Z) { }

        public double getSpeed()
        {
            double mag = getMagnitude();
            return mag * mag;
        }

        public void reflect(Vector normal)
        {
            Vector normalUnit = normal.getUnitVector();
            double mag = Vector.dotProduct(this, normalUnit);
            Vector nComponent = Vector.scale(mag, normalUnit);
            Vector temp = Vector.add(this, Vector.scale(-2, nComponent));
            this.X = temp.X;
            this.Y = temp.Y;
            this.Z = temp.Z;
        }
    }
}
