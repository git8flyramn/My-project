using UnityEngine;
using System.Collections.Generic;
public class WalkEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Animator anim;
    CharacterController con;
    bool IsWalk;
    Vector3 walkspeed = Vector3.left; 
    Vector3 StartPos;
    void Start()
    {
        anim = GetComponent<Animator>();
        con = GetComponent<CharacterController>();
        StartPos = transform.position;
        IsWalk = false;
    }

    // Update is called once per frame
    void Update()
    {
        IsWalk = true;
        anim.SetBool("IsWalk", IsWalk);
        con.Move(walkspeed * Time.deltaTime * 2);
        
    }
}
