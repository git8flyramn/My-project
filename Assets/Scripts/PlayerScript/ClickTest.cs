using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class ClickTest : MonoBehaviour, IPointerClickHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked" + eventData.pointerCurrentRaycast.gameObject.name);

    }
}
