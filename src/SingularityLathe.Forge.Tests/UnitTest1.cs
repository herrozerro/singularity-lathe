using NUnit.Framework;
using Moq;
using System;
using SingularityLathe.Forge.StellarForge.Services;
using System.Linq;
using SingularityLathe.RadLibs;

namespace SingularityLathe.Forge.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AdventureForgeTest()
        {
            //Arrange
            var madlibs = new RadLibs.RadLibService(new RadLibs.RadLibConfiguration() { RandomSeed = 1 });
            var adventure = new AdventureForge.AdventureGeneratorService(new Random(), madlibs);

            //Act
            var template = adventure.GenerateAdventure();

            //Assert
            Assert.Pass();
        }

        [Test]
        public void StellarGenTest()
        {
            var rnd = new Random(123);
            var config = new StellarForge.StellarForgeConfiguration();
            var systemGen = new StarSystemBuilderService(rnd, new PlanetBuilderService(rnd, new MoonBuilderService(rnd, config), config), new AnomalyGeneratorService(new RadLibService(new RadLibConfiguration() { RandomSeed = rnd.Next() }), rnd), config);

            var system = systemGen.GenerateStar().GenerateSystem().Build();

            Assert.True(system.Designation != null);
        }

        [Test]
        public void StellarGenFlatten()
        {
            var rnd = new Random(1);
            var config = new StellarForge.StellarForgeConfiguration();
            var systemGen = new StarSystemBuilderService(rnd, new PlanetBuilderService(rnd, new MoonBuilderService(rnd, config), config), new AnomalyGeneratorService(new RadLibService(new RadLibConfiguration() { RandomSeed = rnd.Next() }), rnd), config);

            var system = systemGen.GenerateStar().GenerateSystem().Build();

            var nodes = system.SystemStar.Flatten().ToList();

            Assert.True(system.Designation != null);
        }
    }
}