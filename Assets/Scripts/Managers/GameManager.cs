using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> cars = new List<GameObject>();
    public bool isCanStart,isGameStart;

    private void Awake()
    {
        ObjectManager.GameManager = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCanStart&&Input.GetMouseButtonDown(0))
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
}
