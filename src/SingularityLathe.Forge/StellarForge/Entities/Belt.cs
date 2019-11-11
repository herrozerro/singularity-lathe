using System;
using System.Collections.Generic;
using System.Text;

namespace SingularityLathe.Forge.StellarForge
{
    public class Belt : StellarBodyBase, IStellarBody
    {
        public Belt()
        {
            StellarBodyType = StellarBodyType.BELT;
        }
    }
}
