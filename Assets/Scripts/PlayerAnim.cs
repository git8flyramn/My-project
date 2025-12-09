using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerAnim : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }
    }
}
