using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerContoller : MonoBehaviour
{

    CharacterController con;
    private  Animator anim;
    Vector3 moveDirection = Vector3.zero;
    private float normalSpeed = 6.0f;  //通常のスピード
 　 private float sprint = 10.0f; //加速したスピード
    private float g = 9.8f; //重力
   
    Vector3 startPos = Vector3.zero;
    bool IsRun;
    void Start()
    {
        con = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        startPos = transform.position;
    }

    void Update()
    {
        
         Move();
        
    }
    //playerの動き
     void Move()
    {
        IsRun = false;
        MoveSet();
    }

    void MoveSet()
    {
        //|| Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            IsRun = true;
        }
        float Speed;
        if(Input.GetKey(KeyCode.F))
        {
            Speed = sprint;
        }
        else 
        {
            Speed = normalSpeed;
        }
        
        Vector3 cameraFroward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1));
        Vector3 moveZ = cameraFroward * Input.GetAxis("Vertical") * Speed;
        Vector3 moveX = Camera.main.transform.right * Input.GetAxis("Horizontal") * Speed;
        if (con.isGrounded)
        {
            moveDirection = moveZ + moveX;

        }
        else
        {
           // moveDirection = moveZ + moveX + new Vector3(0,moveDirection.y, 0);
            moveDirection.y -= g * Time.deltaTime;
        }
        anim.SetBool("IsRun", IsRun);
       
        con.Move(moveDirection * Time.deltaTime);
        
    }
}