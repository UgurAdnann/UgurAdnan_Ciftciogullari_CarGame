using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerClass : MonoBehaviour
{
    #region Variables for General
    [HideInInspector] public GameManager gameManager;
    #endregion

    #region Variables for Movement
    public PlayerType playerType;
     public bool isMove;
    #endregion

    #region Variables for Path
    Coroutine lastRoutine = null;
    public List<Vector2> pathList = new List<Vector2>();
    public bool isSetPath;
    public Vector3[] pathPoints;
    #endregion

    public void SetStartEvent()
    {
        gameManager = ObjectManager.GameManager;
    }
    public void CreatePath()
    {
        StartCoroutine(WaitCreatePath());
    }

    public void FollowPath()
    {
        transform.DOPath(pathPoints, 6/*Duration*/, PathType.Linear, PathMode.Full3D, 10 /* resolution*/, Color.red).SetEase(Ease.Linear);
    }

    private IEnumerator WaitCreatePath()
    {
        yield return new WaitForSeconds(0.25f);

        if (!gameManager.isGameOver && isMove)
        {
            pathList.Add(transform.position);
            StartCoroutine(WaitCreatePath());

        }
    }

    public void StopPathNumarator()
    {
        lastRoutine = StartCoroutine(WaitCreatePath());
        StopCoroutine(lastRoutine);
    }
}


