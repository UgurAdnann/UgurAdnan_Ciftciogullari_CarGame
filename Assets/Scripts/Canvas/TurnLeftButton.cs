using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLeftButton : TurnButtons
{
    void Update()
    {
        if (isTurning)
            playerPlayable.TurnLeft();
    }
}
