using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController : MonoBehaviour
{
    public float Time;
    public float EnemySpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        EnemyMove();
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(collision.gameObject.name + "Ç™ê⁄êGÇµÇΩÇÃÇ≈è¡ñ≈ÇµÇ‹Ç∑");
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject,Time);
        }
       
    }
    void EnemyMove()
    {
        var Speed = Vector3.zero;
        Speed.z = EnemySpeed;
        this.transform.Translate(Speed);
    }
}
