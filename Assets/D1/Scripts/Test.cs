using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform object1; // Ýlk nesne
    public Transform object2; // Ýkinci nesne

    void Update()
    {
        // Ýki nesne arasýnda bir ýþýn oluþtur
        Vector3 direction = object2.position - object1.position;
     
        // Ýki nesne arasýndaki açýyý hesapla
        float angle = Vector3.Angle(object1.forward, direction);

        // Açýyý konsola yazdýr
        Debug.Log("Ýki nesne arasýndaki açý: " + angle);
    }
}
