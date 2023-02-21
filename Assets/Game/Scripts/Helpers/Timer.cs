using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Helpers
{
    public class Timer : MonoBehaviour
    {
        private const string TimeFormat = @"mm\:ss";
        [SerializeField] private TextMeshProUGUI _textMeshPro;

        public void StartTimer(int seconds)
        {
            gameObject.SetActive(true);
            StartCoroutine(UpdateTimer(seconds));
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
        }
    }
}