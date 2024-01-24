using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SMInputController : MonoBehaviour
{
    #region Singleton
    public static SMInputController instance;
    #endregion
    private float startTime;
    private float endTime;
    private bool isResizing = false;
    [SerializeField] private float resizeSpeed;

    [SerializeField] private GameObject stick;
    private GameObject stickObject;
    public GameObject StickObject { get { return stickObject; } }
    float newYScale;

    private void Awake()
    {
        if(instance == null)
        {
             instance = this; 
        }
    }

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
            SMGameManager.instance.FallStick(stickObject);
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
}
