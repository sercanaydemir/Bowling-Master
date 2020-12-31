using UnityEngine;

namespace GameFolders.Scripts.Concrete.Inputs
{
    public class InputManager 
    {
        public bool MouseButtonDown => Input.GetMouseButtonDown(0);
        public bool MouseButton => Input.GetMouseButton(0);
        public bool MouseButtonUp => Input.GetMouseButtonUp(0);
    }
}