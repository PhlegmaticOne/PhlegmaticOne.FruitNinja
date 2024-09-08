using System;
using System.Collections.Generic;

namespace Abstracts.Extensions
{
    public static class ListExtensions
    {
        private static Random rng = new Random();  

        public static List<T> Shuffle<T>(this List<T> list)  
        {  
            var n = list.Count;  
            while (n > 1) 
            {  
                n--;  
                var k = rng.Next(n + 1);  
                (list[k], list[n]) = (list[n], list[k]);
            }

            return list;
        }

        public static T RandomItem<T>(this List<T> list)
        {
            var index = rng.Next(0, list.Count);
            return list[index];
        }
    }
}