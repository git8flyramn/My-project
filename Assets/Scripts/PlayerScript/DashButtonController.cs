using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;
public class DashButtonController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] float tapTime = 2.0f;
    [SerializeField] UnityEvent OnLongTap;

    private float StartTimeCount = 0.0f;
    private bool isLongTap = false;
  
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void PointEnter()
   {
        isLongTap = true;
        StartTimeCount = Time.time;
   }

    private void FixedUpdate()
    {
        if(isLongTap)
        {
            float left_time = tapTime - (Time.time - StartTimeCount);

            if(left_time < 0)
            {
                isLongTap = false;
                StartTimeCount = 0.0f;
                OnLongTap?.Invoke();
            }
        }
    }

    public void PointExit()
    {
        if(isLongTap)
        {
            isLongTap = false;
        }
    }
}
