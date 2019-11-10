using NUnit.Framework;
using Moq;
using System;
using SingularityLathe.Forge.StellarForge.Services;

namespace SingularityLathe.Forge.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //Arrange
            var madlibs = new RadLibs.RadLibService(new RadLibs.RadLibConfiguration() { RandomSeed = 1});
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

            var systemGen = new StarSystemBuilderService(rnd, new PlanetBuilderService(rnd));

            var system = systemGen.GenerateStar().GenerateSystem().Build();

            Assert.Pass();
        } 
    }
}