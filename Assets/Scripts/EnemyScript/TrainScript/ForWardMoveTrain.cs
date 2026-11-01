using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
public class ForWardMoveTrain : MonoBehaviour
{
    //“dÔ‚ª‚Âî•ñ
    private Rigidbody rb;
    private const float MoveSpeed = 5.0f;
    private const float Initvelocity = 10.0f;
    
    private SEManeger SE;
    public AudioClip clip;
    private GameObject Player;
    [SerializeField] ObjectPool.PoolType TrainType;

    //“dÔ‚Ì•Ô‹pŠÔ‚ÆŠÔŠu
    private float ReturnTrainTime = 0.0f;
    private float ReturnTrainInverval = 10.0f;

    void Start()
    {
        Initialize();
    }


    void Initialize()
    {
        rb = GetComponent<Rigidbody>();
        SE = GetComponent<SEManeger>();
        Player = GameObject.Find("Player");
    }


    private void FixedUpdate()
    {
        ReturnTrainTime += Time.deltaTime;
        TrainForwardMove();
        if(ReturnTrainTime > ReturnTrainInverval)
        {
            TrainReturn();
        }
    }

    //“dÔ‚ÌˆÚ“®ˆ—
    private void TrainForwardMove()
    {
        rb.AddForce(Vector3.forward * Initvelocity * MoveSpeed, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Player.GetComponent<StickController>().PlayerDeath();
        }
    }
    void TrainReturn()
    {
        ObjectPool.instance.ReturnToPool(gameObject, TrainType);
    }

}
