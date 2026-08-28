using Unity.VisualScripting;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
   

    private ObjectPool pool;
    public ObjectPool Pool { get => pool; set => pool = value; }
    private ObjectPool.PoolItem item;

    void Update()
    {
        
    }
    //生成したオブジェクトをプールに戻し、非アクティブ化
    public void Release()
    {
        pool.ReturnToPool(item.obj,item.type);

    }
}
