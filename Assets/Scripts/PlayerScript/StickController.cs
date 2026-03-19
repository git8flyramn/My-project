using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class StickController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] ParticleSystem ParticleSystem;
    private Rigidbody rb;
    public DashController Dash;
           CharacterController con;
    private Animator anim;
    Vector3 moveDirection = Vector3.zero;
    Vector3 StickDirection = Vector3.zero;

    private float defaultSpeed = 10.0f;//通常のスピード 
    private float dash = 15.0f;        //ダッシュ時のスピード
   // private float g = 9.8f;
    private float ResetDefaultSpeed = 10.0f; //元のスピードに戻すため
    private float decStamina = 2.0f;//スタミナの減少量

    
    public  FixedJoystick StickMove;
   // int MoveSpeed = 5;

   // Vector3 startPos = Vector3.zero;
    bool IsRun = false;
  　
   
    void Start()
    {
        con  = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        Dash = GetComponent<DashController>();
        rb   = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        MoveStick();
        DashMove();
    }

    void DashMove()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Dash.UseStamina(decStamina);
            ParticleSystem.Play();
            Debug.Log("ダッシュエフェクト再生");
            defaultSpeed = dash;
            /*
            //ダッシュ出来なくする->
            //もしダッシュゲージの今の値を確認して、0より小さかったら
            //アニメーションのダッシュとダッシュの
            //スピードを入れないようにする
            
             if(currntStamina < 0)
            {
             anim.SetBool("IsRun", false);
              defaultSpeed = ResetSpeed;
            }*/

        }
        else if (Input.GetKeyUp(KeyCode.G))
        {
            Debug.Log("ダッシュエフェクト停止");
            ParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

            defaultSpeed = ResetDefaultSpeed;
        }
    }

    void MoveStick()
    {
        //    IsRun = true;

        //    //必要な機能

        //    //前に進む

        //    Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        //     Vector3 moveZ = defaultSpeed * cameraForward;
        //    // StickDirection += 
        //    //ダッシュ・エフェクト


        //    if (con.isGrounded)
        //    {
        //        moveDirection = moveZ;

        //    }
        //    else
        //    {
        //        moveDirection.y -= g * Time.deltaTime;
        //    }
        //    anim.SetBool("IsRun", IsRun);
        //    con.Move(moveDirection * Time.deltaTime);
        IsRun = true;

        Vector3 forwardMove = Vector3.forward * defaultSpeed * Time.deltaTime;
        float horizontal = StickMove.Horizontal;
        Vector3 side = Vector3.right * horizontal * defaultSpeed * Time.deltaTime;
        transform.Translate(forwardMove + side);

        RayCast();
      
       
        anim.SetBool("IsRun", IsRun);
    }

    void RayCast()
    {
        //rayの描画に必要な情報
        Vector3 rayPositon = this.transform.position + new Vector3(0.0f, 0.0f, 0.0f);
        float rayDist = 1.0f;
        float JumpHeight = 3.0f;
        Ray GroundCheckRay = new Ray(rayPositon, Vector3.down);
        bool isGround = Physics.Raycast(GroundCheckRay, rayDist);
        Debug.DrawRay(rayPositon, Vector3.down * rayDist, Color.red);
        
        
        if(Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(new Vector3(0, JumpHeight, 0));
        }

        //isGroundが正常に作動しているか
        Debug.Log(isGround);
    }
  
}

/*
   if (con.isGrounded)
        {
           
        }
        else
        {
            moveDirection.y -= g * Time.deltaTime;
        }
 */