using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player; //Объект за которым следует камера
    Rigidbody2D playerRigit;
    public float offset;
    float playerTransform;
    float playerTransform2;

    void Start()
    {
        
        playerRigit = player.GetComponent<Rigidbody2D>();
 
    }

    void LateUpdate()
    {
        //gameObject.transform.position = new Vector3(0f, player.transform.position.y + offset.y, -10f);
        playerTransform2 = player.transform.position.y;
        if (playerRigit.velocity.y <= 0 && playerTransform2 <= playerTransform)
        {
            playerTransform = player.transform.position.y;
            gameObject.transform.position = new Vector3(0f, playerTransform + offset, -10f);
        }
        else
            gameObject.transform.position = new Vector3(0f, playerTransform + offset, -10f);
    }
}
