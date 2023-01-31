namespace Entities.Base
{
    public class CuttableBlock : Block
    {
        public bool IsCutted { get; private set; }

        public void Cut()
        {
            if (IsCutted == false)
            {
                IsCutted = true;
            }
        }
    }
}