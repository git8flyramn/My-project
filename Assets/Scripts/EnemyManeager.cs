using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //public GameObject RunEnemy;
    public GameObject WalkEnemy;
    public Transform WalkEnemyPlace;

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
            TimeCount = 0;
        }

        //Instantiate(WalkEnemy, WalkEnemyPlace.position, Quaternion.identity);
    }
}
