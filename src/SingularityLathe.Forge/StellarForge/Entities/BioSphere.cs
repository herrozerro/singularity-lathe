using System;
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
            const int[] GOOD_BIOS = { 6, 5, 3 };
            const int[] MEDIUM_BIOS = { 1, 0 };
            const int[] BAD_BIOS = { 2, 4 };

            //Arbitrary factors that can be changed to make life generally more or less likely
            const double GOOD_THRESHOLD = 0.8;
            const double MEDIUM_THRESHOLD = 0.3;
            Random rnd = new Random();
            double roll = (rnd.NextDouble() * 1.1 - 0.5) + lifeWeight;

            if(roll > GOOD_THRESHOLD)
            {
                int bioIndex = rnd.Next(GOOD_BIOS.Length);
                BioSphere bio = GetBioSpheres()[bioIndex];
            }
            else if(roll > MEDIUM_THRESHOLD)
            {
                int bioIndex = rnd.Next(MEDIUM_BIOS.Length);
                BioSphere bio = GetBioSpheres()[bioIndex];
            }
            else
            {
                int bioIndex = rnd.Next(BAD_BIOS.Length);
                BioSphere bio = GetBioSpheres()[bioIndex];
            }
        }
    }


}
