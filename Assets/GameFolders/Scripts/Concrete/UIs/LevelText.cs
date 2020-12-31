using System;
using GameFolders.Scripts.Concrete.Managers;
using TMPro;
using UnityEngine;

namespace GameFolders.Scripts.Concrete.UIs
{
    public class LevelText : MonoBehaviour
    {
        private TextMeshProUGUI _levelText;

        private void Awake()
        {
            _levelText = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            _levelText.text = $"Level: {GameManager.Instance.Level}";
        }
    }
}