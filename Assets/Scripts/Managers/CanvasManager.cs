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
        StartCoroutine(WaitOpenFailPanel());
    }

    public void CloseFailPanel()
    {
        failPanel.SetActive(false);
        failPanel.transform.localScale = Vector3.zero;
    }

    private IEnumerator WaitOpenFailPanel()
    {
        yield return new WaitForSeconds(0.5f);
        failPanel.SetActive(true);

    }
}
