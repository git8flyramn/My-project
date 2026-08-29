using Unity.VisualScripting;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    private ObjectPool pool;
    private ObjectPool Pool { get => pool; set => pool = value; }
   
    void Update()
    {
        
    }
    //生成したオブジェクトをプールに戻し、非アクティブ化
    public void Release(GameObject obj)
    {
        obj.SetActive(false);
        Debug.Log(obj + "が返却されました");
    }
}
