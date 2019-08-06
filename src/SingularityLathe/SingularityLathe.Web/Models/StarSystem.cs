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
            return System.Text.Json.JsonSerializer.Serialize(this,typeof(StarSystem),new System.Text.Json.JsonSerializerOptions() { WriteIndented = true, MaxDepth = 6 });
        }
    }
}
