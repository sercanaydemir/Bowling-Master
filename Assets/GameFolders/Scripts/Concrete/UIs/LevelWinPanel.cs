using UnityEngine;
using GameFolders.Scripts.Concrete.Managers;

namespace GameFolders.Scripts.Concrete.UIs
{
    public class LevelWinPanel : MonoBehaviour
    {
        public void NextButtonClick()
        {
            Debug.Log("Clickk");
            GameManager.Instance.Next();
        }
    }
}