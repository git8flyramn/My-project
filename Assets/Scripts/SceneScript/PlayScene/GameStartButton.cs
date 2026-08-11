using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GameStartButton : MonoBehaviour
{
    void Start()
    {
       
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Egorun", LoadSceneMode.Single);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
