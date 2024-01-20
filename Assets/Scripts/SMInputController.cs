using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SMInputController : MonoBehaviour
{
    private float startTime;
    private float endTime;
    private bool isResizing = false;
    [SerializeField] private float resizeSpeed;

    [SerializeField] private GameObject stick;
    [SerializeField] private Transform stickPosition;
    GameObject stickObject;
    float newYScale;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.LogError("Mousedown");
            startTime = Time.time;
            stickObject = Instantiate(stick, stickPosition);
            isResizing = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.LogError("MouseUp");
            isResizing = false;
        }

        if(isResizing)
        {
            float timeDifference = Time.time - startTime;
            newYScale = stickObject.transform.localScale.y +timeDifference  * resizeSpeed;
            stickObject.transform.localScale = new Vector3(stickObject.transform.localScale.x, newYScale, stickObject.transform.localScale.z);
        }
    }
    float stickHeight;
    internal float GetSpriteHeight()
    {
        SpriteRenderer _stickSpriteRenderer = stickObject.GetComponent<SpriteRenderer>();

        if(_stickSpriteRenderer != null)
        {
            stickHeight = _stickSpriteRenderer.bounds.size.y;
        }
        return stickHeight; 
    }

}
