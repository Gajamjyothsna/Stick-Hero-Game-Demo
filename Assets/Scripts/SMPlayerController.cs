using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SMGameManager : MonoBehaviour
{
    #region Singleton
    private static SMGameManager instance;
    public static SMGameManager Instance //public property to access the singleton
    {
        get
        {
            if(instance == null) //if no instance exists, find or create the object and attach the script
            {
                instance = FindAnyObjectByType<SMGameManager>();

                if(instance == null)
                {
                    //if no object with the script is found, create a new gameobject and attach the script 
                    GameObject smGameManagerObj = new GameObject("SMGameManager");
                    instance = smGameManagerObj.AddComponent<SMGameManager>();    
                }
            }
            return instance;
        }
    }
    #endregion
    #region Private Variables
    [SerializeField] private Transform stickPosition;
    [SerializeField] private GameObject player;
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
    internal void FallStick(GameObject _stickObject)
    {
        StartCoroutine(WaitForSomeTime());

        IEnumerator WaitForSomeTime()
        {
            yield return new WaitForSeconds(1f);
           _stickObject.transform.DORotate(new Vector3 (0,0,-90), .3f).SetEase(Ease.Linear);
           _stickObject.transform.position = new Vector3(_stickObject.transform.position.x + (_stickObject.transform.localScale. y/ 2), _stickObject.transform.position.y - (_stickObject.transform.localScale.y / 2), _stickObject.transform.position.z);


           
        }

    }
    #endregion

}
