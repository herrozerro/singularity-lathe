using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingularityLathe.Web.Services
{
    public class TestService
    {
        public Action OnListCountChanged { get; set; }


        public TestService()
        {

        }

        public List<string> testStrings = new List<string>();

        public void AddListItem(string item)
        {
            testStrings.Add(item);
            OnListCountChanged?.Invoke();
        }
    }
}
