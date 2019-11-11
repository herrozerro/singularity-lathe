using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingularityLathe.Forge.StellarForge
{
    public abstract class StellarBodyBase : IStellarBody
    {
        public string Name { get; set; }
        public int OrbitOrder { get; set; }
        public StellarBodyType StellarBodyType { get; protected set; }
        public List<IStellarBody> ChildBodies { get; set; } = new List<IStellarBody>();
        public List<string> Anomalies { get; set; }


        public IEnumerable<IStellarBody> Flatten()
        {
            yield return this;

            foreach (var node in ChildBodies.SelectMany(child => child.Flatten()))
            {
                yield return node;
            }
        }
    }
}
