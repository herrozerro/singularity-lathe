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
        private readonly AnomalyGeneratorService anomalyGeneratorService = null;
        private readonly StellarForgeConfiguration stellarForgeConfiguration = null;
        private StarSystem starSystem = new StarSystem();
        private readonly Random rnd = null;

        public StarSystemBuilderService(Random random, PlanetBuilderService planetBuilderService, AnomalyGeneratorService anomalyGeneratorService, StellarForgeConfiguration stellarForgeConfiguration)
        {
            rnd = random;
            this.planetBuilderService = planetBuilderService;
            this.anomalyGeneratorService = anomalyGeneratorService;
            this.stellarForgeConfiguration = stellarForgeConfiguration;
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

            //put designations on planets and moons
            var y = 1;
            system.ForEach((x =>
            {
                x.OrbitOrder = y;
                x.Name = starSystem.Designation + "-" + y++;
                
                var m = 1;
                x.ChildBodies.ForEach(z => {
                    z.Name = x.Name + "-" + m++;
                });
            }));

            starSystem.SystemStar.ChildBodies = system;

            //get all bodies and generate anamolies randomly
            var bodies = this.starSystem.SystemStar.Flatten().ToList();
            for (int i = 0; i < rnd.Next(1, 4); i++)
            {
                var body = bodies[rnd.Next(bodies.Count())];

                anomalyGeneratorService.SetBody(body.Name);

                body.Anomalies
                    .Add(anomalyGeneratorService.GenerateAnomaly());
            }

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
