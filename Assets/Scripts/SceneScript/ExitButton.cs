using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
public class ExitButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float BackTitlesTime = 2.0f;
    void Start()
    {
        Invoke("BackTitle", BackTitlesTime);
    }

    // Update is called once per frame
    public void BackTitle()
    {
      
            SceneManager.LoadScene("Title");
        
    }
    
    void Update()
    {
       
    }
}
