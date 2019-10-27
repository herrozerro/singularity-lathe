using System;
using System.Collections.Generic;

namespace SingularityLathe.Forge.StellarForge
{
    public class Tempature
    {
        public string Description { get; set; }
        public double LifeWeight { get; set; }

        public static List<Tempature> GetTempatures()
        {
            var temps = new List<Tempature>
            {
                new Tempature()
                {
                    Description = "Frozen",
                    LifeWeight = .1
                },

                new Tempature()
                {
                    Description = "Variable cold-to-temperate",
                    LifeWeight = .05
                },

                new Tempature()
                {
                    Description = "Cold",
                    LifeWeight = .1
                },

                new Tempature()
                {
                    Description = "Temperate",
                    LifeWeight = .15
                },

                new Tempature()
                {
                    Description = "Warm",
                    LifeWeight = .2
                },

                new Tempature()
                {
                    Description = "Variable temperate-to-warm",
                    LifeWeight = .1
                },

                new Tempature()
                {
                    Description = "Burning",
                    LifeWeight = .01
                }
            };

            return temps;
        } 

        public static Tempature GetRandomTemperature(Random rnd)
        {
            var temps = GetTempatures();

            return temps[rnd.Next(temps.Count)];
        }
    }


}
