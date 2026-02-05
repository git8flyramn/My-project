using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ItemController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float Time;
   // public float ItemSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //var Speed = Vector3.zero;
        //Speed.z = ItemSpeed;
        //this.transform.Translate(Speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
