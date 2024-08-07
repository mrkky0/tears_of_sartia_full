using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using D2Action;

public class SC_IKLook : Action
{
    Animator anim;
    Camera mainCam;
    float weigth=1;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        mainCam = Camera.main;
    }
    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetLookAtWeight(weigth, .05f, 0.5f, .5f, .5f);

        Ray lookAtRay = new Ray(transform.position, mainCam.transform.forward);
        anim.SetLookAtPosition(lookAtRay.GetPoint(25));
        if (!onRunning ) { weigth = Mathf.Lerp(weigth, 1, Time.fixedDeltaTime); }
        if (onRunning ) { weigth = Mathf.Lerp(weigth, 0, Time.fixedDeltaTime); }
        if (!onStrafeMode) { weigth = Mathf.Lerp(weigth, 1, Time.fixedDeltaTime); }
        if (onStrafeMode) { weigth = Mathf.Lerp(weigth, 0, Time.fixedDeltaTime); }



    }

}
