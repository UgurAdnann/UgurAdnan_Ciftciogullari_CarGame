using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRightButton : TurnButtons
{
    void Update()
    {
        if (isTurning)
            playerPlayable.TurnRight();
    }
}
