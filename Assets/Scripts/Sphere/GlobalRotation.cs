using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalRotation : MonoBehaviour //�������� ������ ���� �� �������������� ������ ����� ���
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
