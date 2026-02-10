using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
public class ItemController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private StaminaController Stamina;
    public float DestroyTime;
    public float flowSpeed;
    float Addstamina = 0.5f;
    public float DestoryTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var Speed = Vector3.zero;
        Speed.z += flowSpeed;
        this.transform.Translate(Speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        /* playerがアイテムに触れたらアイテムを消滅させスタミナを回復する処理*/
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Playerに接触しました");
            Stamina.RegenerateStamina(Addstamina);
            Destroy(gameObject, DestoryTime);
        }
    }
}
