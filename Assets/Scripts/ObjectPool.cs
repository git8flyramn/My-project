using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    [SerializeField] private uint PoolSize;
    [SerializeField] private PooledObject objectToPool;
    private Stack<PooledObject> stack;
    void Start()
    {
        SetUpPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetUpPool()
    {
        stack = new Stack<PooledObject>();
        PooledObject instance = null;
        for (int i = 0; i < PoolSize; i++)
        {
            instance = Instantiate(objectToPool);
            instance.Pool = this;
            instance.gameObject.SetActive(false);
            stack.Push(instance);
        }
    }

    public PooledObject GetPooledObject()
    {
        if(stack.Count == 0)
        {
            PooledObject newInstance = Instantiate(objectToPool);
            newInstance.Pool = this;
            return newInstance;
        }
        PooledObject nextInstance = stack.Pop();
        nextInstance.gameObject.SetActive(true);
        return nextInstance;
    }

    public void ReturnToPool(PooledObject pooledObject)
    {
        stack.Push(pooledObject);
        pooledObject.gameObject.SetActive(false);
    }

    public void  ObjInstance()
    {
        SetUpPool();
    }
}
