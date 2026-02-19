using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;
public class EnemyManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //public enum EnemyType{ WALK_ENEMY,RUN_ENEMY,NULL};

    //public GameObject WalkEnemy;
    //public Transform WalkEnemyPlace;
    //public GameObject RunEnemy;
    //public Transform RunEnemyPlace;


    [SerializeField] private ObjectPool pool;
                     private PooledObject enemy;
    void Start()
    {
        pool = GetComponent<ObjectPool>();
        pool.CallSetUpPool();

    }

    // Update is called once per frame
    void Update()
    {

        //if (TimeCount > 5)
        //{
        //    //敵の生成  誰を　　　　　　どの位置に　　　　　　　　どの方向
        //    Instantiate(WalkEnemy, WalkEnemyPlace.position, Quaternion.identity);
        //    Instantiate(RunEnemy, RunEnemyPlace.position, Quaternion.identity);
        //    TimeCount = 0;
        //}

        EnemyInstantiate();
    }

    void EnemyInstantiate()
    {
        enemy = pool.GetPooledObject();

        if(enemy != null)
        {
            enemy.transform.position = transform.position;
            enemy.transform.rotation = Quaternion.identity;
        }
    }

    public void Release()
    {
        enemy.Release();
    }
}
