using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private ObjectPool<GameObject> pool;
    [SerializeField] private PooledObject objectToPool;
    [SerializeField] private int Max_train = 5;
    [SerializeField] private GameObject targetObject;
    private Stack<PooledObject> Stack;
    void Start()
    { 
        SetUpPool();
    }

    // Update is called once per frame
    void Update()
    {
    }

    ////objectPool.Get()の時に呼ばれる機能
    private void SetUpPool()
    {
        Stack = new Stack<PooledObject>();
        PooledObject instance = null;

        for (int i = 0; i < Max_train; i++)
        {
            instance = Instantiate(objectToPool);
            instance.Pool = this;
            instance.gameObject.SetActive(false);
            Stack.Push(instance);
        }
    }

    //プール内から取り出す
    public PooledObject GetPooledObject()
    {
       if(Stack.Count == 0)
        {
            PooledObject newInstance = Instantiate(objectToPool);
            newInstance.Pool = this;
            return newInstance;
        }
        PooledObject nextInstance = Stack.Pop();
        nextInstance.gameObject.SetActive(true);
        return nextInstance;
    }

    //使用後に返却する
    public void ReturnToPool(PooledObject pooledObject)
    {
      Stack.Push(pooledObject);
      pooledObject.gameObject.SetActive(false);
      Debug.Log("自動返却されました");
        
    }
}
