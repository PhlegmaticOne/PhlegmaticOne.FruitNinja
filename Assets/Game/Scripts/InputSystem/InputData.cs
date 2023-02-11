using UnityEngine;

namespace InputSystem
{
    public class InputData
    {
        public InputData(Vector3 position, InputState inputState, bool isValid)
        {
            Position = position;
            InputState = inputState;
            IsValid = isValid;
        }

        public Vector3 Position { get; }
        public InputState InputState { get; }
        public bool IsValid { get; }
    }

    public enum InputState
    {
        None,
        Started,
        Ended,
        Active
    }
}