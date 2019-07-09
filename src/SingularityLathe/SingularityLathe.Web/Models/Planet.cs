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

        private string GetRandomTemp(Random rnd)
        {
            var temps = new List<string>();

            temps.Add("Frozen");
            temps.Add("Variable cold-to-temperate");
            temps.Add("Cold");
            temps.Add("Temperate");
            temps.Add("Warm");
            temps.Add("Variable temperate-to-warm");
            temps.Add("Burning");

            return temps[rnd.Next(temps.Count)];
        }
        private string GetRandomBiosphere(Random rnd)
        {
            var bios = new List<string>();

            bios.Add("Biosphere remnants");
            bios.Add("Microbial life");
            bios.Add("No native biosphere");
            bios.Add("Human-miscible biosphere");
            bios.Add("Immiscile biosphere");
            bios.Add("Hybrid biosphere");
            bios.Add("Engineered biosphere");

            return bios[rnd.Next(bios.Count)];
        }
        private string GetRandomPopulation(Random rnd)
        {
            var pops = new List<string>();

            pops.Add("Failed colonoy");
            pops.Add("Outpost");
            pops.Add("Tens of thousands");
            pops.Add("Hundreds of thousands");
            pops.Add("Millions");
            pops.Add("Billions");
            pops.Add("Alien Civilization");

            return pops[rnd.Next(pops.Count)];
        }
        private string GetRandomTechLevel(Random rnd)
        {
            var pops = new List<string>();

            pops.Add("Tech Level 0. Stone Age");
            pops.Add("Tech Level 1. Medieval");
            pops.Add("Tech Level 2. Nineteenth-century");
            pops.Add("Tech Level 3. Twentieth-century");
            pops.Add("Tech Level 4. Baseline postech");
            pops.Add("Tech Level 4 with specialties or some surviving pretech.");
            pops.Add("Tech Level 5. Pretech, pre-Silence tech.");

            return pops[rnd.Next(pops.Count)];
        }

        public Planet(Random rnd)
        {
            Tempature = GetRandomTemp(rnd);
            Biosphere = GetRandomBiosphere(rnd);
            Population = GetRandomPopulation(rnd);
            TechLevel = GetRandomTechLevel(rnd);
        }
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
