using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SingularityLathe.Forge
{
    public class StarSystem
    {
        public string Designation { get; set; }
        public Star SystemStar { get; set; }

        public StarSystem()
        {

        }

        public string serialize()
        {
            return JsonConvert.SerializeObject(this,Formatting.Indented, new JsonSerializerSettings() {  TypeNameHandling = TypeNameHandling.All });
        }
    }
}
