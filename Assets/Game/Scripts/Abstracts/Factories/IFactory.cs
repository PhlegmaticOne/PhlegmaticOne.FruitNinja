﻿using UnityEngine;

namespace Abstracts.Factories
{
    public interface IFactory<in TContext, out TEntity> 
        where TContext : ICreationContext
        where TEntity : MonoBehaviour
    {
        TEntity Create(TContext creationContext);
    }

    public interface IFactory<out T>
    {
        T Create();
    }
    
    public interface ICreationContext { }
}