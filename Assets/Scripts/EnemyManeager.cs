using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public GameObject WalkEnemy;
    public Transform WalkEnemyPlace;
    public GameObject RunEnemy;
    public Transform RunEnemyPlace;

    float TimeCount;
    //public Transform RunEnemyPlace;
    void Start()
    {
        TimeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount += Time.deltaTime;
        if (TimeCount > 5)
        {
            Instantiate(WalkEnemy, WalkEnemyPlace.position, Quaternion.identity);
            Instantiate(RunEnemy, RunEnemyPlace.position, Quaternion.identity);
            TimeCount = 0;
        }

      

       
    }
}
