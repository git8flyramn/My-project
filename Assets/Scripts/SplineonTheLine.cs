using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;
using Unity.VisualScripting;

//[ExecuteAlways]
public class SplineonTheRun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private SplineContainer spline;
    [SerializeField] private GameObject followObject;
    [SerializeField, Range(0, 1)] private float t;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //Splineや追従するオブジェクトが見つからなかった時にエラーを防止する
        if (!spline || !followObject)
        {
            return;
        }
        if (spline.CalculateLength() == 0f)
        {
            return;
        }
        //入力値の制限
        t = math.saturate(t);

        //Splineの計算
        spline[0].Evaluate(t, out float3 pos, out float3 tangent, out float3 up);

        //位置の反映
        followObject.transform.position = (Vector3)pos;

        if(math.any(tangent))
        {
            followObject.transform.rotation = Quaternion.LookRotation((Vector3)tangent, (Vector3)up);
        }
    }
}
