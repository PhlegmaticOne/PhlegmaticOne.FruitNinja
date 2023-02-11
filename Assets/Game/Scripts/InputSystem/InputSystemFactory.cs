using UnityEngine;

namespace InputSystem
{
    public class InputSystemFactory : IInputSystemFactory
    {
        public IInputSystem CreateInput()
        {
            IInputSystem inputSystem = null;

            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                {
                    inputSystem = new TouchInputSystem();
                    break;
                }
                default:
                {
                    inputSystem = new MouseInputSystem();
                    break;
                }
            }
            
            return inputSystem;
        }
    }
}