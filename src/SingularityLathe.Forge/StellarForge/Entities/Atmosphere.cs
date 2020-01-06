using System;
using System.Collections.Generic;

namespace SingularityLathe.Forge.StellarForge
{
    public class Atmosphere
    {
        public string AtmosphereType { get; set; }
        public bool IsBreathable { get; set; }
        public double LifeWeight { get; set; }

        public static List<Atmosphere> GetAtmospheres()
        {
            var atmos = new List<Atmosphere>
            {
                new Atmosphere
                {
                    AtmosphereType = "Corrosive",
                    IsBreathable = false,
                    LifeWeight = .01
                },

                new Atmosphere
                {
                    AtmosphereType = "Inert Gas",
                    IsBreathable = false,
                    LifeWeight = .05
                },

                new Atmosphere
                {
                    AtmosphereType = "Airless or thin atmosphere",
                    IsBreathable = false,
                    LifeWeight = .07
                },

                new Atmosphere
                {
                    AtmosphereType = "Breathable mix",
                    IsBreathable = true,
                    LifeWeight = .2
                },

                new Atmosphere
                {
                    AtmosphereType = "Thick atmosphere, breathable with a mressure mask",
                    IsBreathable = true,
                    LifeWeight = .25
                },

                new Atmosphere
                {
                    AtmosphereType = "Invasive, toxic atmosphere",
                    IsBreathable = false,
                    LifeWeight = .05
                },

                new Atmosphere
                {
                    AtmosphereType = "Corrosive and invasive atmosphere",
                    IsBreathable = false,
                    LifeWeight = .04
                }
            };

            return atmos;
        }

        public static Atmosphere GetRandomAtmosphere(Random rnd)
        {
            var atmos = GetAtmospheres();

            return atmos[rnd.Next(atmos.Count)];
        }
    }


}
