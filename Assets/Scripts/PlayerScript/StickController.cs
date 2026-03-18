using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class StickController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] ParticleSystem ParticleSystem;
    public StaminaController stamina;
    CharacterController con;
    private Animator anim;
    Vector3 moveDirection = Vector3.zero;

    private float defaultSpeed = 10.0f;//通常のスピード 
    private float dash = 20.0f;        //ダッシュ時のスピード
    private float g = 9.8f;
    private float ResetDefaultSpeed = 10.0f; //元のスピードに戻すため
    private float decStamina = 2.0f;//スタミナの減少量

    public FixedJoystick StickMove;
    float MoveSpeed = 5.0f;

    Vector3 startPos = Vector3.zero;
    bool IsRun = false;

    void Start()
    {
        con = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        stamina = GetComponent<StaminaController>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveStick();

    }

    void MoveStick()
    {
        IsRun = true;
      
        ////必要な機能

        ////前に進む
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveZ = cameraForward * defaultSpeed;


        //ダッシュ・エフェクト
        IsRun = true;
        if (Input.GetKeyDown(KeyCode.G))
        {
            stamina.UseStamina(decStamina);
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

        if(con.isGrounded)
        {
            this.transform.position += this.transform.right * StickMove.Horizontal * MoveSpeed * Time.deltaTime;
            moveDirection = moveZ;
        }
        else
        {
            moveDirection.y -= g * Time.deltaTime;
        }
        anim.SetBool("IsRun", IsRun);
        con.Move(moveDirection * Time.deltaTime);
    }
  
}
