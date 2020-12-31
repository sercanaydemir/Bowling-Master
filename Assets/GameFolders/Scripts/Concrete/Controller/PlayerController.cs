using System;
using GameFolders.Scripts.Concrete.Inputs;
using GameFolders.Scripts.Concrete.Managers;
using GameFolders.Scripts.Concrete.Movement;
using GameFolders.Scripts.Concrete.UIs;
using UnityEngine;

namespace GameFolders.Scripts.Concrete.Controller
{
    public class PlayerController : MonoBehaviour
    {
        private InputManager _input;
        private Rigidbody _rb;
        private ArrowController _arrow;
        private Mover _mover;
        private GameCanvas _gameCanvas;

        public bool LevelWin { get; private set; }
        void Awake()
        {
            _input = new InputManager();
            _rb = GetComponent<Rigidbody>();
            _arrow = GetComponent<ArrowController>();
            _mover = GetComponent<Mover>();
            _gameCanvas = FindObjectOfType<GameCanvas>();
        }

        private void Update()
        {
            _mover.MoveDirection(_input,_arrow,_rb);

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "GameEnd")
            {
                _gameCanvas.PanelTrigger(LevelWin);
            }

            if (other.gameObject.tag == "Win")
            {
                LevelWin = true;
                _gameCanvas.PanelTrigger(LevelWin);
            }
        }
    }
}