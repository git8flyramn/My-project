using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class StartedCountController : MonoBehaviour
{
    [SerializeField]
    
    public TextMeshProUGUI CountDownText;
    private StickController stickcontroller;
    private float CountDownTime = 3.0f; //カウントダウン用の変数
    private float Timer = 1.0f;
    private float GameStartTimer = 1.0f;

    void Start()
    {
        Initialize();
        StartCountDown();
    }

    private void Initialize()
    {
        CountDownText.gameObject.SetActive(true);
        CountDownText.text = "";
        stickcontroller = GameObject.Find("Player").GetComponent<StickController>();
    }

    void Update()
    {
    }

   

    public void  StartCountDown()
    {
       
        StartCoroutine(CountDownCoroutine());
    }


    IEnumerator CountDownCoroutine()
    {
        while(CountDownTime > -1)
        {
            CountDownText.text = CountDownTime.ToString();
            yield return new WaitForSeconds(Timer);
            CountDownTime--;
        }
            CountDownText.text = "GO!";
            yield return new WaitForSeconds(GameStartTimer);
        　　EndCountDown();
        　　CountDownText.gameObject.SetActive(false);
    }

    private void EndCountDown()
    {
      stickcontroller.PlayerIsStartMove();
    }

   

}




