using SingularityLathe.RadLibs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingularityLathe.Forge.StellarForge
{
    internal class AnomalyGeneratorService
    {
        private readonly RadLibService madLibService = null;

        public AnomalyGeneratorService(RadLibService radLibService)
        {
            this.madLibService = radLibService;

            var Types = new RadLibTagDictionary()
            {
                Name = "AnomalyType"
            };

            Types.Values.Add("Magnetic");
            Types.Values.Add("Gravametric");
            Types.Values.Add("Radiatitive");
        }
    }
}
