using System;

namespace SingularityLathe.RadLibs
{
    public sealed class RadLibConfiguration
    {
        /// <summary>
        /// Tag opener pattern, defaults to [[
        /// </summary>
        public string TagOpener { internal get; set; } = "[[";
        
        /// <summary>
        /// Tag closer pattern, defaults to [[
        /// </summary>
        public string TagCloser { internal get; set; } = "]]";

        /// <summary>
        /// Seed for all random interactions, defaults to 0 and will instatiate a new random without a seed
        /// </summary>
        public int RandomSeed { internal get; set; } = 0;

        public RadLibConfiguration()
        {

        }

        public RadLibConfiguration(RadLibConfiguration other)
        {
            this.TagOpener = other.TagOpener;
            this.TagCloser = other.TagCloser;
            this.RandomSeed = other.RandomSeed;
        }
    }
}
