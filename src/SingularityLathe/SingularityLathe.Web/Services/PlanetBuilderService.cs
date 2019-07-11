using SingularityLathe.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingularityLathe.Web.Services
{
    public class PlanetBuilderService
    {
        private Planet _planet = new Planet();
        private readonly Random rnd = new Random();

        public PlanetBuilderService GeneratePhysicalProperties()
        {
            _planet.Biosphere = GetRandomBiosphere(rnd);
            _planet.Tempature = GetRandomTemp(rnd);

            return this;
        }

        public PlanetBuilderService GenerateLife()
        {
            _planet.Population = GetRandomPopulation(rnd);
            if (_planet.Biosphere != "No native biosphere")
            {
                _planet.Population = GetRandomPopulation(rnd);
            }

            return this;
        }

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

        public Planet BuildPlanet()
        {
            var newplanet = _planet;
            _planet = new Planet();
            return newplanet;
        }
    }
}
