using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{


    [System.Serializable]
    public class PoolItem
    {
        public string type;
        public GameObject obj;  
    }

    [SerializeField] List<PoolItem> items;
    private int Max_train = 5;
    public static ObjectPool instance;
    public Dictionary<string, Queue<GameObject>> pools;






    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        InitializePool();
    }

       
    void InitializePool()
    {
       
       SetUpPool();

    }
    //objectPoolにオブジェクトを生成し準備する
    private void SetUpPool()
    {
        pools = new Dictionary<string, Queue<GameObject>>();
        foreach (PoolItem item in items)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();
            
            for (int i = 0; i < Max_train; i++)
            {
                GameObject obj = Instantiate(item.obj);
                obj.SetActive(false);
                objectpool.Enqueue(obj);
            }
            pools.Add(item.type,objectpool);
        }
    }


    //オブジェクトの取得
    public GameObject GetPooledObject(string key)
    {
       if(!pools.ContainsKey(key))
        {
            Debug.LogWarning(key + "と一致しません");
            return null;
        }

        GameObject pooledObject = pools[key].Dequeue();
        pooledObject.SetActive(true);
        return pooledObject;
    }


    //使用後に返却する
    public void ReturnToPool(GameObject obj,string key)
    {
        if(!pools.ContainsKey(key))
        {
            Debug.LogWarning(key + "と一致しません");
            return;
        }
        pools[key].Release(obj);
        pools[key].Enqueue(obj);
        

    }

  
}
