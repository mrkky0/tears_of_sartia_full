using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCubeSpace;

public class RangeTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {Action.isEnemyTriggered = true;} 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {Action.isEnemyTriggered = false;}
    }
}
