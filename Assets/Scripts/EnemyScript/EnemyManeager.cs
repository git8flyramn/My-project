using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;
public class EnemyManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //public enum EnemyType{ WALK_ENEMY,RUN_ENEMY,NULL};

     public GameObject WalkEnemy;
     public Transform WalkEnemyPlace;
     public GameObject RunEnemy;
     public Transform RunEnemyPlace;

   
    float time;
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        if (time > 5)
        {
            //敵の生成  誰を　　　　　　どの位置に　　　　　　　　どの方向
            Instantiate(WalkEnemy, WalkEnemyPlace.position, Quaternion.identity);
            Instantiate(RunEnemy, RunEnemyPlace.position, Quaternion.identity);
            time = 0;
        }
    }


}


//