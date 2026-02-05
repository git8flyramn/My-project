using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ItemController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   
    public float ItemSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject,1.0f);
        }
    }
}
