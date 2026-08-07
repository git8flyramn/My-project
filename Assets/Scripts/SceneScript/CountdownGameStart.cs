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
    public Image ImageMask;
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
        CountdownCoroutine();
    }

    IEnumerator CountdownCoroutine()
    {
        Debug.Log("game Start");
        ImageMask.gameObject.SetActive(true);
        CountDownText.gameObject.SetActive(true);

        CountDownText.text = "3";
        yield return new WaitForSeconds(timer);

        CountDownText.text = "2";
        yield return new WaitForSeconds(timer);

        CountDownText.text = "1";
        yield return new WaitForSeconds(timer);

        CountDownText.text = "Let's Go!";
        ImageMask.gameObject.SetActive(false);
        CountDownText.gameObject.SetActive(false);
    }
}
