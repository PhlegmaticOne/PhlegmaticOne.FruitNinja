using UnityEngine;

namespace Abstracts.Commands
{
    public interface IOnDestroyCommand<in TEntity, in TContext>
        where TEntity : MonoBehaviour
        where TContext : IDestroyContext
    {
        void OnDestroy(TEntity entity, TContext destroyContext);
    }
    
    public interface IDestroyContext { }
}