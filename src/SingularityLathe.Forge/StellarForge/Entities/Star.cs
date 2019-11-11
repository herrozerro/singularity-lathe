using SingularityLathe.Forge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingularityLathe.Forge.StellarForge
{
    public class Star : StellarBodyBase
    {
        public Star()
        {
            StellarBodyType = StellarBodyType.STAR;
        }

        public decimal StellarMass { get; set; }
        public decimal EffectiveTemp { get; set; }

        public StarClassification StarClass { get; set; }
    }

    public class StarClassification : IWeightedItem
    {
        public string Class { get; set; }
        public string Description { get; set; }
        public string Chromaticity { get; set; }
        public decimal StellarMassMin { get; set; }
        public decimal StellarMassMax { get; set; }
        public decimal EffectiveTempMin { get; set; }
        public decimal EffectiveTempMax { get; set; }

        public int ItemWeight { get; set; }

        public static List<StarClassification> GetStarClasses()
        {
            List<StarClassification> starClassifications = new List<StarClassification>
            {
                new StarClassification
                {
                    Class = "O",
                    Description = "",
                    Chromaticity = "Blue",
                    StellarMassMin = 16,
                    StellarMassMax = 350,
                    EffectiveTempMin = 30000,
                    EffectiveTempMax = 40000,
                    ItemWeight = 1
                },

                new StarClassification
                {
                    Class = "B",
                    Description = "",
                    Chromaticity = "Blue White",
                    StellarMassMin = 2.1M,
                    StellarMassMax = 16,
                    EffectiveTempMin = 10000,
                    EffectiveTempMax = 30000,
                    ItemWeight = 1
                },

                new StarClassification
                {
                    Class = "A",
                    Description = "",
                    Chromaticity = "White",
                    StellarMassMin = 1.4M,
                    StellarMassMax = 2.1M,
                    EffectiveTempMin = 7500,
                    EffectiveTempMax = 10000,
                    ItemWeight = 3
                },

                new StarClassification
                {
                    Class = "F",
                    Description = "",
                    Chromaticity = "Yellow White",
                    StellarMassMin = 1.04M,
                    StellarMassMax = 1.4M,
                    EffectiveTempMin = 6000,
                    EffectiveTempMax = 7500,
                    ItemWeight = 5
                },

                new StarClassification
                {
                    Class = "G",
                    Description = "",
                    Chromaticity = "Yellow",
                    StellarMassMin = .8M,
                    StellarMassMax = 1.04M,
                    EffectiveTempMin = 5200,
                    EffectiveTempMax = 6000,
                    ItemWeight = 10
                },

                new StarClassification
                {
                    Class = "K",
                    Description = "",
                    Chromaticity = "Light Orange",
                    StellarMassMin = .45M,
                    StellarMassMax = .8M,
                    EffectiveTempMin = 3700,
                    EffectiveTempMax = 5200,
                    ItemWeight = 20
                },

                new StarClassification
                {
                    Class = "M",
                    Description = "",
                    Chromaticity = "Orange Red",
                    StellarMassMin = .45M,
                    StellarMassMax = .8M,
                    EffectiveTempMin = 2400,
                    EffectiveTempMax = 3700,
                    ItemWeight = 60
                }
            };

            return starClassifications;
        }

        public static StarClassification GetRandomClassification(Random rnd)
        {
            var classes = GetStarClasses();

            return classes[rnd.Next(classes.Count)];
        }

        public static StarClassification GetWeightedClassification(Random rnd)
        {
            var starClass = GetStarClasses().GetRandomWeightedItem(rnd);

            return (StarClassification)starClass;
        }
    }
}
