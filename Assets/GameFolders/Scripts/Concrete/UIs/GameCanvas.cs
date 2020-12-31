using System.Collections;
using UnityEngine;
using GameFolders.Scripts.Concrete.UIs;
namespace GameFolders.Scripts.Concrete.UIs
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject levelWinPanel;
        [SerializeField] private GameObject levelFailedPanel;

        public void PanelTrigger(bool isWin)
        {
            StartCoroutine(PaneOnEnable(isWin));
        }

        IEnumerator PaneOnEnable(bool isWin)
        {
            yield return new WaitForSeconds(3f);

            if (isWin)
            {
                levelWinPanel.gameObject.SetActive(true);
            }
            else
            {
                levelFailedPanel.gameObject.SetActive(true);
            }
        }
        
    }
}