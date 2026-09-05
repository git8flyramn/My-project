using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;
using Unity.VisualScripting;



public class ObjectPool : MonoBehaviour
{

    public enum PoolType
    {
        train,
        SecondTrain,
        ThirdTrain
    }

    [System.Serializable]
    public class PoolItem
    {

        public PoolType type;
        public GameObject obj;
    }

    [SerializeField] List<PoolItem> items;
    private int Max_train = 9;
    private int Init_train = 5;
    //private bool isRelease = false;
    public static ObjectPool instance;
    Dictionary<PoolType, ObjectPool<GameObject>> pools = new Dictionary<PoolType, ObjectPool<GameObject>>();





    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        InitializePool();
        SetUpPool();
    }


    void InitializePool()
    {

        foreach (var item in items)
        {
            ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
                () => Instantiate(item.obj),
                (obj) => GetPooledObject(obj),
                (obj) => obj.SetActive(false),
                (obj) => Destroy(obj),
                true,
                Init_train,
                Max_train
            );
            pools.Add(item.type, pool);
        }
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
    public void GetPooledObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void OnGet(PoolType type)
    {
        pools[type].Get();
    }
    //使用後に返却する
    public void ReturnToPool(GameObject obj, PoolType type)
    {
       
        if (pools.TryGetValue(type, out var pool))
        {
            obj.SetActive(false);
            pool.Release(obj);
            Debug.Log("返却しました" + obj.activeSelf);
        }
    }
}


  

