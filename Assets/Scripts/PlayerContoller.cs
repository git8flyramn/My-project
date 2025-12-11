using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class PlayerContoller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   Å@CharacterController con;
    Å@Animator anim;
    float movex, movez;
    void Start()
    {
        con = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        movex = Input.GetAxis("Horizontal");
        movez = Input.GetAxis("Vertical");

        transform.Translate(movex, 0, movez);
    }
}
