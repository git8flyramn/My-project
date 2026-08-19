using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
public class StickController : MonoBehaviour
{
    //playerに必要なコンポーネントの定義
    [SerializeField] ParticleSystem ParticleSystem;
    private CharacterController con;
    private Animator anim;
    private Rigidbody rb;
    public FixedJoystick StickMove;

    private LayerMask walkableGround;　//地面のみを判定するため
    private Vector3 StickDirection = Vector3.zero;
    private Vector3 rayPosition;
    private RaycastHit hit;
    private Ray ray;
    bool isGround;

    
    [Header("基本スピード")] private float defaultSpeed = 35.0f;
    private float gravity = 9.8f;
    private float distance = 1.0f; //Rayの方向
    [Header("走っているかのフラグ")] bool IsRun = false;
    private float SceneChangeTime = 1.5f;
    public bool IsGameStart = false;
    void Start()
    {
        Initialize();
    }

                //initialize
    private void  Initialize()
    {
        con = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        StickMove.enabled = false;

    }
        
    void Update()
    {
        //if (IsGameStart == true && StickMove.enabled == true)
        //{
        //    MoveStick();
        //}
        RayCast();
        MoveStick();
    }

    //playerの移動機能
    public void MoveStick()
    {

        
            IsRun = true;
            //自走部分
            Vector3 forwardMove = Vector3.forward * defaultSpeed * Time.deltaTime;
            float horizontal = StickMove.Horizontal;
            Vector3 side = Vector3.right * horizontal * defaultSpeed * Time.deltaTime;

            if (con.isGrounded)
            {
                ParticleSystem.Play();
                StickDirection = forwardMove + side;
            }
            else
            {
                ParticleSystem.Stop();
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
        rayPosition = transform.position;
        ray = new Ray(rayPosition, Vector3.down * distance);
        isGround = Physics.Raycast(ray, out hit, walkableGround);
        Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);
        
    }

  
    public void PlayerDeath()
    {
        StartCoroutine(DeathWaitTime());
    }

    private IEnumerator DeathWaitTime()
    {
        anim.SetTrigger("IsDeath");
        yield return new WaitForSeconds(SceneChangeTime);
        SceneManager.LoadScene("Game Over");
    }

    public void PlayerIsStartMove()
    {
        IsGameStart = true;
        StickMove.enabled = true;
    }
}