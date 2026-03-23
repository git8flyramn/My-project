using UnityEngine;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
public class RandomDropTrain : MonoBehaviour
{

    public GameObject DropObject;
    //private int frame = 30;
    private float DropX;
    private float DropY = 1.0f;
    private float DropZ;
    private float MinrangeX = -105.0f;
    private float MaxrangeX = -59.0f;
    private float MinrangeZ = -930.0f;
    private float MaxrangeZ = -780.0f;
    public  float time = 0.0f;
    private Quaternion Rotaion = Quaternion.Euler(0,90,0);
    private Vector3 DropPos = Vector3.zero;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
             // Time.deltaTime
        time += Time.deltaTime;
        if(time > 5)
        {
            DropX = Random.Range(MinrangeX,MaxrangeX);
            DropZ = Random.Range(MinrangeZ, MaxrangeZ);
            DropPos = new Vector3(DropX,DropY,DropZ);
            Instantiate(DropObject, DropPos, Rotaion);
            Debug.Log("ìdé‘Ç™â°å¸Ç´Ç≈ê∂ê¨Ç≥ÇÍÇ‹ÇµÇΩ");
            time = 0.0f;
        }
    }
}
