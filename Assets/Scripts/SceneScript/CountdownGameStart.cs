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
    private float CountDownTime = 3.0f; //カウントダウン用の変数
    private float timer = 1.0f;
   

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
        StartCoroutine(CountDownCorutine());
    }

    IEnumerator CountDownCorutine()
    {
       
        while (CountDownTime > 0)
        {
            CountDownText.text = CountDownTime.ToString();
            CountDownTime -= 1.0f;
            yield return new WaitForSeconds(timer);
           
        }
        CountDownText.text = "Start!";
        SceneManager.LoadScene("Egorun", LoadSceneMode.Single);
       

    }
}
