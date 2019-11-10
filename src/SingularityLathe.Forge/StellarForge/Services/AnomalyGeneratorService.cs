using SingularityLathe.RadLibs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingularityLathe.Forge.StellarForge
{
    internal class AnomalyGeneratorService
    {
        private readonly RadLibService madLibService = null;
        private readonly List<string> templates = new List<string>();


        public AnomalyGeneratorService(RadLibService radLibService)
        {
            this.madLibService = radLibService;

            templates.Add("A [[ANOMALYTYPE]] source was detected on the surface of [[BODY]].  It is unusual for what appears to be a natural source.  However, a [[HAZARD]] is detected nearby.");
            templates.Add("A navigational beacon was detected in orbit around [[BODY]], the message is being distorted by [[ANOMALYTYPE]] interference.  But what is coming through is disturbing.");
            templates.Add("Sensors have picked up a [[ANOMALYTYPE]] signal, but it disappeared just as quickly as it appeared.  According to the Navigational database, this has been reported before in a [[HAZARD]].  [[AUTHORITY]] has a bounty on finding the source.");

            var Types = new RadLibTagDictionary("ANOMALYTYPE");

            Types.Values.Add("Magnetic");
            Types.Values.Add("Gravametric");
            Types.Values.Add("Radiatitive");

            var Hazards = new RadLibTagDictionary("HAZARD");

            Hazards.Values.Add("Micro Meteorite Cloud");
            Hazards.Values.Add("Ionizing Radiation Storm");

            var Authority = new RadLibTagDictionary("AUTHORITY");

            Authority.Values.Add("Spacer's Guild");
            Authority.Values.Add("UNN Government");



        }
    }
}
