using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnButtons : MonoBehaviour
{
    #region Variables for Turn Player
    [HideInInspector] public PlayerPlayable playerPlayable;
    [HideInInspector] public bool isClick, isTurning, isEnter;
    #endregion

    public void Start()
    {
        playerPlayable = ObjectManager.PlayerPlayable;
    }

    #region Mouse Events
    public void PointerDown()
    {
        isClick = true;
        if (isEnter)
        {
            if (playerPlayable == null)
                playerPlayable = ObjectManager.PlayerPlayable;

            isTurning = true;
        }
    }

    public void PointerEnter()
    {
        isEnter = true;
    }

    public void PointerExit()
    {
        isTurning = false;
        isEnter = false;
    }

    public void PointerUp()
    {
        isClick = false;
        isTurning = false;
    }
    #endregion

}
