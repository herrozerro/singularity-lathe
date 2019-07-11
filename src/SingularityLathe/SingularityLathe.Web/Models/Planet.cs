using SingularityLathe.Web.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingularityLathe.Web.Models
{
    public class Planet : IStellarBody
    {
        public string Name { get; set; }
        public int OrbitOrder { get; set; }
        public StellarBodyType stellarBodyType { get { return StellarBodyType.Planet; } }
        public IEnumerable<IStellarBody> ChildBodies { get; set; }

        public Atmosphere Atmosphere { get; set; }

        public string Tempature { get; set; }
        public string Biosphere { get; set; }
        public string Population { get; set; }
        public string TechLevel { get; set; }        
    }

    public class Atmosphere
    {
        public string AtmosphereType { get; set; }
        public bool isBreathable { get; set; }

        public static List<Atmosphere> GetAtmospheres()
        {
            var atmos = new List<Atmosphere>();

            atmos.Add(new Atmosphere
            {
                AtmosphereType = "Corrosive",
                isBreathable = false
            });

            atmos.Add(new Atmosphere
            {
                AtmosphereType = "Inert Gas",
                isBreathable = false
            });

            atmos.Add(new Atmosphere
            {
                AtmosphereType = "Airless or thin atmosphere",
                isBreathable = false
            });

            atmos.Add(new Atmosphere
            {
                AtmosphereType = "Breathable mix",
                isBreathable = true
            });

            atmos.Add(new Atmosphere
            {
                AtmosphereType = "Thick atmosphere, breathable with a mressure mask",
                isBreathable = true
            });

            atmos.Add(new Atmosphere
            {
                AtmosphereType = "Invasive, toxic atmosphere",
                isBreathable = false
            });

            atmos.Add(new Atmosphere
            {
                AtmosphereType = "Corrosive and invasive atmosphere",
                isBreathable = false
            });



            return atmos;
        }

        public static Atmosphere GetRandomAtmosphere()
        {
            var atmos = GetAtmospheres();

            var rnd = new Random();

            return atmos[rnd.Next(atmos.Count)];
        }
    }
}
