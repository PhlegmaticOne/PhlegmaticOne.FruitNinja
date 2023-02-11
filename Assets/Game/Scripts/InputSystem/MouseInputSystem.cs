using UnityEngine;

namespace InputSystem
{
    public class MouseInputSystem : IInputSystem
    {
        public InputData ReadInput()
        {
            var position = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                return new InputData(position, InputState.Started, true);
            }

            if (Input.GetMouseButtonUp(0))
            {
                return new InputData(position, InputState.Ended, true);
            }

            if (Input.GetMouseButton(0))
            {
                return new InputData(position, InputState.Active, true);
            }

            return new InputData(position, InputState.None, false);
        }
    }
}