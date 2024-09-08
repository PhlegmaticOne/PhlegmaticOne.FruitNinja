using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Systems.Magnet
{
    public class MagnetWaves : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private float _scaleTime = 1f;
        [SerializeField] private float _scale = 1.05f;

        private float _baseScale;

        public void Show(Vector3 position, float radius)
        {
            gameObject.SetActive(true);
            _spriteRenderer.enabled = true;
            _spriteRenderer.transform.position = position;
            _baseScale = transform.localScale.x;
            _spriteRenderer.transform.localScale *= radius; 
            _spriteRenderer.transform
                .DOScale(transform.localScale * _scale, _scaleTime)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.Linear);
        }

        public void DrawLines(Vector3 center, List<Vector3> positions)
        {
            _lineRenderer.positionCount = positions.Count * 2;
            var result = new List<Vector3>();
            foreach (var position in positions)
            {
                result.Add(center);
                result.Add(position);
            }
            _lineRenderer.SetPositions(result.ToArray());
        }

        public void Hide()
        {
            _spriteRenderer.transform.DOKill();
            _spriteRenderer.enabled = false;
            _lineRenderer.positionCount = 0;
            _spriteRenderer.transform.localScale = new Vector3(_baseScale, _baseScale, 1);
            gameObject.SetActive(false);
        }
    }
}