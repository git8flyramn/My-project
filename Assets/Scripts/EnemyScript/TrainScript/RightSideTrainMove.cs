using UnityEngine;

public class RightSideTrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    private BothTrainMove BothTrain;
    private float MoveSpeed = 2.0f;
    private float Initvelocity = 2.0f;
    Vector3 Train = Vector3.zero;
    private BothTrainMove BothTrain;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BothTrain = GetComponent<BothTrainMove>();
    }

// Update is called once per frame
void Update()
    {
        BothTrain.RightTrainMove();
        Degug.Log("ê≥èÌÇ…ìÆçÏ");
    }

}
