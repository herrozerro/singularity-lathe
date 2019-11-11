using System.Collections.Generic;
using System.Text;

namespace SingularityLathe.Forge.StellarForge
{
    public class Planet : StellarBodyBase
    {
        public Planet()
        {
            StellarBodyType = StellarBodyType.PLANET;
        }

        public Atmosphere Atmosphere { get; set; }

        public Tempature Tempature { get; set; }
        public BioSphere Biosphere { get; set; }
        public Population Population { get; set; }
        public TechLevel TechLevel { get; set; }
    }
}
