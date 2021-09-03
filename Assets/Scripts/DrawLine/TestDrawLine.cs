using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDrawLine : MonoBehaviour
{
    LineRenderer line;
    Color c1 = new Color(1f, 1f, 1f, 1f);
    Color c2 = new Color(0.1f, 0.1f, 1f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        

        line = transform.GetComponent<LineRenderer>();
        line.SetVertexCount(5);
        line.SetColors(c1, c2);
        line.SetWidth(0.1f, 0.1f);
        line.SetPosition(0, new Vector3(-1, 1, 0));
        line.SetPosition(1, new Vector3(1, 1, 0));
        line.SetPosition(2, new Vector3(1, -1, 0));
        line.SetPosition(3, new Vector3(-1, -1, 0));
        line.SetPosition(4, new Vector3(-1, 1, 0));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
