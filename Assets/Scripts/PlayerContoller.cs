using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.Mathematics;
public class PlayerContoller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float moveX;
    private float moveZ;

    void Start()
    { 
        //GetAxisRaw‚Å–îˆó‚ð•ûŒü‚ðŽó‚¯Žæ‚é
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveX, 0, moveZ);
    }
}
