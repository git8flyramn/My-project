using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class GameClear : MonoBehaviour
{
    private SEManeger SE;
    public AudioClip clip;
    private float deleayTime = 0.9f;
    public TextMeshProUGUI ClearWord;
   

    void Start()
    {
        SE = GetComponent<SEManeger>();
        ClearWord.text = "";
        ClearWord.gameObject.SetActive(false);
        
    }
   
    void Update()
    {
        
    }

    //クリア時のSE再生関数
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Player"))
        {
            if(SE != null)
            {
                SE.ClearSE(clip);
               
            }
            StartCoroutine(ClrearSEWaitTime());
        }

    }

    //クリア後のSE待機時間関数
    IEnumerator ClrearSEWaitTime()
    {
        ClearWord.text = ClearWord.ToString();
        ClearWord.text = "GOAL!!!";
        ClearWord.gameObject.SetActive(true);
        yield return new WaitForSeconds(deleayTime);
        SceneManager.LoadScene("GameClear");
    }

}
