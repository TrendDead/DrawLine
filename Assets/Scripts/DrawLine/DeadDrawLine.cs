using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadDrawLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        Debug.Log("a LLIo HE RABIT??!");
        //Destroy(gameObject);
    }

    void OnMouseDown()
    {
        Debug.Log("sdfdsfsd");
        Destroy(gameObject);
    }
}
