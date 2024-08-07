using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform object1; // �lk nesne
    public Transform object2; // �kinci nesne

    void Update()
    {
        // �ki nesne aras�nda bir ���n olu�tur
        Vector3 direction = object2.position - object1.position;
     
        // �ki nesne aras�ndaki a��y� hesapla
        float angle = Vector3.Angle(object1.forward, direction);

        // A��y� konsola yazd�r
        Debug.Log("�ki nesne aras�ndaki a��: " + angle);
    }
}
