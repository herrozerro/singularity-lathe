using SingularityLathe.Forge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingularityLathe.Forge.StellarForge.Services
{
    public class StarSystemBuilderService
    {
        private readonly PlanetBuilderService planetBuilderService = null;
        private StarSystem starSystem = new StarSystem();
        private readonly Random rnd = null;

        public StarSystemBuilderService(Random random, PlanetBuilderService planetBuilderService)
        {
            rnd = random;
            this.planetBuilderService = planetBuilderService;
        }

        public StarSystemBuilderService GenerateStar()
        {
            starSystem.Designation = GetRandomDesination();
            starSystem.SystemStar = new Star
            {
                Name = starSystem.Designation + "-A",
                OrbitOrder = 0,
                StarClass = StarClassification.GetRandomClassification(rnd)
            };

            starSystem.SystemStar.EffectiveTemp = rnd.Next((int)starSystem.SystemStar.StarClass.EffectiveTempMin, (int)starSystem.SystemStar.StarClass.EffectiveTempMax);
            starSystem.SystemStar.StellarMass = (decimal)(rnd.Next((int)(starSystem.SystemStar.StarClass.StellarMassMin * 100), (int)(starSystem.SystemStar.StarClass.StellarMassMax * 100)) / 100.00);

            return this;
        }

        public StarSystemBuilderService GenerateSystem()
        {
            var system = new List<IStellarBody>();

            int systemsize = rnd.Next(10);

            for (int i = 1; i < systemsize; i++)
            {
                planetBuilderService.GeneratePlanet();

                system.Add(planetBuilderService.BuildPlanet());

            }
            var y = 1;
            system.ForEach((x => { x.Name = starSystem.Designation + "-" + y++; }));

            starSystem.SystemStar.ChildBodies = system;

            return this;
        }

        public StarSystem Build()
        {
            var starSystem = this.starSystem;
            this.starSystem = new StarSystem();
            return starSystem;
        }

        private string GetRandomDesination()
        {
            var des = rnd.Next(10000).ToString("0000");

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return des + "-" + new string(Enumerable.Repeat(chars, 3)
             .Select(s => s[rnd.Next(s.Length)]).ToArray());

        }
    }
}
