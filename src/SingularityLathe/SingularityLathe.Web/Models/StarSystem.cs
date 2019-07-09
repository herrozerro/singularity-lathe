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
            var system = new List<IStellarBody>();
            var rnd = new Random();

            int systemsize = rnd.Next(10);

            for (int i = 0; i < systemsize; i++)
            {
                if (i == 0)
                {
                    SystemStar = new Star {
                        Name = "New System",
                        OrbitOrder = i,
                        StarClass = StarClassification.GetRandomClassification(),
                    };
                }
                else
                {
                    var planet = new Planet(rnd) {
                        Name = SystemStar.Name + " - " + i,
                        OrbitOrder = i
                    };

                    system.Add(planet);
                }
            }

            SystemStar.ChildBodies = system;
        }
    }
}
