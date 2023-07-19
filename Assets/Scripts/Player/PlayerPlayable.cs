using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlayable : PlayerClass
{
    #region Variables for Movement
    public float forwardSpeed,rotateSpeed;
    #endregion

    private void Awake()
    {
        ObjectManager.PlayerPlayable = this;
    }

    void Start()
    {

    }

    void Update()
    {
        if (isMove)
            InputManager();
    }

    #region Variables for Movement
    private void InputManager()
    {
        transform.Translate(transform.up * forwardSpeed * Time.deltaTime,Space.World);
    }


    #endregion

    #region Turning Events
    public void TurnRight()
    {
        transform.Rotate(-Vector3.forward * rotateSpeed * Time.deltaTime);
    }
    public void TurnLeft()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
    #endregion
}
