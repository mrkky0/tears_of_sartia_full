using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using D2Action;

public class SC_WeaponController : Action
{
    Animator Anim;
     

    public GameObject handWeapon;
    public GameObject backWeapon;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Anim.SetBool("iS", onStrafeMode);

        if (Input.GetMouseButtonDown(0)&&onStrafeMode)
        {

            Anim.SetTrigger("attack");
            Debug.Log("any");



        }

        if (Input.GetKeyDown(KeyCode.F)) { onStrafeMode = !onStrafeMode; }
        if (!onStrafeMode) { typeMove = MovementType.Directional; } // GetComponent<SC_TPSController>().typeMove = SC_TPSController.MovementType.Directional;
        else if (onStrafeMode) { typeMove = MovementType.Strafe; } // GetComponent<SC_TPSController>().typeMove = SC_TPSController.MovementType.Strafe;
        handWeapon.SetActive(onStrafeMode);
    }

    void equip()
    {
        


    }

    void unequip()
    {
        handWeapon.SetActive(false);
        backWeapon.SetActive(true);
    }
}
