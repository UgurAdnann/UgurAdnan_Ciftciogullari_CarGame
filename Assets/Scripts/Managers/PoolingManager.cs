using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    #region Variables for Gold Fx
    public GameObject goldFxPrefab;
    private readonly Queue<GameObject> goldFxQue = new Queue<GameObject>();
    public int goldFxNum;
    private GameObject tempGoldFx;
    #endregion

    #region Variables for Crash Fx
    public GameObject crashFxPrefab;
    private readonly Queue<GameObject> crashFxQue = new Queue<GameObject>();
    public int crashFxNum;
    private GameObject tempCrashFx;
    #endregion

    private void Awake()
    {
        ObjectManager.PoolingManager = this;
    }
    void Start()
    {
        CreateGoldFxQue();
        CreateCrashFxQue();
    }

    #region GoldFx
    private void CreateGoldFxQue()
    {
        for (int i = 0; i < goldFxNum; i++)
        {
            tempGoldFx = Instantiate(goldFxPrefab);
            tempGoldFx.transform.SetParent(transform.GetChild(0));
            tempGoldFx.transform.localPosition = Vector3.zero;
            goldFxQue.Enqueue(tempGoldFx);
        }
    }

    public void UseGoldFx(Vector2 target)
    {
        //Ýf there are no fx, create
        if (goldFxQue.Count == 0)
            CreateGoldFxQue();

        else
        {
            tempGoldFx = goldFxQue.Dequeue();
            tempGoldFx.transform.position = target;
            tempGoldFx.SetActive(true);
            tempGoldFx.GetComponent<FxController>().CloseObject();
        }
    }

    public void CloseGoldFx(GameObject go)
    {
        go.transform.position = Vector3.zero;
        go.SetActive(false);
        goldFxQue.Enqueue(go);
    }

    #endregion

    #region CrashFx
    private void CreateCrashFxQue()
    {
        for (int i = 0; i < crashFxNum; i++)
        {
            tempCrashFx = Instantiate(crashFxPrefab);
            tempCrashFx.transform.SetParent(transform.GetChild(1));
            tempCrashFx.transform.localPosition = Vector3.zero;
            crashFxQue.Enqueue(tempCrashFx);
        }
    }

    public void UseCrashFx(Vector2 target)
    {
        //Ýf there are no fx, create
        if (crashFxQue.Count == 0)
            CreateCrashFxQue();

        else
        {
            tempCrashFx = crashFxQue.Dequeue();
            tempCrashFx.transform.position = target;
            tempCrashFx.SetActive(true);
            tempCrashFx.GetComponent<FxController>().CloseObject();
        }
    }

    public void CloseCrashFx(GameObject go)
    {
        go.transform.position = Vector3.zero;
        go.SetActive(false);
        crashFxQue.Enqueue(go);
    }
    #endregion
}
