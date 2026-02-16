using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
public class GameOverSceneLoad : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

         
    private FadeOutSceneLoder fadeout;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GameOver()
    {
        fadeout.CallFadeOut();
    }
    private void OnTriggerEnter(Collider other)
    {
        fadeout = other.gameObject.GetComponent<FadeOutSceneLoder>();
        if (fadeout != null)
        {
            Debug.Log("フェードアウトします");
            GameOver();
        }
        else
        {
            Debug.Log("fadeoutSceneLoderが見つかりません");
        }
    }


}
