using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ChangeDirection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private BothTrainMove BothTrain;
    private Vector3 ChangeDir = Vector3.forward;
    void Start()
    {
        BothTrain = GetComponent<BothTrainMove>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnTriggerEnter(Collider other)
    {
                           //ChageDirPoint
        if (other.CompareTag("train"))
        {
            Debug.Log("“dÔ‚ÌŒü‚«‚ª•ÏX‚³‚ê‚Ü‚µ‚½");
            BothTrain.ChangeTrainDir(ChangeDir);
           
        }
        else
        {
            Debug.LogWarning("Œü‚«‚ª•ÏX‚³‚ê‚Ä‚¢‚Ü‚¹‚ñ");
        }
    }
}
