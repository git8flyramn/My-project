using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//public class NewEmptyCSharpScript
public class PlayerConfig : MonoBehaviour
{

    //float speed = 1.0f;
    private float time = 1.0f;
    private float g = 9.8f;
    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-1.0f * time, 0, 0);
            time += -1.0f;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0,1.0f, 0);
        }

    }

}
