using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ItemManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject RecoveryItem;
    public Transform RecoveryItemPlace;
    public float ItemSpeed;
    //ê∂ê¨ÇÃä‘äu
    float TimeCount;
    void Start()
    {
        TimeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        TimeCount += Time.deltaTime;
        if(TimeCount > 5)
        {
            var Speed = Vector3.zero;
            Speed.z = ItemSpeed;
            this.transform.Translate(Speed);
            //ÉAÉCÉeÉÄÇÃê∂ê¨                                      //âÒì]ÇµÇ»Ç¢
            Instantiate(RecoveryItem, RecoveryItemPlace.position, Quaternion.identity);
            TimeCount = 0;
        }
    }
}
