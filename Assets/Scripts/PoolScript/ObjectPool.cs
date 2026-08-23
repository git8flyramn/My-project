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
        LeftForwardTrain,
        RightForwardTrain,
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
    private int Max_train = 15;
    public static ObjectPool instance;
    Dictionary<PoolType, ObjectPool<GameObject>> pools = new Dictionary<PoolType, 
                                                                        ObjectPool<GameObject>>();
         




    void Start()
    {
        Initialize();
    }

       
    void Initialize()
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
            ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
          () => Instantiate(item.obj),
          (obj) => GetPooledObject(obj),
          (obj) => obj.SetActive(false),
          (obj) => Destroy(obj),
           true,
           5,
           Max_train);
            pools.Add(item.type, pool);
        }
       SetUpPool();

    }
    //objectPoolにオブジェクトを生成し準備する
    private void SetUpPool()
    {
        foreach (var item in items)
        {
            var stack = new Stack<PooledObject>();
            //var instance = null;
            for (int i = 0; i < Max_train; i++)
            {
               
            }
          
        }
    }


    //オブジェクトの取得
    void GetPooledObject(GameObject obj)
    {
        obj.SetActive(true);
        obj.transform.position = Vector3.zero;
    }

    //外部からオブジェクトのを取得するため
    public void OnGet(PoolType type)
    {
        pools[type].Get();
    }


    //使用後に返却する
    public void ReturnToPool(PoolType type, PooledObject pooledobj)
    {
        pools[type].Release(pooledobj);
    }


}
