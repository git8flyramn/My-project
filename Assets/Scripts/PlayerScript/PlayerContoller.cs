using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerContoller : MonoBehaviour
{


    [SerializeField] ParticleSystem ParticleSystem;
    CharacterController con;
    private Animator anim;
    Vector3 moveDirection = Vector3.zero;
    private float normalSpeed = 15.0f;  //通常のスピード
    private float sprint = 10.0f;
    private float g = 9.8f;
   

    //  private float sprint = 15.0f; //加速したスピード
    // private float g = 9.8f; //重力
    float Speed; //走っている時のスピード

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
        IsRun = true;
        if (Input.GetKey(KeyCode.G))
        {

            //ParticleSystem.Play();
            //Debug.Log("ダッシュエフェクト再生");
            Speed = sprint;
        }
        else
        {
            Speed = normalSpeed;
        }
      //Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        Vector3 moveZ = cameraForward * normalSpeed;

        Vector3 moveX = Camera.main.transform.right * Input.GetAxis("Horizontal") * normalSpeed;

        if(con.isGrounded)
        {
            moveDirection = moveZ + moveX;
        }
        else
        {
            moveDirection.y -= g * Time.deltaTime;
        }
        anim.SetBool("IsRun", IsRun); con.Move(moveDirection * Time.deltaTime);



    }

   
}