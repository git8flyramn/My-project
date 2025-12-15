using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerContoller : MonoBehaviour
{

    CharacterController con;
    public Animator anim;
    Vector3 moveDirection = Vector3.zero;
    private float normalSpeed = 6.0f;
    private float sprint = 10.0f;
  //  private float g = 9.8f;
    bool IsRun;
    void Start()
    {
        con = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
         Move();
        
    }
     void Move()
    {
        IsRun = false;
        MoveSet();
    }

    void MoveSet()
    {
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            IsRun = true;
        }
        float Spped = Input.GetKey(KeyCode.LeftShift) ? sprint : normalSpeed;
        Vector3 cameraFroward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1));
        Vector3 moveZ = cameraFroward * Input.GetAxis("Vertical") * Spped;
        Vector3 moveX = Camera.main.transform.right * Input.GetAxis("Horizontal") * Spped;
        if (con.isGrounded)
        {
            moveDirection = moveZ + moveX;

        }
        else
        {
            moveDirection = moveZ + moveX + new Vector3(0, 0, 0);
           // moveDirection.y -= g * Time.deltaTime;
        }

        con.Move(moveDirection * Time.deltaTime);
        anim.SetBool("IsRun", IsRun);
    }
}