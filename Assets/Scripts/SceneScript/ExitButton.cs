using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
public class ExitButton : MonoBehaviour
{
    private float BackTitlesTime = 2.0f;
    void Start()
    {
        Invoke("BackTitle", BackTitlesTime);
    }
    public void BackTitle()
    {
      
     SceneManager.LoadScene("Title");
        
    }
    
    void Update()
    {
       
    }
}
