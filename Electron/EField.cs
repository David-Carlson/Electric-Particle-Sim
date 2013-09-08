using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronSimulator
{
    class EField : Field
    {
        public Vector getForceOn(Particle particle, bool isUniform = false)
        {
            return Vector.scale(particle.charge, getField(particle, isUniform));
        }

        //This is a test

        private Vector getField(Particle particle, bool isUniform)
        {
            if (!isUniform)
            {
                Vector result = new Vector(0, 0);
                foreach (Particle p in Setup.Instance.Particles)
                    if (particle.ID != p.ID)
                        result = Vector.add(result, componentField(p, particle.Pos));
                return result;
            }
            else
                return Constants.UniformEField;
        }

        private Vector componentField(Particle particle, Position pos) 
        {
            Vector diff = Vector.add(particle.pos, Vector.scale(-1, pos)); 
            double dist = diff.getMagnitude();
            Vector dir = diff.getUnitVector();
            double mag = Constants.K * particle.charge / (dist * dist);
            return new Vector(dir, mag);
        }
    }
}
