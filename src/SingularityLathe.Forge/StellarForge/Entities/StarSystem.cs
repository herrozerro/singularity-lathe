using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SingularityLathe.Forge.StellarForge
{
    public class StarSystem
    {
        public string Designation { get; set; }
        public Star SystemStar { get; set; }

        public StarSystem()
        {

        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this,Formatting.Indented, new JsonSerializerSettings() {  TypeNameHandling = TypeNameHandling.All });
        }
    }
}
