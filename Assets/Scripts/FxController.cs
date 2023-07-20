using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxController : MonoBehaviour
{
    public ObjectType objectType;
    private PoolingManager poolingManager;

    void Start()
    {
        poolingManager = ObjectManager.PoolingManager;
    }


   public void CloseObject()
    {
        StartCoroutine(WaitClose());
    }
    private IEnumerator WaitClose()
    {
        yield return new WaitForSeconds(1);
        if (objectType.Equals(ObjectType.GoldFx))
            poolingManager.CloseGoldFx(gameObject);
        else if(objectType.Equals(ObjectType.CrashFx))
            poolingManager.CloseCrashFx(gameObject);
    }
}
