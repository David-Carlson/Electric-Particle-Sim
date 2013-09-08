using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronSimulator
{
    interface Field
    {

        public Vector getForceOn(Particle particle, bool isUniform = false);
        private Vector getField(Particle particle, bool isUniform);
        private Vector componentField(Particle particle, Position pos);
    }
}
