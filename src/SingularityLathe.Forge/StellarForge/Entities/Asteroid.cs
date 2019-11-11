using System;
using System.Collections.Generic;
using System.Text;

namespace SingularityLathe.Forge.StellarForge
{
    public class Asteroid : StellarBodyBase, IStellarBody
    {
        public Asteroid()
        {
            StellarBodyType = StellarBodyType.ASTEROID;
        }
    }
}
