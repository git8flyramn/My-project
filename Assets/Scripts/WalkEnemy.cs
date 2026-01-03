using UnityEngine;
using System.Collections.Generic;
public class WalkEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Animator anim;
    CharacterController con;
    bool IsWalk;
    Vector3 StartPos;
    void Start()
    {
        anim = GetConmponent<Animator>();
        con = GetComponent<CharactorController>();
        StartPos = transform.position;
        IsWalk = false;
    }

    // Update is called once per frame
    void Update()
    {
      
        IsWalk = true;
        anim.SetBool("IsWalk", IsWalk);
    }
}
