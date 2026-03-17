using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private ObjectPool<GameObject> pool;
    
     [SerializeField] private GameObject targetObject;
     [SerializeField] private int  Max_train;
    [SerializeField] private PooledObject objectToPool;

    void Start()
    {
                                   //生成     アクティブ化　非アクティブ    破棄
        pool = new ObjectPool<GameObject>(SetUpPool, GetPooledObject, ReturnToPool, OnDestory, collectionCheck: false, defaultCapacity: Max_train, maxSize: Max_train);
       
    }

    // Update is called once per frame
    void Update()
    {
    }

    //objectPool.Get()の時に呼ばれる機能
    private GameObject SetUpPool()
    {

        // Debug.Log("オブジェクトが生成されました");
        Vector3 initPosition = transform.position;
        GameObject objectClone = Instantiate(targetObject, initPosition, Quaternion.identity);
        return objectClone;
    }

    public void GetPooledObject(GameObject objectClone)
    {
       
        objectClone.gameObject.SetActive(true);
       
    }

    public void ReturnToPool(GameObject objectClone)
    {
      
        objectClone.gameObject.SetActive(false);
    }

    public void OnDestory(GameObject objectClone)
    {
        Destroy(objectClone);
    }

    public GameObject Get()
    {
        return pool.Get();
    }

    public void Release(GameObject objectClone)
    {
        pool.Release(objectClone);
    }

    //電車の最大数の取得
    public int GetTrainNum()
    {
        return Max_train;
    }
}
