using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingularityLathe.Web.Models.Interfaces
{
    public interface IStellarBody
    {
        string Name { get; set; }
        int OrbitOrder { get; set; }
        StellarBodyType stellarBodyType { get; }
        IEnumerable<IStellarBody> ChildBodies { get; set; }
    }
}
