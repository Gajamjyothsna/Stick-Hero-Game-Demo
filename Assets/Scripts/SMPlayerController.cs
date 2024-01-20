using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMPlayerController : MonoBehaviour
{
    #region Singleton
    private static SMPlayerController instance;
    public static SMPlayerController Instance => instance;
    #endregion
    [SerializeField] private GameObject stick;
    [SerializeField] private Transform stickPosition;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void AlignTheStick()
    {

    }
   
}
