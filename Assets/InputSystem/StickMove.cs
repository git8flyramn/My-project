using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class StickMove : MonoBehaviour
{

    private private float moveSpeed = 10f;
      void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis(Input.GetAxis("Vertical"));
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
