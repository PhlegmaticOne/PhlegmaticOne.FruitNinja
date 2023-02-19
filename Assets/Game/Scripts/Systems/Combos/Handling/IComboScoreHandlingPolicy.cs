namespace Systems.Combos.Handling
{
    public interface IComboScoreHandlingPolicy
    {
        int GetScoreFromPositionInCombo(int score, int comboNumber);
    }
}