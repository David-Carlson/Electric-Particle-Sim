using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronSimulator
{
    class Constants
    {
        public static double tau 
        {
            get { return 2 * Math.PI; }
        }

        public static double K
        {
            get { return 1 / (2 * tau * epsilon); }
        }

        public static double startDist
        {
            get { return 1000000; }
        }


        #region  undeclared constants

        public static double q_e { get; }
        public static double m_e {get; }
        public static double epsilon { get; }
        public static Vector UniformEField { get; }
        public static Vector UniformBField { get; }
        public static double magneticPermeability { get; }
        public static double startingSpeed { get; }
        
        #endregion

        //particles
        #region
        public class Electron : Particle 
        {
            public Electron() : base(q_e, m_e) { }
        }
        #endregion
    }
}
