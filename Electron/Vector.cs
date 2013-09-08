using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronSimulator
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector(double x, double y, double z)
        {
            setValues(x, y, z);
        }

        public Vector(double x, double y)
        {
            setValues(x, y, 0);
        }

        public Vector(Vector dir, double mag)
        {
            dir = scale(mag, dir);
            setValues(dir.X, dir.Y, dir.Z);
        }

        private void setValues(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector crossProduct(Vector a, Vector b)
        {
            double x = a.Y * b.Z - b.Y * a.Z;
            double y = b.X * a.Z - a.X * b.Z;
            double z = a.X * b.Y - a.Y * b.X;
            return new Vector(x, y, z);
        }

        public static double dotProduct(Vector a, Vector b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        public static double getCosTheta(Vector a, Vector b)
        {
            double dotProd = dotProduct(a, b);
            double magA = a.getMagnitude();
            double magB = b.getMagnitude();
            return dotProd / (magA * magB);
        }

        public double getMagnitude() 
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public Vector getUnitVector()
        {
            double x = X / getMagnitude();
            double y = Y / getMagnitude();
            double z = Z / getMagnitude();
            return new Vector(x, y, z);
        }

        public static Vector add(Vector a, Vector b)
        {
            double x = a.X + b.X;
            double y = a.Y + b.Y;
            double z = a.Z + b.Z;
            return new Vector(x, y, z);
        }

        public static Vector scale(double T, Vector a)
        {
            double x = a.X * T;
            double y = a.Y * T;
            double z = a.Z * T;
            return new Vector(x, y, z);
        }
    }
}
