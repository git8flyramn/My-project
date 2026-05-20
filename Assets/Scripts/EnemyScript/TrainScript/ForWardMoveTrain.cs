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
    private SEManeger SE;
    private float MoveSpeed = 2.0f;
    private float Initvelocity = 2.0f;
    public AudioClip clip;
    private float SeceneChangeTime = 0.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SE = GetComponent<SEManeger>();
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
        if (collision.gameObject.name == "Player")
        {
            SE.TrainAccident(clip);
            Debug.Log("player‚Æ‚Ô‚Â‚©‚Á‚½‰¹‚ğÄ¶‚µ‚Ü‚·");
            StartCoroutine(TrainAciidentWaitTime());
        }
    }

    IEnumerator TrainAciidentWaitTime()
    {
        yield return new WaitForSeconds(SeceneChangeTime);
        Debug.Log("player‚Æ“dÔ‚ª‚Ô‚Â‚©‚Á‚½‚Ì”»’è‚ğæ‚è‚Ü‚µ‚½");
        SceneManager.LoadScene("Game Over");
    }
}
