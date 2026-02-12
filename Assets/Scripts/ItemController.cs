using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
public class ItemController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    
    public float DestroyTime;
    public float flowSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ItemMove();
    }

    void ItemMove()
    {
        var Speed = Vector3.zero;
        Speed.z += flowSpeed;
        this.transform.Translate(Speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("playerÇ…ê⁄êGÇµÇΩÇÃÇ≈è¡ñ≈ÇµÇ‹Ç∑");
            Destroy(gameObject,DestroyTime);
        }
    }
  
}
