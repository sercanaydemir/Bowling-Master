using UnityEngine;
using GameFolders.Scripts.Concrete.Managers;
namespace GameFolders.Scripts.Concrete.UIs
{
    public class LevelFailedPanel : MonoBehaviour
    {
        
        public void ReplyButtonClick()
        {
            GameManager.Instance.Reply();
        }
    }
}