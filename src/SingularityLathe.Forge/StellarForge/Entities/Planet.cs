using System.Collections.Generic;
using System.Text;

namespace SingularityLathe.Forge.StellarForge
{
    public class Planet : IStellarBody
    {
        public string Name { get; set; }
        public int OrbitOrder { get; set; }
        public StellarBodyType StellarBodyType { get { return StellarBodyType.PLANET; } }
        public List<IStellarBody> ChildBodies { get; set; }
        public List<string> Anomalies { get; set; }

        public Atmosphere Atmosphere { get; set; }

        public Tempature Tempature { get; set; }
        public BioSphere Biosphere { get; set; }
        public Population Population { get; set; }
        public TechLevel TechLevel { get; set; }
    }
}
