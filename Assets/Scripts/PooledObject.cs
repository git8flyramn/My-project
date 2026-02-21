using Unity.VisualScripting;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private ObjectPool pool;
    
    public ObjectPool Pool { get => pool; set => pool = value; }
    void Start()
    {
        pool = GetComponent<ObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //生成したオブジェクトをプールに戻し、非アクティブ化
    public void Release()
    {
      // pool.ReturnToPool(this);
    }
}
