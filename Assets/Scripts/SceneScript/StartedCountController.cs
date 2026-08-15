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
    private float GameStartTimer = 2.0f;
    private bool isCountDown = true;

    void Start()
    {
        CountDownText.gameObject.SetActive(true);
        CountDownText.text = "";
        stickcontroller = GameObject.Find("Player").GetComponent<StickController>();
        StartCountDown();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void  StartCountDown()
    {
       
        StartCoroutine(CountDownCoroutine());
    }


    IEnumerator CountDownCoroutine()
    {
          while (CountDownTime > 0)
            {
                CountDownText.text = CountDownTime.ToString();
                CountDownTime -= 1.0f;
                yield return new WaitForSeconds(Timer);
            }
            CountDownText.text = "GO!";
            isCountDown = false;
            yield return new WaitForSeconds(GameStartTimer);
        　　EndCountDown();
        　　CountDownText.gameObject.SetActive(false);
    }

    private void EndCountDown()
    {
        if (isCountDown == false)
        {
            stickcontroller.PlayerStartMove();
            isCountDown = true;
        }
    }

   

}




