using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ItemManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject RecoveryItem;
    public Transform RecoveryItemPlace;
    public int GeneratetTime = 15;
   
    //¶¬‚ÌŠÔŠu
    float TimeCount;
    void Start()
    {
        TimeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount += Time.deltaTime;
        if(TimeCount > GeneratetTime)
        {
            //ƒAƒCƒeƒ€‚Ì¶¬                                      //‰ñ“]‚µ‚È‚¢
            Instantiate(RecoveryItem, RecoveryItemPlace.position, Quaternion.identity);
            TimeCount = 0;
        }
    }
}
