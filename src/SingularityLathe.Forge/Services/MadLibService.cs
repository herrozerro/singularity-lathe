using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SingularityLathe.Forge.Services
{
    public class MadLibService
    {
        private readonly Random rnd;
        public List<MadLib> madLibs { get; set; } = new List<MadLib>();
        
        public string ProcessMadLib(string template)
        {
            var regex = new Regex(@"\[\[.*?\]\]");

            var matches = regex.Matches(template);

            foreach (Match m in matches)
            {
                var replacer = new Regex(m.Value);

                string replace = "";

                var madlib = madLibs.FirstOrDefault(x => x.Tag == m.Value);

                if (madlib == null)
                {
                    continue;
                }

                replace = madlib.Values[rnd.Next(madlib.Values.Count)];

                template = regex.Replace(template, replace, 1);
            }

            return template;
        }

        public MadLibService(Random rnd)
        {
            this.rnd = rnd;
        }
    }

    public class MadLib
    {
        public string Name { get; set; }
        public string Tag => $"[[{Name}]]";
        public List<string> Values { get; set; } = new List<string>();
    }
}
