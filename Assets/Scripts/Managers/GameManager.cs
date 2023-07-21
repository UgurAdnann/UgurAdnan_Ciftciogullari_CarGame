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
    public  List<Vector2> lastPathList;
    private GameObject tempCar;
    private PlayerPlayable playerClass;
    #endregion

    #region variables for Level State
    public bool isCanStart,isGameStart,isGameOver;
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
        if (Input.GetKeyDown(KeyCode.Space))
            NextStage();
    }

    #region Cars Event
    private void StartAllCars()
    {
        if (isCanStart && Input.GetMouseButtonDown(0))
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
    }
    #endregion

    #region Level End Events
    public void NextStage()
    {
        levelGenerator.playerCounter++;
        isGameOver = true;

        StopAllCars();
        DOTween.KillAll();

        tempCar = cars[cars.Count - 1];
        playerClass = tempCar.GetComponent<PlayerPlayable>();
        cars.Remove(tempCar);

        for (int i = 0; i < cars.Count; i++)
        {
            cars[i].transform.position = levelGenerator.playerPoses[i].startPos;
            cars[i].transform.rotation = levelGenerator.playerPoses[i].rot;
            cars[i].GetComponent<PlayerFollowable>().isSetPath = false;
        }

        levelGenerator.SetLastPlayer();


        SetCurrentCarSettings();
        ResetGameSettings();


        isCanStart = true;
    }

    private void ResetGameSettings()
    {
        isCanStart = false;
        isGameStart = false;
        isGameOver = false;
        lastPathList.Clear();
    }

    private void SetCurrentCarSettings()
    {
        playerClass.isSetPath = false;
        playerClass.pathList.Clear();

        playerClass.StopPathNumarator();


        playerClass.isCrashed = false;
        playerClass.isNextStage = false;
        playerClass.isMove = false;

        tempCar.transform.position = levelGenerator.playerPoses[levelGenerator.playerCounter].startPos;
        tempCar.transform.rotation = levelGenerator.playerPoses[levelGenerator.playerCounter].rot;

        cars.Add(tempCar);

        levelGenerator.SetTarget();
    }

    public void NextLevel()
    {
        //SceneManager
    }
    #endregion
}
