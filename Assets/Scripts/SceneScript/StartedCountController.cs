using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class StartedCountController : MonoBehaviour
{


    public enum PlayState
    {
        None,
        Ready,
        Play,
    }
    [SerializeField]
    public PlayState CurrentState = PlayState.None;
    public TextMeshProUGUI CountDownText;
    private float CountDownTime = 3.0f; //カウントダウン用の変数
    private float timer = 1.0f;

    void Start()
    {
        CountDownText.gameObject.SetActive(true);
        CountDownText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void  StartCountDown()
    {
        CurrentState = PlayState.Ready;
        StartCoroutine(CountDownCoroutine());
    }


    IEnumerator CountDownCoroutine()
    {
       
        if (CurrentState == PlayState.Ready)
        {
            while (CountDownTime > 0)
            {
                CountDownText.text = CountDownTime.ToString();
                CountDownTime -= 1.0f;
                yield return new WaitForSeconds(timer);

            }

            CountDownText.text = "Start!";

            CurrentState = PlayState.Play;
            CountDownText.gameObject.SetActive(false);
        }
    }

}




