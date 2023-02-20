using System.Collections;
using TMPro;
using UnityEngine;

namespace Helpers
{
    public class Timer : MonoBehaviour
    {
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
                var minutes = seconds / 60;
                var sec = seconds % 60;
                
                _textMeshPro.text = ToTime(minutes, sec);
                seconds--;
                yield return new WaitForSeconds(1);
            }

            _textMeshPro.text = string.Empty;
            gameObject.SetActive(false);
        }

        private static string ToTime(int minutes, int seconds) => FormatTime(minutes) + ":" + FormatTime(seconds);

        private static string FormatTime(int time) => time <= 9 ? "0" + time : time.ToString();
    }
}