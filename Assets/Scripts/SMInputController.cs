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
    GameObject stickObject;
    float newYScale;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTime = Time.time;
            Vector3 stickPosition = SMObjectManager.instance.GetSpawnPositionFromBlock(SMObjectManager.instance.initialBlock);
            stickObject = Instantiate(stick, stickPosition, Quaternion.identity);
            isResizing = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            stickObject.transform.position = new Vector3(stickObject.transform.position.x, stickObject.transform.position.y + (stickObject.transform.localScale.y / 2), stickObject.transform.position.z);
            SMGameManager.Instance.FallStick(stickObject);
            isResizing = false;
        }

        if(isResizing)
        {
            float timeDifference = Time.time - startTime;
            newYScale = stickObject.transform.localScale.y +timeDifference  * resizeSpeed;
            if(stickObject.transform.localScale.y < Screen.height)
            {
                stickObject.transform.localScale = new Vector3(stickObject.transform.localScale.x, newYScale, stickObject.transform.localScale.z);
            }

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
