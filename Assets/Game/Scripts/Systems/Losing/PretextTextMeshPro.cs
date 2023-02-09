using TMPro;
using UnityEngine;

namespace Systems.Losing
{
    public class PretextTextMeshPro : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        [SerializeField] private string _preString;

        public void SetText(string value, bool addSpaceBetweenStrings = true)
        {
            var space = addSpaceBetweenStrings ? " " : string.Empty;
            _textMeshPro.text = _preString + space + value;
        }
    }
}