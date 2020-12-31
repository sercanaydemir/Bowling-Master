using System;
using System.Collections;
using TMPro;
using GameFolders.Scripts.Concrete.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concrete.UIs
{
    public class Score : MonoBehaviour
    {
        private TextMeshProUGUI _scoreText;
        private int _score;
        private int _currentScore;
        private void Awake()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
            StartCoroutine(ScoreCounter(GameManager.Instance.Score));
        }
        

        IEnumerator ScoreCounter(int score)
        {
            yield return new WaitForSeconds(0.001f);
 
            _currentScore++;
            
            if (score >= _currentScore )
            {
                Debug.Log("Work");
                _scoreText.text = $"Score: {_currentScore.ToString()}";
                StartCoroutine(ScoreCounter(score));
            }
           
        }
    }
}