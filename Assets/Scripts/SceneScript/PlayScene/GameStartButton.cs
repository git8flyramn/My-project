using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameStartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private CountdownGameStart countdown;
    void Start()
    {
        countdown = GetComponent<CountdownGameStart>();
    }
    public void StartGame()
    {
        countdown.OnClickButtonStart();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
