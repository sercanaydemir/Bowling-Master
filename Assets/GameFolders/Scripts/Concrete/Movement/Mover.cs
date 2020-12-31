using GameFolders.Scripts.Concrete.Controller;
using GameFolders.Scripts.Concrete.Inputs;
using UnityEngine;

namespace GameFolders.Scripts.Concrete.Movement
{
    public class Mover : MonoBehaviour
    {   
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float force;
        
        private Vector3 _firstPos;
        private Vector3 _followPos;
        private Vector3 _direction;
        
        private bool _firstTouch;
        
        public void MoveDirection(InputManager input, ArrowController arrow, Rigidbody rb)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (input.MouseButton)
            {
                rb.velocity = Vector3.zero;
                if (!_firstTouch)
                {
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                    {
                        _firstPos = hit.point;
                        _firstTouch = true;
                        arrow.GameObject.SetActive(true);
                    }
                }
                else
                {
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                    {
                        _followPos = hit.point;
                        _direction = _firstPos - _followPos;
                        arrow.RotateArrow(_direction);
                    }
                }
                
            }

            if (input.MouseButtonUp)
            {
                Vector3 Force = _direction*force;
                Force.y = 0;
                rb.AddForce(Force,ForceMode.Impulse);
                
                Vector3 velocity = rb.velocity;
                velocity.y = 0;
                rb.velocity = velocity;
                
                _firstTouch = false;
                
                arrow.ResetScale();
                arrow.GameObject.SetActive(false);
                
                VectorReset();
            }
        }
        void VectorReset()
        {
            _direction = Vector3.zero;
            _firstPos = Vector3.zero;
            _followPos = Vector3.zero;
        }
    }
    
    
}