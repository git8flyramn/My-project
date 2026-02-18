using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
public class GameOverSceneLoad : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

         
     public FadeOutSceneLoder fadeout;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //FadeOutSceneLoder
            fadeout = collision.gameObject.GetComponent<FadeOutSceneLoder>();
            if (fadeout != null)
            {
                Debug.Log("フェードアウトします");
                fadeout.CallFadeOut();
            }
            else
            {
                Debug.Log("fadeoutSceneLoderが見つかりません");
            }
        }

    }

    
}   
