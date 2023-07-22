using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneController : MonoBehaviour
{
    #region Variables for General
    private GameManager gameManager;
    #endregion

    private void Awake()
    {
        ObjectManager.SceneController = this;
    }

    void Start()
    {
        gameManager = ObjectManager.GameManager;
        print(SceneManager.GetActiveScene().buildIndex);
        print(SceneManager.sceneCountInBuildSettings);
    }

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void StopBehindGame()
    {
        DOTween.PauseAll();
        DOTween.KillAll();
        StopAllCoroutines();
    }

}
