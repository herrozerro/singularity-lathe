using System;
using System.Collections.Generic;
using System.Text;

namespace SingularityLathe.Forge.StellarForge
{
    public class Moon : StellarBodyBase
    {
        public Moon()
        {
            StellarBodyType = StellarBodyType.MOON;
        }
        
        public string Shape { get; set; }
        public Atmosphere Atmosphere { get; set; }
        public Tempature Tempature { get; set; }
        public BioSphere BioSphere { get; set; }

    }
}
