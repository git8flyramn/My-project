using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class StickController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] ParticleSystem ParticleSystem;
    public DashController Dash;
    CharacterController con;
    private Animator anim;
    Vector3 moveDirection = Vector3.zero;
    Vector3 StickDirection = Vector3.zero;

    private float defaultSpeed = 10.0f;//通常のスピード 
    private float dash = 15.0f;        //ダッシュ時のスピード
    private float g = 9.8f;
    private float ResetDefaultSpeed = 10.0f; //元のスピードに戻すため
    private float decStamina = 2.0f;//スタミナの減少量

    public  FixedJoystick StickMove;
   // int MoveSpeed = 5;

   // Vector3 startPos = Vector3.zero;
    bool IsRun = false;
  
    void Start()
    {
        con = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        Dash = GetComponent<DashController>();
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
       

        if (con.isGrounded)
        {

            transform.Translate(forwardMove + side);
        }
        else
        {
            moveDirection.y -= g * Time.deltaTime;
        }
       
        anim.SetBool("IsRun", IsRun);
    }
  
}
