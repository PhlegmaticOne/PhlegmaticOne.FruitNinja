using System;
using System.Collections.Generic;
using Configurations;
using Configurations.Blocks;
using Entities.Base;
using UnityEngine;

namespace Entities
{
    public class MetamorphicBlock : Block
    {
        [SerializeField] private MetamorphicBlockConfiguration _metamorphicBlockConfiguration;
        [SerializeField] private ParticleSystem _particleSystem;
        public override IBlockConfiguration BlockConfiguration => _metamorphicBlockConfiguration;
        
        public Block CurrentlyMorphedTo { get; private set; }

        private void Start()
        {
            var particle = _particleSystem.main;
            particle.duration = TransformPeriod;
            particle.startLifetime = TransformPeriod;
            _particleSystem.Play();
        }

        public void MorphTo(Block block)
        {
            if (CurrentlyMorphedTo != null)
            {
                CurrentlyMorphedTo.PermanentDestroy();    
            }
            
            CurrentlyMorphedTo = block;
        }

        public void Stop() => _particleSystem.Stop();

        private void LateUpdate()
        {
            if (CurrentlyMorphedTo != null)
            {
                transform.position = CurrentlyMorphedTo.transform.position;
            }
        }

        public List<BlockInfo> CanTransformTo => _metamorphicBlockConfiguration.CanTransformTo;
        public float TransformPeriod => _metamorphicBlockConfiguration.TransformPeriod;
    }
}