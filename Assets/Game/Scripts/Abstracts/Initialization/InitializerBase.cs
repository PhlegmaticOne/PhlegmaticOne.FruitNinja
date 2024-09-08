using UnityEngine;

namespace Abstracts.Initialization
{
    public abstract class InitializerBase<T> : MonoBehaviour
    {
        public abstract T Create();
    }
}