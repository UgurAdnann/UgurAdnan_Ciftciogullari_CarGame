using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject failPanel;

    private void OnEnable()
    {
        EventManager.OpenFailpanel += OpenFailPanel;
        EventManager.CloseFailpanel += CloseFailPanel;
    }

    private void OnDisable()
    {
        EventManager.OpenFailpanel -= OpenFailPanel;
        EventManager.CloseFailpanel -= CloseFailPanel;
    }

    public void OpenFailPanel()
    {
        failPanel.SetActive(true);
    }

    public void CloseFailPanel()
    {
        failPanel.SetActive(false);
        failPanel.transform.localScale = Vector3.zero;
    }
}
