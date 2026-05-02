
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// using UnityEditor.ShaderGraph.Internal;
/// </summary>
public class ItemController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //アイテムの制御に必要な物
    public float DestroyTime;
    public float flowSpeed;
    public float RegenerateValue = 0.3f;
    public DashGauge stamina;
    private SEManeger SE;
    public AudioClip clip;
    void Start()
    {

        SE = GetComponent<SEManeger>();
    }

    // Update is called once per frame
    void Update()
    {
        ItemMove();
    }

    void ItemMove()
    {
        var Speed = Vector3.zero;
        Speed.z += flowSpeed;
        this.transform.Translate(Speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            DashGauge dc = collision.gameObject.GetComponent<DashGauge>();
          

            if (dc != null)
            {
                Debug.Log("playerに接触したのでplayerのスタミナを回復します");
                dc.RegenerateStamina(RegenerateValue);
                SEManeger.PlayerRunSE(clip);
            }
            else
            {
                Debug.LogWarning("接触したのはPlayerですが、StaminaControllerが見つかりません！");
            }
          
        }
    }
  
}
