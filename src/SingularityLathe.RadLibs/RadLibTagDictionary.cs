using System.Collections.Generic;

namespace SingularityLathe.RadLibs
{
    public class RadLibTagDictionary
    {
        public string Name { get; set; }
        public string Tag => $"{Name}";
        public List<string> Values { get; set; } = new List<string>();
    }
}
