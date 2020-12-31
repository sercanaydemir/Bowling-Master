using System;
using GameFolders.Scripts.Concrete.Controller;
using GameFolders.Scripts.Concrete.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concrete.Collisions
{
    public class PinCollisions : MonoBehaviour
    {
        private PinController _pinController;

        private bool _isCollision; 
        private void Awake()
        {
            _pinController = FindObjectOfType<PinController>();
        }

        private void OnCollisionEnter(Collision other)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            PinCollisions pin = other.gameObject.GetComponent<PinCollisions>();

            if ((player != null || pin != null) && !_isCollision)
            {
                GameManager.Instance.Score += 10;
                _isCollision = true;
            }
        }
    }
}