using System;
using System.Collections.Generic;
using UnityEngine;

namespace Positioning
{
    public class LeftRightAnchor : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private List<Transform> _transforms;
        [SerializeField] private float _marginFromScreen = 1f;
        private void Start()
        {
            var width = _mainCamera.orthographicSize * _mainCamera.aspect;

            foreach (var t in _transforms)
            {
                var posX = t.position.x < 0 ? -width - _marginFromScreen : width + _marginFromScreen;
                var position = t.position;
                t.position = new Vector3(posX, position.y, position.z);
            }
        }
    }
}