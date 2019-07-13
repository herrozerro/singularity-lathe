using SingularityLathe.Web.Models;
using SingularityLathe.Web.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingularityLathe.Web.Services
{
    public class StarSystemGeneratorService
    {
        private readonly PlanetBuilderService _planetBuilderService = null;

        private StarSystem _starSystem = new StarSystem();

        private readonly Random rnd = new Random();

        public StarSystemGeneratorService(PlanetBuilderService planetBuilderService)
        {
            _planetBuilderService = planetBuilderService;
        }

        public StarSystemGeneratorService GenerateStar()
        {
            _starSystem.Designation = GetRandomDesination();
            _starSystem.SystemStar = new Star
            {
                Name = _starSystem.Designation + "-A",
                OrbitOrder = 0,
                StarClass = StarClassification.GetRandomClassification()
            };

            _starSystem.SystemStar.EffectiveTemp = rnd.Next((int)_starSystem.SystemStar.StarClass.EffectiveTempMin, (int)_starSystem.SystemStar.StarClass.EffectiveTempMax);
            _starSystem.SystemStar.StellarMass = (decimal)(rnd.Next((int)(_starSystem.SystemStar.StarClass.StellarMassMin * 100), (int)(_starSystem.SystemStar.StarClass.StellarMassMax * 100)) / 100.00);

            return this;
        }

        public StarSystemGeneratorService GenerateSystem()
        {
            var system = new List<IStellarBody>();
            var rnd = new Random();

            int systemsize = rnd.Next(10);

            for (int i = 1; i < systemsize; i++)
            {
                _planetBuilderService.GeneratePhysicalProperties();
                _planetBuilderService.GenerateLife();

                system.Add(_planetBuilderService.BuildPlanet());

            }
            var y = 1;
            system.ForEach((x => { x.Name = _starSystem.Designation + "-" + y++; }));

            _starSystem.SystemStar.ChildBodies = system;

            return this;
        }

        public StarSystem Build()
        {
            var starSystem = _starSystem;
            _starSystem = new StarSystem();
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
