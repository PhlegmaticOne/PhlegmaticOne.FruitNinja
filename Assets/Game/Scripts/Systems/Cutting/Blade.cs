﻿using UnityEngine;

namespace Systems.Cutting
{
    public class Blade : MonoBehaviour
    {
        [SerializeField] private TrailRenderer _trailRenderer;
        public bool IsSlicing { get; private set; }

        public void StartSlicing(Vector3 slicePoint)
        {
            SliceTo(slicePoint);
            _trailRenderer.enabled = true;
            _trailRenderer.Clear();
            IsSlicing = true;
        }

        public Vector3 SliceTo(Vector3 newPosition)
        {
            var direction = newPosition - transform.position;
            transform.position = newPosition;
            return direction;
        }

        public void EndSlicing()
        {
            _trailRenderer.enabled = false;
            _trailRenderer.Clear();
            IsSlicing = false;
        }
    }
}