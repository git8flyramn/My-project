using UnityEngine;

public class LeftSideTrainMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody rb;
    private BothTrainMove BothTrain;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BothTrain = GetComponent<BothTrainMove>();
    }

    // Update is called once per frame
    void Update()
    {
        BothTrain.TrainLeftMove();
        Debug.Log("ThirdTrainÇ™ç∂Ç…ìÆÇ¢ÇƒÇ¢Ç‹Ç∑");
    }
}
