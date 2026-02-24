using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerContoller : MonoBehaviour
{


    [SerializeField] ParticleSystem ParticleSystem;
    public StaminaController stamina;
    CharacterController con;
    private Animator anim;
    Vector3 moveDirection = Vector3.zero;
    private float defaultSpeed = 10.0f;//通常のスピード 
    private float dash = 15.0f;
    private float g = 9.8f;
    private float speed = 10.0f;
    private float decStamina = 0.01f;//スタミナの減少量

    //  private float sprint = 15.0f; //加速したスピード
    // private float g = 9.8f; //重力
    float Speed; //走っている時のスピード

    Vector3 startPos = Vector3.zero;
    bool IsRun;
    void Start()
    {
        con = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        stamina = GetComponent<StaminaController>();
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
        if (Input.GetKeyDown(KeyCode.G))
        {
            stamina.UseStamina(decStamina);
            ParticleSystem.Play();
            Debug.Log("ダッシュエフェクト再生");
            defaultSpeed = dash;
        }
      
        else if(Input.GetKeyUp(KeyCode.G))
        {
            Debug.Log("ダッシュエフェクト停止");
            ParticleSystem.Stop(true,ParticleSystemStopBehavior.StopEmittingAndClear);
           
            defaultSpeed = speed;
        }
     
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        Vector3 moveZ = cameraForward * defaultSpeed;

        Vector3 moveX = Camera.main.transform.right * Input.GetAxis("Horizontal") * defaultSpeed;

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