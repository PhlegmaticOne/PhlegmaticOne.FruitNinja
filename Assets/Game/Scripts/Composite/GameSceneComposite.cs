using System.Collections.Generic;
using Composite.Base;
using Initialization.Stages;
using UnityEngine;

namespace Composite
{
    public class GameSceneComposite : MonoBehaviour
    {
        [SerializeField] private List<CompositeInitializer> _initializers;
        [SerializeField] private StageablesAccessor _stageablesAccessor;
        
        private void Awake()
        {
            foreach (var compositeInitializer in _initializers)
            {
                compositeInitializer.Initialize();
            }
        }

        private void Start()
        {
            foreach (var stageable in _stageablesAccessor.GetStageables())
            {
                stageable.Enable();
            }
        }
    }
}