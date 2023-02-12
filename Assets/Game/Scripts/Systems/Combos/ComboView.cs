using System.Collections;
using DG.Tweening;
using Helpers;
using UnityEngine;

namespace Systems.Combos
{
    public class ComboView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        
        [SerializeField] private FruitsTextMeshProHelper _fruitsTextMeshProHelper;
        [SerializeField] private AppendTextMeshPro _combosTextMeshPro;
        
        [SerializeField] private float _showTime;

        private Coroutine _fadeCoroutine;

        public void ShowCombo(int combo, Vector3 position)
        {
            transform.position = position;
            SetCombos(combo);

            if (_fadeCoroutine != null)
            {
                StopAnimation();
                _canvasGroup.alpha = 1;
            }
            
            _fadeCoroutine = StartCoroutine(Fade(position));
        }

        public void Hide()
        {
            StopAnimation();
            _canvasGroup.DOFade(0, 0);
        }

        private void StopAnimation()
        {
            StopCoroutine(_fadeCoroutine);
            _canvasGroup.DOKill();
        }

        private IEnumerator Fade(Vector3 position)
        {
            transform.DOMove(position, 0.1f);
            _canvasGroup.alpha = 1;
            yield return new WaitForSeconds(_showTime);
            _canvasGroup.DOFade(0, _showTime);
        }

        private void SetCombos(int combosCount)
        {
            _fruitsTextMeshProHelper.SetCombosCount(combosCount);
            _combosTextMeshPro.SetText(combosCount.ToString());
        }
    }
}