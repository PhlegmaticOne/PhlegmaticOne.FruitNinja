using System;
using UnityEngine;

namespace Configurations.Base
{
    [Serializable]
    public class MinMaxInfo<T>
    {
        [SerializeField] private T _min;
        [SerializeField] private T _max;

        public T Min => _min;
        public T Max => _max;
    }
}