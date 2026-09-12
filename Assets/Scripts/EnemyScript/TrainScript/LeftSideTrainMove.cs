using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class LeftSideTrainMove : MonoBehaviour
{
    

    private Rigidbody rb;
    private BothTrainMove BothTrain;
    private SEManeger SE;
    public AudioClip clip;
    private GameObject Player;
    [SerializeField] ObjectPool.PoolType TrainType;
    //“dŽÔ‚Ì•Ô‹pŽžŠÔ‚ÆŠÔŠu
    private float ReturnTrainInverval = 13.0f;
    private float ReturnTrainTime     = 0.0f;

    void Start()
    {
        Initialize(); 
    }

    void Initialize()
    {
        rb = GetComponent<Rigidbody>();
        BothTrain = GetComponent<BothTrainMove>();
        SE = GetComponent<SEManeger>();
        Player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        ReturnTrainTime += Time.deltaTime;
        BothTrain.TrainMove();

        if(ReturnTrainTime > ReturnTrainInverval)
        {
            LeftTrainReturn();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SE.TrainAccident(clip);
            Player.GetComponent<StickController>().PlayerDeath();
        }
    }

    void LeftTrainReturn()
    {
        ObjectPool.instance.ReturnToPool(gameObject,TrainType);
    }


}
