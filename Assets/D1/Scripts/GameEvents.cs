using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCubeSpace;

 public class GameEvents : MonoBehaviour
{
    public delegate void OnCliked();

    //public static event OnCliked OnLeftCliked;
    public static event OnCliked OnClikedOps1;

    private void Start()
    {
        //OnLeftCliked += () => {/*/...function*/ };
        OnClikedOps1 += () => { /*/...function*/ /*Test_x();*/ } ;
       
    }

    
    //void Test_x()
    //{
 
    //    Debug.Log("CodeBlock!");
    //}

    private void Update()
    {
        //There is about the trigger for what (kosul yazilir.)

        if (Action.isEnemyTriggered) {OnClikedOps1();}
 
    
        
    }






}
