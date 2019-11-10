using System;
using System.Collections.Generic;
using System.Text;

namespace SingularityLathe.Forge.StellarForge
{
    public class Moon : IStellarBody
    {
        public string Name { get; set; }
        public int OrbitOrder { get; set; }
        public StellarBodyType StellarBodyType { get { return StellarBodyType.MOON; } }
        public List<IStellarBody> ChildBodies { get; set; }
        public List<string> Anomalies { get; set; }


        public Atmosphere Atmosphere { get; set; }
        public Tempature Tempature { get; set; }
        public BioSphere BioSphere { get; set; }

    }
}
