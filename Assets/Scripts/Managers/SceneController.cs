using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneController : MonoBehaviour
{

    private void Awake()
    {
        ObjectManager.SceneController = this;
    }


    public void NextLevel()
    {
        StopBehindGame();
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadLevel()
    {
        StopBehindGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void StopBehindGame()
    {
        DOTween.PauseAll();
        DOTween.KillAll();
        StopAllCoroutines();
    }

}
