using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class StickController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public FixedJoystick InputMove;
    float moveSpeed = 5.0f;
    public Transform trans;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("スティックで移動");
        this.trans.position += this.trans.forward * InputMove.Vertical * moveSpeed * Time.deltaTime;
     // this.transform.position += this.transform.right * inputMove.Horizontal * moveSpeed*Time.deltaTime; 
        this.trans.position     += this.trans.right * InputMove.Horizontal * moveSpeed * Time.deltaTime;
    }


     
}
