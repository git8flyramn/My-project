using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using UnityEditor;
using TMPro;
public class GameClear : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

  
    [SerializeField] private string clearSceneName;
    private ClearTimeManeget cleartime;
    private float time = 0.0f;
    
    void Start()
    {
        cleartime = GetComponent<ClearTimeManeget>();
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.CompareTag("Player"))
        {
            cleartime.GetClearTime(time);
            SceneManager.LoadScene(clearSceneName);
        }

    }

}
