using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class PlayerContoller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   Å@CharacterController con;
    Animator anim;
    float speed = 3f;
    float sprintspeed = 5f;
    float jump = 4f;
    float gravity = 10f;
    Vector3 moveDirection = Vector3.zero;
    Vector3 startPos = Vector3.zero;
    void Start()
    {
        con = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        startPos = transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        float spped = Input.GetKey(KeyCode.LeftShift) ? sprintspeed : speed;
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveZ = cameraForward * Input.GetAxis("Vertical") * speed;
        Vector3 moveX = Camera.main.transform.right * Input.GetAxis("Horizontal");
       
        //playerÇ™ínñ Ç…Ç¢ÇÈéû
        if(con.isGrounded)
        {
            moveDirection = moveZ + moveX;
            if(Input.GetButton("Jump"))
            {
                moveDirection.y = jump;
                anim.SetBool("Jump", true);
            }
        }
        else
        {
            moveDirection = moveZ + moveX + new Vector3(0, moveDirection.y, 0);
            moveDirection.y -= gravity * Time.deltaTime;
        }
        anim.SetBool("Walk",true);

        //transform.LookAt(transform.position + moveZ + moveX);

        con.Move(moveDirection * Time.deltaTime);
    }
}
