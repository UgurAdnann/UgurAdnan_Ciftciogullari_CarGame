using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldController : MonoBehaviour
{
    private PoolingManager poolingManager;

    void Start()
    {
        poolingManager = ObjectManager.PoolingManager;
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            poolingManager.UseGoldFx(transform.position);
            gameObject.SetActive(false);
            print("Gold");
        }
    }
}
