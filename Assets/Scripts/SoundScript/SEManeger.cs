using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SEManeger : MonoBehaviour
{
    private AudioSource audioSource = null;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        
    }


    //各SE設定関数
    public void ItemSE(AudioClip clip)
    {
        if(audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("アイテムを取った音が登録されていません");
        }
    }

    public void ClearSE(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("クリア音が設定されていません");
        }
    }

    public void GameOverSE(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("ゲームオーバー音が設定されていません");
        }
    }

    public void TrainAccident(AudioClip clip)
    {
        if(audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("電車とplayerがぶつかった音が設定されていません");
        }
    }

    public void BlinkerSE(AudioClip clip)
    {
        if(audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }


}
