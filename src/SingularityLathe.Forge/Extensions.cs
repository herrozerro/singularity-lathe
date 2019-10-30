using SingularityLathe.Forge.Interfaces;
using System;
using System.Collections.Generic;
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
                for (int i = 0; i < item.ItemWeight; i++)
                {
                    weightedList.Add(item);
                }
            }

            return weightedList[rnd.Next(weightedList.Count)];
        }
    }
}
