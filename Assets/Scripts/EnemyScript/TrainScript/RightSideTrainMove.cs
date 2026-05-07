using UnityEngine;

public class RightSideTrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    private BothTrainMove BothTrain;
    Vecotr3 Train = Vector.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BothTrain = GetComponent<BothTrainMove>();
    }

    // Update is called once per frame
    void Update()
    {
        RightTrainMove();
        Debug.Log("FourthTrain‚ª‰E‚É“®‚¢‚Ä‚¢‚Ü‚·");
    }

    public  void RightTrainMove()
    {
        Train = Vector3.right;
        rb.AddForce(Train * Initvelocity * MoveSpeed, ForceMode.Acceleration);
    }

}
