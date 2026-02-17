using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FadeOutSceneLoder : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // フェードアウトの機能部分
    
    
    public Image fadePanel;//フェード用のパネル
    public float fadeTime = 1.0f; //フェードの完了にかかる時間

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
        
    public IEnumerator FadeOutLoadScene()
    {
        fadePanel.enabled = true;//パネルを有効化
        float elapsedTime = 0.0f;//経過時間を初期化
        Color startColor = fadePanel.color;//フェードパネルの開始の色を取得
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeTime);//フェードの進行度の計算
            fadePanel.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }
        fadePanel.color = endColor;
        SceneManager.LoadScene("GameOver");
    }

    public void CallFadeOut()
    {
        FadeOutLoadScene();
    }

}
