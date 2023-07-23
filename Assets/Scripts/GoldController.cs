using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldController : MonoBehaviour
{
    #region Variables for General
    private PoolingManager poolingManager;
    private GameManager gameManager;
    #endregion

    void Start()
    {
        poolingManager = ObjectManager.PoolingManager;
        gameManager = ObjectManager.GameManager;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            poolingManager.UseGoldFx(transform.position);
            gameObject.SetActive(false);

            gameManager.collectedGolds.Add(gameObject);
            gameManager.totalGold++;
        }
    }
}
