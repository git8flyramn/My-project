using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
   

    private ObjectPool pool;
    private GameObject obj;
    public ObjectPool Pool { get => pool; set => pool = value; }

    void Update()
    {
        
    }
    //生成したオブジェクトをプールに戻し、非アクティブ化
    public void Release()
    {
        pool.ReturnToPool(obj);
    }
}
