using System;
using UnityEngine;

namespace GameFolders.Scripts.Concrete.Controller
{
    public class CameraFolllower : MonoBehaviour
    {
        private Transform _player;
        private Vector3 _offset;

        [SerializeField] private float lerpMultiply=0.5f;
        private void Awake()
        {
            _player = FindObjectOfType<PlayerController>().transform;
        }

        private void Start()
        {
            _offset = transform.position - _player.position;
            lerpMultiply = 3f;
        }

        private void LateUpdate()
        {
            if (Vector3.Distance(transform.position, _player.position + _offset) > 0.1f && _player.position.y>-5f)
            {
                transform.position = Vector3.Lerp(transform.position, _player.position + _offset, lerpMultiply*Time.deltaTime);
            }
            transform.LookAt(_player);
        }
    }
}