using System;
using System.Collections.Generic;
using System.Text;

namespace SingularityLathe.Forge.StellarForge.Services
{
    public class MoonBuilderService
    {
        private Moon Moon = new Moon();
        private readonly Random rnd = null;
        private readonly StellarForgeConfiguration stellarForgeConfiguration = null;
        public MoonBuilderService(Random random, StellarForgeConfiguration stellarForgeConfiguration)
        {
            rnd = random;
            this.stellarForgeConfiguration = stellarForgeConfiguration;
        }

        public MoonBuilderService GeneratePhysicalProperties()
        {
            Moon.Tempature = GetRandomTemp();
            Moon.Atmosphere = GetRandomAtmosphere();
            Moon.BioSphere = GetRandomBiosphere();

            return this;
        }

        public MoonBuilderService GenerateLife()
        {
            if (Moon.BioSphere.Description != "No native biosphere")
            {
                
            }

            return this;
        }

        private Tempature GetRandomTemp()
        {
            return Tempature.GetRandomTemperature(rnd);
        }
        private BioSphere GetRandomBiosphere()
        {
            return BioSphere.GetRandomBiosphere(rnd);
        }
        private Atmosphere GetRandomAtmosphere()
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
