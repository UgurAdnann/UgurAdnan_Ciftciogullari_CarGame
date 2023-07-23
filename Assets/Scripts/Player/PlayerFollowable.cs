using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowable : PlayerClass
{
    #region Variables for Rot
    private float previousXPos, previousYPos;
    private float nextXPos, nextYPos;
    public float rotateSpeed;
    #endregion

    void Start()
    {
        SetStartEvent();
    }

    void Update()
    {
        if (isMove)
        {
            if (!isSetPath)
            {
                SetPath();
                PathFollowing();
                isSetPath = true;
            }
            SetRot();
        }
    }

    private void SetPath()
    {
        if (pathPoints.Length == 0)
        {
            pathPoints = new Vector3[pathList.Count];

            for (int i = 0; i < pathList.Count; i++)
            {
                pathPoints[i] = pathList[i];
            }
        }
    }

    private void PathFollowing()
    {
        FollowPath();
    }

    private void SetRot()
    {
        previousXPos = transform.position.x;
        previousYPos = transform.position.y;

        transform.up = Vector3.Lerp(transform.up, new Vector3(previousXPos - nextXPos, previousYPos - nextYPos, 0), rotateSpeed);

        nextXPos = transform.position.x;
        nextYPos = transform.position.y;
    }

}
