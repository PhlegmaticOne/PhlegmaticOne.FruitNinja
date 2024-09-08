using System;
using System.Collections;
using Abstracts.Stages;
using TMPro;
using UnityEngine;

namespace Helpers
{
    public class Timer : MonoBehaviour, IStageable
    {
        private const string TimeFormat = @"mm\:ss";
        private Coroutine _timerCoroutine;
        [SerializeField] private TextMeshProUGUI _textMeshPro;

        public void StartTimer(int seconds)
        {
            if (_timerCoroutine != null)
            {
                StopCoroutine(_timerCoroutine);
            }
            
            gameObject.SetActive(true);
            _timerCoroutine = StartCoroutine(UpdateTimer(seconds));
        }

        private IEnumerator UpdateTimer(int seconds)
        {
            while (seconds > 0)
            {
                var time = TimeSpan.FromSeconds(seconds);
                _textMeshPro.text = time.ToString(TimeFormat);
                seconds--;
                yield return new WaitForSeconds(1);
            }

            _textMeshPro.text = string.Empty;
            gameObject.SetActive(false);
            _timerCoroutine = null;
        }

        public void Enable() { }

        public void Disable()
        {
            if (_timerCoroutine != null)
            {
                StopCoroutine(_timerCoroutine);
            }
        }
    }
}