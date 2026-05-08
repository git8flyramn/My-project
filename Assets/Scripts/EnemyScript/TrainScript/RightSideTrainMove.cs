using UnityEngine;

public class RightSideTrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    private BothTrainMove BothTrain;
    Vector3 Train = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BothTrain = GetComponent<BothTrainMove>();
    }

    // Update is called once per frame
    void Update()
    {
        BothTrain.TrainRightMove();
      // BothTrain.TrainLeftMove();
        Debug.Log("FourthTrain‚ª‰E‚É“®‚¢‚Ä‚¢‚Ü‚·");
    }

  

}
