using SingularityLathe.Forge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingularityLathe.Forge
{
    public static class Extensions
    {
        public static IWeightedItem GetRandomWeightedItem(this IEnumerable<IWeightedItem> weightedItems, Random rnd)
        {
            var weightedList = new List<IWeightedItem>();

            foreach (var item in weightedItems)
            {
                for (int i = 1; i < item.ItemWeight; i++)
                {
                    weightedList.Add(item);
                }
            }

            return weightedList[rnd.Next(weightedList.Count)];
        }

        public static Enum GetRandomEnumValue(this Type t, Random rnd)
        {
            var e = Enum.GetValues(t)
                .OfType<Enum>().ToList();

            var enu = e[rnd.Next(e.Count())];

            return enu;
        }
    }
}
