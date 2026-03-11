using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private ObjectPool<GameObject> pool;
    
     [SerializeField] private GameObject targetObject;
     [SerializeField] private int TrainNum;
    [SerializeField] private int MaxTrainNum; 
                     



    void Start()
    {                                   //生成     アクティブ化　非アクティブ
        pool = new ObjectPool<GameObject>(SetUpPool, GetPooledObject, ReturnToPool, OnDestory, false, TrainNum, MaxTrainNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject SetUpPool()
    {
        
            Debug.Log("オブジェクトが生成されました");
            Vector3 initPosition = transform.position;
            GameObject objectClone = Instantiate(targetObject, initPosition, Quaternion.identity);
            return objectClone;
          
    }

    public void GetPooledObject(GameObject objectClone)
    {
        objectClone.gameObject.SetActive(true);
    }

    public void ReturnToPool(GameObject objectClone)
    {
        objectClone.gameObject.SetActive(false);
    }

    public void OnDestory(GameObject objectClone)
    {
            Destroy(objectClone.gameObject);
    }

    public GameObject Get()
    {
        return pool.Get();
    }

    public void Release(GameObject objectClone)
    {
        pool.Release(objectClone);
    }

}
