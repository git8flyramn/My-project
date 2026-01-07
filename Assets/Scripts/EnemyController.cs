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
        Destroy(this.gameObject, Time);
    }

    // Update is called once per frame
    void Update()
    {
        var Speed = Vector3.zero;
        Speed.z = EnemySpeed;

                    
        this.transform.Translate(Speed);
    }
}
