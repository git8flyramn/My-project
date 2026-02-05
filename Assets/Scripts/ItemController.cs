using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ItemController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float DestroyTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "‚ªÚG‚µ‚½‚Ì‚ÅÁ–Å‚µ‚Ü‚·");
        if (collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("ƒvƒŒƒCƒ„[‚ªÚG‚µ‚½");
            Destroy(gameObject);
        }
    }
}
