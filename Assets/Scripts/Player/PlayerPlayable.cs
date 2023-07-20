using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlayable : PlayerClass
{
    #region Variables for General
    private GameManager gameManager;
    #endregion

    #region Variables for Movement
    public float forwardSpeed, rotateSpeed;
    #endregion

    #region Variables for Collision
    private bool isCrashed,isNextStage;
    #endregion

    private void Awake()
    {
        ObjectManager.PlayerPlayable = this;
    }

    private void Start()
    {
        gameManager = ObjectManager.GameManager;
    }

    void Update()
    {
        if (isMove)
            InputManager();
    }

    #region Variables for Movement

    #region Forward Movement
    private void InputManager()
    {
        transform.Translate(transform.up * forwardSpeed * Time.deltaTime, Space.World);
    }
    #endregion

    #region Turning Movements
    public void TurnRight()
    {
        transform.Rotate(-Vector3.forward * rotateSpeed * Time.deltaTime);
    }
    public void TurnLeft()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
    #endregion

    #endregion

    #region Collision Events
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            if (!isCrashed)
            {
                isCrashed = true;
                gameManager.StopAllCars();
                EventManager.OpenFailpanel();
            }
        }

        if (collision.CompareTag("Target"))
        {
            if (!isNextStage)
            {
                isNextStage = true;
                Time.timeScale = 0;
                print("Next Stage");

            }
        }

        if (collision.CompareTag("Gold"))
        {
            collision.gameObject.SetActive(false);
            print("Gold");
        }
    }
    #endregion

}
