using TMPro;
using UnityEngine;

namespace Helpers
{
    public class AppendTextMeshPro : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        [SerializeField] private bool _appendToStart;
        [SerializeField] private string _preString;

        public void SetText(string value, bool addSpaceBetweenStrings = true)
        {
            var space = addSpaceBetweenStrings ? " " : string.Empty;
            _textMeshPro.text = _appendToStart ?
                value + space + _preString :
                _preString + space + value;
        }
    }
}