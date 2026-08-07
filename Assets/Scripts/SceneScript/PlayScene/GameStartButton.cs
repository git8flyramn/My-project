using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
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
        CountdownCoroutine();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CountdownCoroutine()
    {
        countdown.OnClickButtonStart();
        Debug.Log("game Start");
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("Egorun", LoadSceneMode.Single);
    }
