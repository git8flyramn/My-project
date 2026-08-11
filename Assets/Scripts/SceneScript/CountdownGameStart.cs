using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CountdownGameStart : MonoBehaviour
{

    private StartedCountController CountContorller;
    void Start()
    {
       CountContorller = GetComponent<StartedCountController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //スタートボタンを押した時に呼ばれる関数
    public void OnClickButtonCountDown()
    {
        CountContorller.StartCountDown();
    }
}
