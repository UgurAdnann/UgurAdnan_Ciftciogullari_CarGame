using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnButtons : MonoBehaviour
{
    [HideInInspector] public PlayerPlayable playerPlayable;
    [HideInInspector] public bool isClick, isTurning,isEnter;

    public void Start()
    {
        playerPlayable = ObjectManager.PlayerPlayable;
    }

    #region Mouse Events
    public void PointerDown()
    {
        print("Down");
        isClick = true;
        if (isEnter)
            isTurning = true;
    }

    public void PointerEnter()
    {
        print("Enter");
        isEnter = true;
    }

   public void PointerExit()
    {
        print("Exit");
        isTurning = false;
        isEnter = false;
    }

    public void PointerUp()
    {
        print("Up");
        isClick = false;
        isTurning = false;
    }
    #endregion

}
