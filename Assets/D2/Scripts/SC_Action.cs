using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace D2Action
{
    public class Action : MonoBehaviour
    {
        public static bool onRunning;
        public static bool onStrafeMode=false;
        public static bool canAttack;



        public enum MovementType
        {
            Directional,
            Strafe
        }
        public static MovementType typeMove;


    }

}
