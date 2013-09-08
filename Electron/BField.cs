using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronSimulator
{
    class BField : Field
    {
        public Vector getForceOn(Particle particle, bool isUniform = false)
        {
            Vector cross = Vector.crossProduct(particle.velocity, getField(particle, isUniform));
            return Vector.scale(particle.charge, cross);
        }

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
                return Constants.UniformBField;
        }

        private Vector componentField(Particle particle, Position pos)
        {
            Vector radius = Vector.add(particle.pos, Vector.scale(-1, pos));
            Vector cross = Vector.crossProduct(particle.velocity, radius.getUnitVector());
            double dist = radius.getMagnitude();
            double scalar = (Constants.magneticPermeability * particle.charge) / (2 * Constants.tau * dist * dist);
            return Vector.scale(scalar, cross);
        }
    }
}
