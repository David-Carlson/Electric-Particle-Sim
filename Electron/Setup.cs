using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronSimulator
{
    class Setup
    {
        private List<Particle> particles;
        public List<Particle> Particles { get { return particles; } }
        private static Setup setup = new Setup();
        public static Setup Instance { get { return setup; } }
        public bool threeD;

        private class IncomingParticle 
        {
            public bool Active{get; set;}
            private double distance;
            private Velocity velocity;
            private Particle particle;

            public IncomingParticle() { Active = false; }

            public void createNew(Velocity initial, Particle p)
            {
                distance = Constants.startDist;
                velocity = initial;
                particle = p;
                Active = true;
            }
            public Particle toParticle()
            {
                particle.V = velocity;
                Position p = new Position(Velocity.scale(-1, velocity.getUnitVector()));
                particle.Pos = p;
                Active = false;
                return particle;
            }
        }
        private IncomingParticle incoming;
        private Setup()
        {
            threeD = false;
            particles = new List<Particle>();
            Particle.fillClassList();
            incoming = new IncomingParticle();
        }

        public void addParticle()
        {
            if (!incoming.Active)
                return;
            Position entrance = findEntryPoint();
            double electricPotential = getPotential();
            Random generator = new Random();
            int index = generator.Next(0, Particle.particleTypes.Count);
            Particle p = Particle.getInstance(index);
            double potentialEnergy = p.charge * electricPotential;
            double finalKineticEnergy = p.mass * Constants.startingSpeed * Constants.startingSpeed / 2;
            double totalEnergy = potentialEnergy + finalKineticEnergy;
            double initialSpeed = Math.Sqrt(2 * totalEnergy / p.mass);
            Velocity vel = new Velocity(Vector.scale(-1, entrance.getUnitVector()));
            vel = (Velocity) Vector.scale(initialSpeed, vel);
            incoming.createNew(vel, p);
        }

        private double getPotential()
        {
            double totalCharge = 0;
            foreach (Particle p in particles)
                totalCharge += p.charge;
            double coefficient = -1 * totalCharge / (Constants.tau * Constants.epsilon);
            double integrate;
            if (threeD)
            {
                coefficient /= -2;
                integrate = 1 / .001 - 1 / (Constants.startDist / 1000);
                return coefficient * integrate;
            }
            integrate = Math.Log(.001 / (Constants.startDist / 1000));
            return coefficient * integrate;
        }

        private Position findEntryPoint()
        {
            Position entrance;
            Random generator = new Random();
            double x = generator.NextDouble();
            if (generator.Next(0, 2) == 1)
                x *= -1;
            double y;
            if (threeD && x != 1)
            {
                do
                {
                    y = generator.NextDouble();
                    if (generator.Next(0, 2) == 1)
                        y *= -1;
                } while ((x * x + y * y) > 1);
                double z = Math.Sqrt(1 - (x * x + y * y));
                if (generator.Next(0, 2) == 1)
                    z *= -1;
                entrance = new Position(x, y, z);
            }
            else
            {
                y = Math.Sqrt(1 - x * x);
                entrance = new Position(x, y);
            }
            return entrance;
        }
    }
}
