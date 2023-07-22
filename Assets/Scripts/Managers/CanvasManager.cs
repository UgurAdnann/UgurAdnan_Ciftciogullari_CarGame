using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    #region Variables for General
    private GameManager gameManager;
    #endregion

    #region Variables for UI
    public GameObject failPanel, winPanel;
    public TMPro.TextMeshProUGUI goldText;
    #endregion

    private void OnEnable()
    {
        EventManager.OpenEndpanel += OpenEndPanel;
        EventManager.CloseEndpanel += CloseEndPanel;
    }

    private void OnDisable()
    {
        EventManager.OpenEndpanel -= OpenEndPanel;
        EventManager.CloseEndpanel -= CloseEndPanel;
    }

    private void Start()
    {
        gameManager = ObjectManager.GameManager;
    }


    #region EndPanel Events
    private void OpenEndPanel()
    {
        StartCoroutine(WaitOpenEndPanel());
    }

    private void CloseEndPanel()
    {
        if (gameManager.isWin)
        {
            winPanel.SetActive(false);
            winPanel.transform.localScale = Vector3.zero;
        }
        else
        {
            failPanel.SetActive(false);
            failPanel.transform.localScale = Vector3.zero;
        }
    }

    private IEnumerator WaitOpenEndPanel()
    {
        yield return new WaitForSeconds(0.5f);
        if (gameManager.isWin)
        {
            SetGoldText();
            winPanel.SetActive(true);
        }
        else
            failPanel.SetActive(true);
    }
    #endregion

    private void SetGoldText()
    {
        goldText.text = gameManager.totalGold.ToString();
    }
}
