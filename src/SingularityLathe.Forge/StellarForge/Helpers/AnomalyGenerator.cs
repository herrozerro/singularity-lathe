using SingularityLathe.RadLibs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingularityLathe.Forge.StellarForge.Helpers
{
    internal class AnomalyGenerator
    {
        private readonly Random rnd = null;
        private readonly RadLibService madLibService = null;

        public AnomalyGenerator(Random rnd, RadLibService madLibService)
        {
            this.rnd = rnd;
            this.madLibService = madLibService;

            var Types = new RadLibTagDictionary()
            {
                Name = "Type"
            };

            Types.Values.Add("Magnetic");
            Types.Values.Add("Gravametric");
            Types.Values.Add("Radiatitive");
        }
    }
}
