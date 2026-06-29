using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StickController : MonoBehaviour
{
    //playerに必要なコンポーネントの定義
    [SerializeField] ParticleSystem ParticleSystem;
    public ProgressBarContorller Progress;
    private CharacterController con;
    private Animator anim;
    private Rigidbody rb;
    private LayerMask walkableGround;
    Vector3 StickDirection = Vector3.zero;
    private Vector3 rayPosition;
    private RaycastHit hit;
    private Ray ray;
    bool isGround;
    public FixedJoystick StickMove;
    [Header("基本スピード")] private float defaultSpeed = 40.0f;
    private float gravity = 9.8f;
    private float distance = 1.0f; //Rayの方向
    [Header("走っているかのフラグ")] bool IsRun = false;
   
    //private float SceneChangeTime = 1.0f;

    void Start()
    {

        con      = GetComponent<CharacterController>();
        anim     = GetComponent<Animator>();
        rb       = GetComponent<Rigidbody>();
        Progress = GetComponent<ProgressBarContorller>();
      

    }

    // Update is called once per frame
    void Update()
    {
        MoveStick();
    }
   
    //playerの移動機能
    void MoveStick()
    {
        RayCast();
        IsRun = true;
        //自走部分
        Progress.StartProgressBar();
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
                                       
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.name == "train")
        {
            Debug.Log("死亡しました");
        }
    }

}