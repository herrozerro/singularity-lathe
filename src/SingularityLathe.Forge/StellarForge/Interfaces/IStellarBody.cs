using System;
using System.Collections.Generic;
using System.Text;

namespace SingularityLathe.Forge.StellarForge
{
    public interface IStellarBody
    {
        string Name { get; set; }
        int OrbitOrder { get; set; }
        StellarBodyType StellarBodyType { get; }
        List<IStellarBody> ChildBodies { get; set; }
        List<string> Anomalies { get; set; }

        IEnumerable<IStellarBody> Flatten();
    }
}
