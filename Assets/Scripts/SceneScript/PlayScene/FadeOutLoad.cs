using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using UnityEditor;
public class GameOverSceneLoad : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

         
    //フェードアウトの機能を使う方


    [SerializeField] private FadeOutSceneLoder fadeOut;
    private SEManeger SE;
    public AudioClip clip;

    void Start()
    {

        SE = GetComponent<SEManeger>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("ぶつかりました。フェードアウトします");
            if(SE != null)
            {
                SE.GameOverSE(clip);
            }
            
            fadeOut.CallFadeOut();
        }
    }


}
