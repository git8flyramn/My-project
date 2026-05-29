using System.Data;
using UnityEngine;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class ForWardMoveTrain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private Rigidbody rb;
    private float MoveSpeed = 2.0f;
    private float Initvelocity = 2.0f;
    private ForWardMoveTrain ForwardTrain;
    private SEManeger SE;
    public AudioClip clip;
    private float SeceneChangeTime = 0.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ForwardTrain = GetComponent<ForWardMoveTrain>();
    }

    // Update is called once per frame
    void Update()
    {
        TrainForwardMove();
    }

    private void TrainForwardMove()
    {
        rb.AddForce(Vector3.forward * Initvelocity * MoveSpeed, ForceMode.Acceleration);
    }

    public void OnCollisionEnter(Collision collision)
    {
        SE.TrainAccident(clip);
        Debug.Log("playerとぶつかった音を再生します");
        StartCoroutine(TrainAciidentWaitTime());
    }

    IEnumerator TrainAciidentWaitTime()
    {
        yield return new WaitForSeconds(SeceneChangeTime);
        Debug.Log("playerと電車がぶつかった時の判定を取りました");
        SceneManager.LoadScene("Game Over");
    }
}
