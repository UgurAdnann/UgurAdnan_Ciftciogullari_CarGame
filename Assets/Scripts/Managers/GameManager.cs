using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    #region Variables for General
    private LevelGenerator levelGenerator;
    #endregion

    #region Variables for Cars
    public List<GameObject> cars = new List<GameObject>();
    public List<Vector2> lastPathList;
    private GameObject tempCar;
    private PlayerPlayable playerPlayable;
    public int totalGold;
    #endregion

    #region variables for Level State
    public bool isCanStart, isGameStart, isGameOver;
    public bool isWin = true;
    public List<GameObject> collectedGolds = new List<GameObject>();
    #endregion

    private void Awake()
    {
        ObjectManager.GameManager = this;
    }

    private void Start()
    {
        levelGenerator = ObjectManager.LevelGenerator;
    }

    void Update()
    {
        StartAllCars();
    }

    #region Cars Event
    private void StartAllCars()
    {
        if (isCanStart && (Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Space)))
        {
            if (!isGameStart)
            {
                foreach (var item in cars)
                {
                    item.GetComponent<PlayerClass>().isMove = true;
                }
                isGameStart = true;
            }
        }
    }

    public void StopAllCars()
    {
        foreach (var item in cars)
        {
            item.GetComponent<PlayerClass>().isMove = false;
        }
        DOTween.KillAll();
    }
    #endregion

    #region Stage End Events
    public void NextStage()
    {
        levelGenerator.playerCounter++;
        isGameOver = true;

        StopAllCars();
        DOTween.KillAll();

        tempCar = cars[^1];
        playerPlayable = tempCar.GetComponent<PlayerPlayable>();
        cars.Remove(tempCar);

        SetCars();

        levelGenerator.SetLastPlayer();

        SetCurrentCarSettings();
        cars.Add(tempCar);
        ResetGameSettings();


        isCanStart = true;
    }

    private void SetCars()
    {
        for (int i = 0; i < cars.Count; i++)
        {
            cars[i].transform.position = levelGenerator.playerPoses[i].startPos;
            cars[i].transform.rotation = levelGenerator.playerPoses[i].rot;
            cars[i].GetComponent<PlayerClass>().isSetPath = false;
        }
    }

    private void ResetGameSettings()
    {
        isCanStart = false;
        isGameStart = false;
        isGameOver = false;
        collectedGolds.Clear();
        lastPathList.Clear();
    }

    private void SetCurrentCarSettings()
    {
        playerPlayable.isSetPath = false;
        playerPlayable.pathList.Clear();

        playerPlayable.StopPathNumarator();

        playerPlayable.isCrashed = false;
        playerPlayable.isNextStage = false;
        playerPlayable.isMove = false;

        tempCar.transform.position = levelGenerator.playerPoses[levelGenerator.playerCounter].startPos;
        tempCar.transform.rotation = levelGenerator.playerPoses[levelGenerator.playerCounter].rot;

        levelGenerator.SetTarget();
    }

    public void TryAgainEvents()
    {
        tempCar = cars[^1];
        playerPlayable = tempCar.GetComponent<PlayerPlayable>();

        //Golds Settings
        totalGold -= collectedGolds.Count;

        SetFailedGolds();
        ResetGameSettings();
        EventManager.CloseEndpanel();
        SetCurrentCarSettings();
        StopAllCars();
        SetCars();
        isCanStart = true;
    }

    private void SetFailedGolds()
    {
        foreach (var item in collectedGolds)
        {
            item.SetActive(true);
        }
    }

    public void LevelEndEvent()
    {
        isWin = true;
        StopAllCars();
        EventManager.OpenEndpanel();
    }
    #endregion


}
