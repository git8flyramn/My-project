using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
public class CountdownGameStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    public TextMeshProUGUI CountDownText;
    //public Image ImageMask;
    private float timer = 1.0f;
    int count = 3;
    void Start()
    {
        CountDownText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButtonStart()
    {
        Debug.Log("game Start");
   
        StartCoroutine(CountdownCoroutine());
        
    }

    IEnumerator CountdownCoroutine()
    {
      while(count > 0)
      {
            CountDownText.text = count.ToString();
            yield return new WaitForSeconds(timer);
            count--;
      }
       
    }
}
