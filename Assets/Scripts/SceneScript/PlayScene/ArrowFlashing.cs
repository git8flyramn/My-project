using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ArrowFlashing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    MeshRenderer mesh;
    private float BlinkTime = 0.2f;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        StartCoroutine(BlinkArrow());
    }

    // Update is called once per frame
    
    IEnumerator BlinkArrow()
    {
        while(true)
        {
            for(int i = 0; i < 100; i++)
            {
                mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 1); 
            }
            yield return new WaitForSeconds(BlinkTime);

            for (int j = 0; j < 100; j++)
            {
                mesh.material.color = mesh.material.color + new Color32(0, 0, 0, 1);

            }

            yield return new WaitForSeconds(BlinkTime);
        }
    }
   
}
