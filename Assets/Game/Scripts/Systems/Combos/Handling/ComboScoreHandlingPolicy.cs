namespace Systems.Combos.Handling
{
    public class ComboScoreHandlingPolicy : IComboScoreHandlingPolicy
    {
        public int GetScoreFromPositionInCombo(int score, int comboNumber)
        {
            return score * comboNumber;
        }
    }
}