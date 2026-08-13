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
    private float timer = 1.0f;
    private bool isCountDown = true;

    void Start()
    {
        stickcontroller = GetComponent<StickController>();
        if(stickcontroller == null)
        {
            Debug.Log("stickcontroller is null");
        }
        CountDownText.gameObject.SetActive(true);
        CountDownText.text = "";
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
                yield return new WaitForSeconds(timer);
            }
            CountDownText.text = "GO!";
            isCountDown = false;
            IsStartedGame(isCountDown);
           yield return new WaitForSeconds(timer);
            CountDownText.gameObject.SetActive(false);
    }

    private bool IsStartedGame(bool isStartGame)
    {
        if(isStartGame == false)
        {
            stickcontroller.isGameStarted = true;
            isStartGame = true;
            return isStartGame;
        }
        return isStartGame;
    }

}




