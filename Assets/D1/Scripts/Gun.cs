using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DataCubeSpace;

public class Gun : MonoBehaviour
{

    Animator gunAnimator;
    NavMeshAgent playerAgent;
    public KeyCode[] hotkeies;
    public Transform enemyTransform;

    private int animationHashA, animationHashS, animationHashD;
    //private string[] animationList = new string[] { "Base Layer.AttackAnims MA", "Dual Weapon Combo" , "AttackAnims D" };

    private List<string> animationList;

    // Start is called before the first frame update
    void Start()
    {
        animationList = new List<string>();

        foreach (string str in new string[] { "Base Layer.AttackAnims MA", "adas" })
        {
            animationList.Add(str);
        }
        animationHashA = Animator.StringToHash("Base Layer.AttackAnims MA");
        animationHashS = Animator.StringToHash("Base Layer.Dual Weapon Combo");
        animationHashD = Animator.StringToHash("Base Layer.AttackAnims D");

        gunAnimator = gameObject.GetComponent<Animator>();
        playerAgent = GetComponent<CharController>().gameObject.GetComponent<NavMeshAgent>();
    }


    void GunActive()
    {
      
                if (Input.GetKeyDown(KeyCode.A)/*&& Action.isAttackActive*/)
                {
                    playerAgent.isStopped = true;
                      playerAgent.ResetPath(); gunAnimator.SetBool("isPress_a", true);
                    //if(Action.canPressA) { player.transform.LookAt(GetComponent<CharController>().lookVec); Action.canPressA = false; }
                }

                if (Input.GetKeyDown(KeyCode.D)/*&& Action.isAttackActive*/)
                {
                    playerAgent.isStopped = true;
                      playerAgent.ResetPath(); gunAnimator.SetBool("isPress_d", true); 
                    if(Action.canPressA) { /*player.transform.LookAt(GetComponent<CharController>().lookVec/2); */Action.canPressA = false; }
                }

                if (Input.GetKeyDown(KeyCode.S)/*&& Action.isAttackActive*/)
                {
                    playerAgent.isStopped = true;
                      playerAgent.ResetPath(); gunAnimator.SetBool("isPress_w", true); 
                    //player.transform.LookAt(GetComponent<CharController>().lookVec);   
                }
     
            if (Input.GetKeyUp(KeyCode.A)/*&& Action.isAttackActive*/) {   playerAgent.ResetPath(); Action.isStopedWalkAttack = false; gunAnimator.SetBool("isPress_a", false); Action.isCompilatedPath = true; }
            if (Input.GetKeyUp(KeyCode.D)/*&& Action.isAttackActive*/) { playerAgent.ResetPath(); Action.isStopedWalkAttack = false; gunAnimator.SetBool("isPress_d", false); Action.isCompilatedPath = true; }
            if (Input.GetKeyUp(KeyCode.S)/*&& Action.isAttackActive*/) {   playerAgent.ResetPath(); Action.isStopedWalkAttack = false; gunAnimator.SetBool("isPress_w", false); Action.isCompilatedPath = true; }
        



    }
    



    // Update is called once per frame
    void Update()
    {
        
        //if (Input.GetKeyDown(hotkeies[0])|| Input.GetKeyDown(hotkeies[1])|| Input.GetKeyDown(hotkeies[2]))
        //{

        //    Vector3 direction = enemyTransform.position - transform.position;
        //    //Quaternion rotation = Quaternion.LookRotation(direction);
            

        //}

  
        if (IsAnimationPlaying(animationHashA)){ RotEq(0);}
        if (IsAnimationPlaying(animationHashS)) { RotEq(0); }
        if (IsAnimationPlaying(animationHashD)){   }
        GunActive();
 
 

     }
    bool IsAnimationPlaying(int animationHash)
    {
        // Þu anda oynatýlan animasyonun bilgisini al
        AnimatorStateInfo currentStateInfo = gunAnimator.GetCurrentAnimatorStateInfo(0);

        // Verilen animasyon hash deðeriyle þu anda oynatýlan animasyonun hash deðerini karþýlaþtýr
        // Eðer aynýysa, animasyon hala oynatýlýyor demektir
        return currentStateInfo.fullPathHash == animationHash;
    }

    void RotEq(int rotint)
    {
        Vector3 direction = enemyTransform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction - new Vector3(rotint, 0, 0));
        transform.rotation = rotation;
    }
}
