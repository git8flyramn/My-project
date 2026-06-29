using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class RightSideTrainMove : MonoBehaviour
{
    private Rigidbody rb;
    private BothTrainMove BothTrain;
    private SEManeger SE;
    public AudioClip clip;
    private float SeceneChangeTIme = 0.5f;
    void Start()
    {
        rb        = GetComponent<Rigidbody>();
        BothTrain = GetComponent<BothTrainMove>();
        SE        = GetComponent<SEManeger>(); 
    }

// Update is called once per frame
    void Update()
    {
        BothTrain.TrainMove();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SE.TrainAccident(clip);
            Debug.Log("右の電車とplayerとぶつかった音を再生します");
            StartCoroutine(TrainAciidentWaitTime());
        }

    }

    IEnumerator TrainAciidentWaitTime()
    {
        yield return new WaitForSeconds(SeceneChangeTIme);
        Debug.Log("playerと右の電車がぶつかった時の判定を取りました");
        SceneManager.LoadScene("Game Over");
    }
}
