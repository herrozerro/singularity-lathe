using SingularityLathe.Forge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingularityLathe.Forge
{
    public class Star : IStellarBody
    {
        public string Name { get; set; }
        public int OrbitOrder { get; set; }
        public StellarBodyType stellarBodyType { get { return StellarBodyType.Star; } }
        public List<IStellarBody> ChildBodies { get; set; }

        public decimal StellarMass { get; set; }
        public decimal EffectiveTemp { get; set; }

        public StarClassification StarClass { get; set; }
    }

    public class StarClassification
    {
        public string Class { get; set; }
        public string Description { get; set; }
        public string Chromaticity { get; set; }
        public decimal StellarMassMin { get; set; }
        public decimal StellarMassMax { get; set; }
        public decimal EffectiveTempMin { get; set; }
        public decimal EffectiveTempMax { get; set; }

        public decimal Weight { get; set; }

        public static List<StarClassification> GetStarClasses()
        {
            List<StarClassification> starClassifications = new List<StarClassification>();

            starClassifications.Add(new StarClassification
            {
                Class = "O",
                Description = "",
                Chromaticity = "Blue",
                StellarMassMin = 16,
                StellarMassMax = 350,
                EffectiveTempMin = 30000,
                EffectiveTempMax = 40000,
                Weight = 1
            });

            starClassifications.Add(new StarClassification
            {
                Class = "B",
                Description = "",
                Chromaticity = "Blue White",
                StellarMassMin = 2.1M,
                StellarMassMax = 16,
                EffectiveTempMin = 10000,
                EffectiveTempMax = 30000,
                Weight = 1
            });

            starClassifications.Add(new StarClassification
            {
                Class = "A",
                Description = "",
                Chromaticity = "White",
                StellarMassMin = 1.4M,
                StellarMassMax = 2.1M,
                EffectiveTempMin = 7500,
                EffectiveTempMax = 10000,
                Weight = 3
            });

            starClassifications.Add(new StarClassification
            {
                Class = "F",
                Description = "",
                Chromaticity = "Yellow White",
                StellarMassMin = 1.04M,
                StellarMassMax = 1.4M,
                EffectiveTempMin = 6000,
                EffectiveTempMax = 7500,
                Weight = 5
            });

            starClassifications.Add(new StarClassification
            {
                Class = "G",
                Description = "",
                Chromaticity = "Yellow",
                StellarMassMin = .8M,
                StellarMassMax = 1.04M,
                EffectiveTempMin = 5200,
                EffectiveTempMax = 6000,
                Weight = 10
            });

            starClassifications.Add(new StarClassification
            {
                Class = "K",
                Description = "",
                Chromaticity = "Light Orange",
                StellarMassMin = .45M,
                StellarMassMax = .8M,
                EffectiveTempMin = 3700,
                EffectiveTempMax = 5200,
                Weight = 20
            });

            starClassifications.Add(new StarClassification
            {
                Class = "M",
                Description = "",
                Chromaticity = "Orange Red",
                StellarMassMin = .45M,
                StellarMassMax = .8M,
                EffectiveTempMin = 2400,
                EffectiveTempMax = 3700,
                Weight = 60
            });

            return starClassifications;
        }

        public static StarClassification GetRandomClassification()
        {
            var classes = GetStarClasses();

            var rnd = new Random();

            return classes[rnd.Next(classes.Count)];
        }

        public static StarClassification GetWeightedClassification()
        {
            var classes = GetStarClasses();

            var rand = new Random();

            return classes.Where(x => x.Weight <= rand.Next(100)).OrderByDescending(x => x.Weight).First();
        }
    }
}
