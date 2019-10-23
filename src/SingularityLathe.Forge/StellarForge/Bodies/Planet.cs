using SingularityLathe.Forge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingularityLathe.Forge.StellarForge.Bodies
{
    public class Planet : IStellarBody
    {
        public string Name { get; set; }
        public int OrbitOrder { get; set; }
        public StellarBodyType StellarBodyType { get { return StellarBodyType.PLANET; } }
        public List<IStellarBody> ChildBodies { get; set; }
        public List<string> Anomalies { get; set; }

        public Atmosphere Atmosphere { get; set; }

        public Tempature Tempature { get; set; }
        public BioSphere Biosphere { get; set; }
        public Population Population { get; set; }
        public TechLevel TechLevel { get; set; }
    }

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
            var bios = GetBioSpheres().Select(x => (IWeightedItem)x).ToList();
            return (BioSphere)bios.GetRandomWeightedItem(rnd);
        }
    }

    public class Population : IWeightedItem
    {
        public int ItemWeight { get; set; }
        public string Description { get; set; }

        public static List<Population> GetPopulations()
        {
            var pops = new List<Population>
            {
                new Population()
                {
                    Description = "Failed colonoy",
                    ItemWeight = 20
                },
                new Population()
                {
                    Description = "Outpost",
                    ItemWeight = 15
                },
                new Population()
                {
                    Description = "Tens of thousands",
                    ItemWeight = 15
                },
                new Population()
                {
                    Description = "Hundreds of thousands",
                    ItemWeight = 10
                },
                new Population()
                {
                    Description = "Millions",
                    ItemWeight = 10
                },
                new Population()
                {
                    Description = "Billions",
                    ItemWeight = 20
                },
                new Population()
                {
                    Description = "Alien Civilization",
                    ItemWeight = 5
                }
            };

            return pops;
        }

        public static Population GetRandomPopulation(Random rnd)
        {
            var pops = GetPopulations().Select(x => (IWeightedItem)x).ToList();

            return (Population)pops.GetRandomWeightedItem(rnd);
        }
    }

    public class TechLevel : IWeightedItem
    {
        public int ItemWeight { get; set; }
        public string Description { get; set; }

        public static List<TechLevel> GetTechLevels()
        {
            var techs = new List<TechLevel>
            {
                new TechLevel()
                {
                    Description = "Tech Level 0. Stone Age",
                    ItemWeight = 20
                },
                new TechLevel()
                {
                    Description = "Tech Level 1. Medieval",
                    ItemWeight = 15
                },
                new TechLevel()
                {
                    Description = "Tech Level 2. Nineteenth-century",
                    ItemWeight = 15
                },
                new TechLevel()
                {
                    Description = "Tech Level 3. Twentieth-century",
                    ItemWeight = 10
                },
                new TechLevel()
                {
                    Description = "Tech Level 4. Baseline postech",
                    ItemWeight = 10
                },
                new TechLevel()
                {
                    Description = "Tech Level 4 with specialties or some surviving pretech.",
                    ItemWeight = 20
                },
                new TechLevel()
                {
                    Description = "Tech Level 5. Pretech, pre-Silence tech.",
                    ItemWeight = 5
                }
            };

            return techs;
        }

        public static TechLevel GetRandomPopulation(Random rnd)
        {
            var techs = GetTechLevels().Select(x => (IWeightedItem)x).ToList();
            
            return (TechLevel)techs.GetRandomWeightedItem(rnd);
        }
    }


}
