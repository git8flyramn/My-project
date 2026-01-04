using System.Collections.Generic;
public class WalkEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Animator anim;
    CharacterController con;
    bool IsRun;
    Vector3 Runspeed = Vector3.left;
    Vector3 StartPos;
    void Start()
    {
        anim = GetComponent<Animator>();
        con = GetComponent<CharacterController>();
        StartPos = transform.position;
        IsRun = false;
    }

    // Update is called once per frame
    void Update()
    {
        IsRun = true;
        anim.SetBool("IsRun", IsRun);
        con.Move(walkspeed * Time.deltaTime * 2);

    }
}
