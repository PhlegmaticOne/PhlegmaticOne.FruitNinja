namespace Systems.Score.Models
{
    public class ScoreModel
    {
        public ScoreModel(int value) => Value = value;
        
        public int Value { get; private set; }
        
        public void AddScore(int score) => Value += score;
    }
}