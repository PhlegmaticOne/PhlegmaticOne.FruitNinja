using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Helpers
{
    public class AppendTextMeshPro : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        [SerializeField] private bool _appendToStart;
        [SerializeField] private string _stringToAppend;
        [SerializeField] private bool _addSpaceBetweenString = true;

        public void SetText(string value)
        {
            var space = _addSpaceBetweenString ? " " : string.Empty;
            _textMeshPro.text = _appendToStart ? _stringToAppend + space + value : value + space + _stringToAppend;
        }
    }
}