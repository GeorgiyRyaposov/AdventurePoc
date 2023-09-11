using UnityEngine.InputSystem;

namespace Game.Input.DevicesListeners
{
    public interface IDeviceListener
    {
        void Setup(InputActions inputActions, InputDevice device);
        string GetControlScheme();
    }
}