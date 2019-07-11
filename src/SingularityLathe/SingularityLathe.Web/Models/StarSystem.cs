using SingularityLathe.Web.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingularityLathe.Web.Models
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
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
