﻿using System;
using System.Collections.Generic;
using System.Linq;
using SingularityLathe.Forge.Interfaces;

namespace SingularityLathe.Forge.StellarForge
{
    public class BioSphere : IWeightedItem
    {
        public int ItemWeight { get; set; }

        public string Description { get; set; }

        public static List<BioSphere> GetBioSpheres()
        {
            var bios = new List<BioSphere>
            {
                new BioSphere()
                {
                    Description = "Biosphere remnants",
                    ItemWeight = 20
                },
                new BioSphere()
                {
                    Description = "Microbial life",
                    ItemWeight = 15
                },
                new BioSphere()
                {
                    Description = "No native biosphere",
                    ItemWeight = 15
                },
                new BioSphere()
                {
                    Description = "Human-miscible biosphere",
                    ItemWeight = 10
                },
                new BioSphere()
                {
                    Description = "Immiscile biosphere",
                    ItemWeight = 10
                },
                new BioSphere()
                {
                    Description = "Hybrid biosphere",
                    ItemWeight = 20
                },
                new BioSphere()
                {
                    Description = "Engineered biosphere",
                    ItemWeight = 5
                }
            };

            return bios;
        }

        public static BioSphere GetRandomBiosphere(Random rnd)
        {
            var bio = GetBioSpheres().GetRandomWeightedItem(rnd);
            return (BioSphere)bio;
        }

        public static BioSphere GetWeightedBiosphere(double lifeWeight)
        {
            //Arbitrary factors that can be changed to make life generally more or less likely
            const int LIFE_SCALE = 2;
            const double SHIFT = 0.2;

            Random rnd = new Random();
            double lifeProbability = lfeWeight * LIFE_SCALE + SHIFT;
            double roll = rnd.NextDouble();
            if(roll > )
        }
    }


}
