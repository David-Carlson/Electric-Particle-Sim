using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronSimulator
{
    abstract class Particle
    {
        public Position Pos { get; set; }

        public Velocity V { get; set; }

        private double q;
        private double m;

        public double charge { get{return q;} }
        public double mass { get{return m;} }
        private int id;
        public int ID { get; }

        private static List<Type> particleClasses = null;
        public static List<Type> particleTypes { get { return particleClasses; } }

        public Particle(double m, double q) 
        {
            this.m = m;
            this.q = q;

            if (particleClasses == null)
                fillClassList();
        }

        public static Particle getInstance(int index)
        {
            return (Particle) Activator.CreateInstance(particleClasses[index]);
        }

        public static void fillClassList()
        {
            particleClasses.Add(typeof(Constants.Electron));
        }
    }
}
