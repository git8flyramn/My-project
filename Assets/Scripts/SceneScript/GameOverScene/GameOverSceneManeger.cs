using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverSceneManeger : MonoBehaviour
{
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }
}
