using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
public class PooledObject : MonoBehaviour
{
    public ObjectPool<GameObject> Pool { get; set; }

    void Update()
    {
        
    }
    //生成したオブジェクトをプールに戻し、非アクティブ化
    public void Release()
    {
        Pool.Release(gameObject);
    }
}
