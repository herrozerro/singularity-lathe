using NUnit.Framework;
using Moq;
using System;

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
            var madlibs = new SingularityLathe.Forge.Services.MadLibService(new Random());
            var adventure = new SingularityLathe.Forge.AdventureForge.AdventureGeneratorService(madlibs);
            //Act

            var template = adventure.GenerateAdventure();

            //Assert
            Assert.Pass();
        }
    }
}