using System;
using System.Collections.Generic;
using System.Text;

namespace SingularityLathe.Forge.StellarForge.Services
{
    public class MoonBuilderService
    {
        private Moon Moon = new Moon();
        private readonly Random rnd = null;

        public MoonBuilderService(Random random)
        {
            rnd = random;
        }

        public MoonBuilderService GeneratePhysicalProperties()
        {
            Moon.Tempature = GetRandomTemp(rnd);
            Moon.Atmosphere = GetRandomAtmosphere(rnd);
            Moon.BioSphere = GetRandomBiosphere(rnd);

            return this;
        }

        public MoonBuilderService GenerateLife()
        {
            if (Moon.BioSphere.Description != "No native biosphere")
            {
                
            }

            return this;
        }

        private Tempature GetRandomTemp(Random rnd)
        {
            return Tempature.GetRandomTemperature(rnd);
        }
        private BioSphere GetRandomBiosphere(Random rnd)
        {
            return BioSphere.GetRandomBiosphere(rnd);
        }
        private Population GetRandomPopulation(Random rnd)
        {
            return Population.GetRandomPopulation(rnd);
        }
        private TechLevel GetRandomTechLevel(Random rnd)
        {
            return TechLevel.GetRandomPopulation(rnd);
        }
        private Atmosphere GetRandomAtmosphere(Random rnd)
        {
            return Atmosphere.GetRandomAtmosphere(rnd);
        }

        public void GenerateMoon()
        {
            GeneratePhysicalProperties();
            GenerateLife();
        }

        public Moon BuildMoon()
        {
            var newMoon = Moon;
            Moon = new Moon();
            return newMoon;
        }
    }
}
