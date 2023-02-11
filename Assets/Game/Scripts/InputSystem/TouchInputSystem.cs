using System;
using UnityEngine;

namespace InputSystem
{
    public class TouchInputSystem : IInputSystem
    {
        public InputData ReadInput()
        {
            try
            {
                var touch = Input.GetTouch(0);

                var state = InputState.Active;

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        state = InputState.Started;
                        break;
                    case TouchPhase.Moved:
                        state = InputState.Active;
                        break;
                    case TouchPhase.Ended:
                        state = InputState.Ended;
                        break;
                }

                var isValid = Input.touchCount <= 1;
            
                return new InputData(touch.position, state, isValid);
            }
            catch (Exception)
            {
                return new InputData(Vector3.zero, InputState.None, false);
            }
        }
    }
}