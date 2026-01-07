using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManeager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //public GameObject RunEnemy;
    public GameObject WalkEnemy;

    public Transform WalkEnemyPlace;
    //public Transform RunEnemyPlace;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {                                                 //âÒì]ÇÕÉ[Éç
        Instantiate(WalkEnemy,WalkEnemyPlace.position,Quaternion.identity);
        //Instantiate(WalkEnemy, WalkEnemyPlace.position, Quaternion.identity);
    }
}
