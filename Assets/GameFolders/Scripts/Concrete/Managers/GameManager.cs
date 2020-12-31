using System;
using System.Collections;
using GameFolders.Scripts.Concrete.UIs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFolders.Scripts.Concrete.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        [SerializeField] private int _score;
        
        private GameCanvas _gameCanvas;
        private int _level;

        public int Level => _level;
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }
        
        private void Awake()
        {
            MakeInstance();

            _level = PlayerPrefs.GetInt("Level");
            
            _level = _level == 0 ? _level = 1 : _level;
        }

        private void Start()
        {
            int currentLevel = _level - 1;
            LevelChange(currentLevel);
        }

        void MakeInstance()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void Next()
        {
            _level++;
            int currentLevel = _level - 1;
            PlayerPrefs.SetInt("Level",_level);
            LevelChange(currentLevel);
            
        }

        public void Reply(int level=0)
        {
            int currentLevel = _level;
            StartCoroutine(OnLoadAsync(level));
        }

        IEnumerator OnLoadAsync(int level)
        {
            yield return _score = 0;
            yield return SceneManager.LoadSceneAsync(level);

        }

        private void LevelChange(int currentLevel)
        {
            if (currentLevel < 3)
            {
                StartCoroutine(OnLoadAsync(currentLevel));
            }
            else
            {
                int random = UnityEngine.Random.Range(0, 3);
                StartCoroutine(OnLoadAsync(random));
            }
        }

        
    }
}