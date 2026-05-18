using System.Data;
using UnityEngine;
using Unity.VisualScripting;
<<<<<<< HEAD
=======
using System.Collections;
>>>>>>> d6787c5341d54e5be7e8e2916433f617c18bc89e
using System.Collections.Generic;
public class ForWardMoveTrain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private Rigidbody rb;
    private SEManeger SE;
    private float MoveSpeed = 3.0f;
    private float Initvelocity = 2.0f;
<<<<<<< HEAD
=======
    private SEManeger SE;
>>>>>>> d6787c5341d54e5be7e8e2916433f617c18bc89e
    public AudioClip clip;

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

<<<<<<< HEAD
=======

>>>>>>> d6787c5341d54e5be7e8e2916433f617c18bc89e
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SE.TrainAccident(clip);
<<<<<<< HEAD
            Debug.Log("ã¶ã¤ã‹ã£ãŸéŸ³ã‚’åEç”Ÿã—ã¾ãE);
=======
            Debug.Log("‚Ô‚Â‚©‚Á‚½‰¹‚ðÄ¶‚µ‚Ü‚·");
>>>>>>> d6787c5341d54e5be7e8e2916433f617c18bc89e
        }
    }
}
