using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SMPlayerController : MonoBehaviour
{
    #region Singleton
    private static SMPlayerController instance;
    public static SMPlayerController Instance //public property to access the singleton
    {
        get
        {
            if(instance == null) //if no instance exists, find or create the object and attach the script
            {
                instance = FindAnyObjectByType<SMPlayerController>();

                if(instance == null)
                {
                    //if no object with the script is found, create a new gameobject and attach the script 
                    GameObject smPlayerControllerObj = new GameObject("SMPlayerController");
                    instance = smPlayerControllerObj.AddComponent<SMPlayerController>();    
                }
            }
            return instance;
        }
    }
    #endregion
    #region Private Variables
    [SerializeField] private Transform stickPosition;
    #endregion

    #region Private Methods
    private void Awake()
    {
        if(instance == null) //checking only one instance of the singleton exists
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //Dont destroy the singleton when loading new scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    internal void AlignTheStick(GameObject _stickObject)
    {
        StartCoroutine(WaitForSomeTime());

        IEnumerator WaitForSomeTime()
        {
            yield return new WaitForSeconds(1f);
            float rotationSpeed = 5f;
          //  _stickObject.transform.eulerAngles = new Vector3(_stickObject.transform.eulerAngles.x, _stickObject.transform.eulerAngles.y, _stickObject.transform.eulerAngles.z + 90f * rotationSpeed;
          _stickObject.transform.DORotate(new Vector3 (0,0,-90), 1f).SetEase(Ease.InOutCirc);
          _stickObject.transform.position = new Vector3(_stickObject.transform.position.x / 2, _stickObject.transform.position.y - (_stickObject.transform.localScale.y / 2), _stickObject.transform.position.z);


        }

    }
    #endregion

}
