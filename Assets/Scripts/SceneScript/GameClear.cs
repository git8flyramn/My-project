using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class GameClear : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private SEManeger SE;
    public AudioClip clip;
    private float deleayTime = 0.9f;
   
    void Start()
    {
        SE = GetComponent<SEManeger>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Player"))
        {
            if(SE != null)
            {
                SE.ClearSE(clip);
                Debug.Log("‰¹º‚ª–Â‚è‚Ü‚µ‚½");
            }
            StartCoroutine(ClrearSEWaitTime());
        }

    }

    IEnumerator ClrearSEWaitTime()
    {
        yield return new WaitForSeconds(deleayTime);
        Debug.Log("ƒQ[ƒ€ƒNƒŠƒA‚Ì”»’è‚ğæ‚è‚Ü‚µ‚½");
        SceneManager.LoadScene("GameClear");
    }

}
