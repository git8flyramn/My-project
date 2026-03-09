using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;
using Unity.VisualScripting;

[ExecuteAlways]
public class SplineonTheRun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private SplineContainer spline;
    [SerializeField] private float speed = 5f;

    private float splinespped = 0;
    private float splineLength;

    void Start()
    {
        splineLength = spline.CalculateLength();
    }

    // Update is called once per frame
    void Update()
    {
        splinespped += (speed * Time.deltaTime) / splineLength;

        splineLength = Mathf.Clamp01(splinespped);

        Vector3 pos = spline.EvaluatePosition(splinespped);
        Vector3 dir = spline.EvaluateTangent(splinespped);

        transform.position = pos;
        transform.rotation = Quaternion.LookRotation(dir);
          
    }
}
