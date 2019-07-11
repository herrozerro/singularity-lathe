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

        public StarSystemGeneratorService(PlanetBuilderService planetBuilderService)
        {
            _planetBuilderService = planetBuilderService;
        }

        public StarSystemGeneratorService GenerateStar()
        {
            _starSystem.SystemStar = new Star
            {
                Name = "New System",
                OrbitOrder = 0,
                StarClass = StarClassification.GetRandomClassification(),
            };

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

            _starSystem.SystemStar.ChildBodies = system;

            return this;
        }

        public StarSystem Build()
        {
            var starSystem = _starSystem;
            _starSystem = new StarSystem();
            return starSystem;
        }
    }
}
