using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalRotation : MonoBehaviour //Дочерний объект шара не поворачивается вокруг своей оси
{
    Transform rotationSphere;
    void Start()
    {
        rotationSphere = GetComponent<Transform>();
    }

    void Update()
    {
        rotationSphere.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
