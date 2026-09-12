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
    private int Max_train = 6;
    private int Init_train = 5;
    public static ObjectPool instance;
    private ObjectPool<GameObject> pool; 
    Dictionary<PoolType,GameObject> pools = new Dictionary<PoolType,GameObject>();


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        InitializePool();
    }
   


    void InitializePool()
    {

        foreach (var item in items)
        {
             pool = new ObjectPool<GameObject>(
                () => Instantiate(item.obj),
                (obj) => GetPooledObject(obj),
                (obj) => obj.SetActive(false),
                (obj) => Destroy(obj),
                true,
                Init_train,
                Max_train
            );
            pools.Add(item.type, item.obj);
        }
       // SetUpPool();
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

    public GameObject OnGet(PoolType type,GameObject TrainObject)
    {

        if (pools.ContainsKey(type))
        {
            ReturnToPool(TrainObject, type);
        }
        GameObject obj = pool.Get();
        pools[type] = obj;
        Debug.Log("obj: " + obj);
        Debug.Log("obj_ID: " + obj.GetEntityId());
        return obj;
       
    }
    //使用後に返却する
    public void ReturnToPool(GameObject obj, PoolType type)
    {  
        if(pools.TryGetValue(type, out GameObject obj))
        {
            Debug.Log("返却されます: " + obj);
            Debug.Log("obj_ID:" + obj.GetEntityId());
            pool.Release(obj);
            pools.Remove(type);
            Debug.Log("activeSelf: " + obj.activeSelf);
        }

       
    }
}


  

