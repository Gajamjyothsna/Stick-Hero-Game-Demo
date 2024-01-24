using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMCollisionDetection : MonoBehaviour
{
    [SerializeField] private GameObject player;
    bool status;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    internal bool CheckPlayerHittingGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.down, 5f);
      //  Debug.Log("Hit collider object" + hit.collider.gameObject.name);

        Debug.DrawRay(player.transform.position, Vector2.down * 5f, Color.red);

        if (hit.collider != null)
        {
            Debug.Log("Hit collider object" + hit.collider.gameObject.name);
            status = true;
        }
        return status;
    }
}
