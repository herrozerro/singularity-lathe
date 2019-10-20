using SingularityLathe.Forge.StellarForge.Bodies;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingularityLathe.Forge.StellarForge.Services
{
    public class PlanetBuilderService
    {
        private Planet _planet = new Planet();
        private readonly Random rnd = new Random();

        public PlanetBuilderService GeneratePhysicalProperties()
        {
            _planet.Tempature = GetRandomTemp(rnd);
            _planet.Atmosphere = GetRandomAtmosphere(rnd);
            _planet.Biosphere = GetRandomBiosphere(rnd);

            return this;
        }

        public PlanetBuilderService GenerateLife()
        {
            if (_planet.Biosphere.Description != "No native biosphere")
            {
                _planet.Population = GetRandomPopulation(rnd);
                _planet.TechLevel = GetRandomTechLevel(rnd);
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


        public void GeneratePlanet()
        {
            GeneratePhysicalProperties();
            GenerateLife();
        }

        public Planet BuildPlanet()
        {
            var newplanet = _planet;
            _planet = new Planet();
            return newplanet;
        }
    }
}
