using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class StickController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] ParticleSystem ParticleSystem;
    public DashController Dash;
    public CharacterController con;
    private Animator anim;
    Vector3 StickDirection = Vector3.zero;
    private float defaultSpeed = 10.0f;//通常のスピード 
    private float dash = 15.0f;        //ダッシュ時のスピード
    private float gravity = 9.8f;
    private float ResetDefaultSpeed = 10.0f; //元のスピードに戻すため
    private float decStamina = 2.0f;//スタミナの減少量
    public FixedJoystick StickMove;
    float distance = 1.0f;
    public LayerMask walkableGround;
    Vector3 startPos;
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
        RayCast();
        IsRun = true;
        //自走部分
        Vector3 forwardMove = Vector3.forward * defaultSpeed * Time.deltaTime;
        float horizontal = StickMove.Horizontal;
        Vector3 side = Vector3.right * horizontal * defaultSpeed * Time.deltaTime;
         if(con.isGrounded)
        {
            StickDirection = forwardMove + side;
        }
        else
        { 
            StickDirection.y += gravity * Time.deltaTime;
        }
        con.Move(-StickDirection);
        anim.SetBool("IsRun", IsRun);

    }


    //RayCastによる接地判定
      void RayCast()
    {
        //rayの描画に必要な情報
        //rayの開始位置、方向、距離、衝突を無視する物
        Vector3 rayPosition = transform.position;
        RaycastHit hit;
        Ray ray = new Ray(rayPosition, Vector3.down * distance);
        bool isGround = Physics.Raycast(ray,out hit,walkableGround);
        Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red); 
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