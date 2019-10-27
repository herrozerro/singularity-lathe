using System;
using System.Collections.Generic;
using System.Text;

namespace SingularityLathe.Forge.StellarForge
{
    class Asteroid : IStellarBody
    {
        public string Name { get; set; }
        public int OrbitOrder { get; set; }

        public StellarBodyType StellarBodyType { get { return StellarBodyType.ASTEROID; } }

        public List<IStellarBody> ChildBodies { get; set; }

        public List<string> Anomalies { get; set; }
    }
}
