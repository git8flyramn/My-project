using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    private Animator anim;
    private CharacterController con;
    Vector3 moveDirection = Vector3.zero;
    Vector3 StartPos;
     void Start()
    {
        con = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
      
            if (Input.GetKey(KeyCode.UpArrow))
            {
                anim.SetBool("IsRun", true);
            }
            else
            {
                anim.SetBool("IsRun", false);
            }
          
            if(Input.GetKey(KeyCode.Space))
            {
               
            }
        
      

    }
}