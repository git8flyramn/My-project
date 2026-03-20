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
    private float g = 10.0f;
    private float ResetDefaultSpeed = 10.0f; //元のスピードに戻すため
    private float decStamina = 2.0f;//スタミナの減少量
    float rayDist;

    public  FixedJoystick StickMove;
   // int MoveSpeed = 5;

   Vector3 startPos;
    bool IsRun = false;
  　
   
    void Start()
    {
        con  = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        Dash = GetComponent<DashController>();
        rb   = GetComponent<Rigidbody>();
        rayDist = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
       
        MoveStick();
        DashMove();
    }
    //ダッシュの機能(あとでMoveStickと統合する)
    void DashMove()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Dash.UseStamina(decStamina);
            ParticleSystem.Play();
            Debug.Log("ダッシュエフェクト再生");
            defaultSpeed = dash;
        }
        else if (Input.GetKeyUp(KeyCode.G))
        {
            Debug.Log("ダッシュエフェクト停止");
            ParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

            defaultSpeed = ResetDefaultSpeed;
        }
    }

    
    //前に自動で進む
    void MoveStick()
    {
        IsRun = true;
        startPos = GameObject.Find("Player").transform.position;
        Vector3 forwardMove = Vector3.forward * defaultSpeed * Time.deltaTime;
        float horizontal = StickMove.Horizontal;
        Vector3 side = Vector3.right * horizontal * defaultSpeed * Time.deltaTime;
        con.Move(-forwardMove + side);
        RayCast();
        anim.SetBool("IsRun", IsRun);
       
    }


    //RayCastによる接地判定
    void RayCast()
    {
                 //GameObject
      
        //rayの描画に必要な情報
        Vector3 rayPositon = transform.position + new Vector3(0.0f, 0.0f, 0.0f);
        Ray GroundCheckRay = new Ray(rayPositon, Vector3.down);
        bool isGround = Physics.Raycast(GroundCheckRay, rayDist);
        Debug.DrawRay(rayPositon, Vector3.down * rayDist, Color.red);
        //isGroundが正常に作動しているか
        //Debug.Log(isGround);
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