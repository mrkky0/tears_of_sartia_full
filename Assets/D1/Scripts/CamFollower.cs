using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.0f;
 
    private Vector3 velocity = Vector3.one;
    Vector3 XVec = new Vector3(0f, 10f, -10f);
    // Start is called before the first frame update
    void Start()
    {

     }

    // Update is called once per frame
    private void LateUpdate()
    {

        Vector3 goalPos = target.localPosition + XVec;
        goalPos.y = transform.position.y;
        transform.localPosition = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
    }
}
