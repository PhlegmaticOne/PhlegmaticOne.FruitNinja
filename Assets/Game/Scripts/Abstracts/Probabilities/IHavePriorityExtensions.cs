using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Abstracts.Probabilities
{
    public static class IHavePriorityExtensions
    {
        public static T GetRandomItemBasedOnProbabilities<T>(this List<T> items) where T : IHavePriority
        {
            var prioritiesSum = items.Sum(x => x.Priority);
            var randomCumulativeProbability = Random.Range(0, prioritiesSum);
            var cumulativeSum = 0f;
            
            foreach (var spawnerInfo in items)
            {
                cumulativeSum += spawnerInfo.Priority;
                if (randomCumulativeProbability < cumulativeSum)
                {
                    return spawnerInfo;
                }
            }

            return items.Last();
        }
    }
}