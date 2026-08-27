using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
   

    //生成したいオブジェクト
    public enum PoolType
    {
        ForwardTrain,
        LeftSideTrain,
        RightSideTrain

    }
    //プールに持たせたい変数のクラス
    [System.Serializable]
    public class PoolItem
    {
        public PoolType type;
        public GameObject obj;
    }

    [SerializeField] List<PoolItem> items;

    [SerializeField] private PooledObject objectToPool;
    private int Max_train = 5;
    private int Init_train = 3;
    public static ObjectPool instance;
    Dictionary<PoolType, ObjectPool<GameObject>> pools = new Dictionary<PoolType, 
                                                                        ObjectPool<GameObject>>();
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

       foreach(var item in items)
        {
           pool = new ObjectPool<GameObject>(
          () => Instantiate(item.obj),
          (obj) => obj.SetActive(true),
          (obj) => obj.SetActive(false),
          (obj) => Destroy(obj),
           true,  
           Init_train,
           Max_train);
            pools.Add(item.type, pool);
        }
       SetUpPool();

    }
    //objectPoolにオブジェクトを生成し準備する
    private void SetUpPool()
    {
        GameObject[] obj = new GameObject[Max_train];
        foreach (var item in items)
        {
            for (int i = 0; i < Max_train; i++)
            {
                obj[i] = Instantiate(item.obj);
            }

            for (int i = 0; i < Max_train; i++)
            {
                pools[item.type].Release(obj[i]);
            }
        }
    }


    //オブジェクトの取得
    public void GetPooledObject(GameObject obj,Transform transform)
    {
        obj.transform.position = transform.position;
       
       
    }

    public void OnGetObject(GameObject obj)
    {
        obj.SetActive(true);
    }

   

    //外部からオブジェクトのを取得するため
    public void OnGet(PoolType type)
    {
       if(pools.TryGetValue(type,out var pool))
        {
            pool.Get();
        }
       
    }


    //使用後に返却する
    public void ReturnToPool(GameObject obj,PoolType type)
    {
     if(pools.TryGetValue(type,out var pool))
     {
            pool.Release(obj);
            Debug.Log("返却しました");
            Debug.Log(type);
     }
     else
     {
            Debug.Log("返却出来ていません");
     }
        
    }
}
