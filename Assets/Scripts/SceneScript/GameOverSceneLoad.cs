using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
public class GameOverSceneLoad : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

         
    //フェードアウトの機能を使う方


    private FadeOutSceneLoder fadeOut;
    public string ObjectName;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(ObjectName))
        {
            FadeOutSceneLoder fs;
            fs = other.GetComponent<FadeOutSceneLoder>();
            fs.CallFadeOut();
        }
    }


}
