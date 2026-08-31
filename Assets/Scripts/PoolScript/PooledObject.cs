using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
public class PooledObject : MonoBehaviour
{
    private ObjectPool pool;
    public ObjectPool  Pool { get => pool; set => pool = value; }

    void Update()
    {
        
    }
    //生成したオブジェクトをプールに戻し、非アクティブ化
    public void Release()
    {
        Debug.Log("返却されました");
    }
}
