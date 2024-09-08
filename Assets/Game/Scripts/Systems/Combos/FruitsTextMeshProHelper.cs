using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace Systems.Combos
{
    public class FruitsTextMeshProHelper : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        private readonly string BaseText = "фрукт";
        private const string OvEnding = "ов";
        private const string AEnding = "а";
        private const string EmptyEnding = "";

        private readonly Dictionary<int, string> _endings = new Dictionary<int, string>()
        {
            { 0, OvEnding },
            { 1, EmptyEnding },
            { 2, AEnding },
            { 3, AEnding },
            { 4, AEnding },
            { 5, OvEnding },
            { 6, OvEnding },
            { 7, OvEnding },
            { 8, OvEnding },
            { 9, OvEnding },
        };

        public void SetCombosCount(int combosCount)
        {
            var baseString = new StringBuilder(BaseText);

            baseString.Append(Between10And20(combosCount % 100) ? OvEnding : _endings[combosCount % 10]);

            _textMeshPro.text = combosCount + baseString.ToString();
        }

        private static bool Between10And20(int value) => value >= 11 && value <= 19;
    }
}