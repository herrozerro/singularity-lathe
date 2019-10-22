using SingularityLathe.Forge.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingularityLathe.Forge.StellarForge.Bodies
{
    class Asteroid : IStellarBody
    {
        public string Name { get; set; }
        public int OrbitOrder { get; set; }

        public StellarBodyType StellarBodyType { get; set; }

        public List<IStellarBody> ChildBodies { get; set; }

        public List<string> Anomalies { get; set; }
    }
}
