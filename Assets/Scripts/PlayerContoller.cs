using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerContoller : MonoBehaviour
{

    CharacterController con;
    Animator anim;
    Vector3 startPos;
    private float normalspeed = 3.0f;
    private float sprint = 5.0f;
    void Start()
    {
        con = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        startPos = transform.position; 
    }

    void Update()
    {
        float Spped = Input.GetKey(KeyCode.LeftShift) ? sprint : normalspeed;

        Vector3 cameraFroward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1));

        Vector3 moveZ = cameraFroward * Input.GetAxis("Vertical") * Spped;
        Vector3 moveX = Camera.main.transform.right * Input.GetAxis("Horizontal") * Spped;
    }
}