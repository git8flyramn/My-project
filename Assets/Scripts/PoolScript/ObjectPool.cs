using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
  
    //プールに持たせたい変数のクラス
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
    private ObjectPool<GameObject> pool;






    void Start()
    {
        InitializePool();
    }

       
    void InitializePool()
    {
       
       if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
       SetUpPool();

    }
    //objectPoolにオブジェクトを生成し準備する
    private void SetUpPool()
    {
        pools = new Dictionary<string, Queue<GameObject>>();

        foreach (var item in items)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();
            for (int i = 0; i < Max_train; i++)
            {
                               //Instantiate
                GameObject obj = Instantiate(item.obj);
                obj.SetActive(false);
                objectpool.Enqueue(obj);
            }
            pools.Add(item.type, objectpool);
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
        obj.SetActive(false);
        pools[key].Enqueue(obj);
        Debug.Log(obj + "が返却されました");

    }
}
