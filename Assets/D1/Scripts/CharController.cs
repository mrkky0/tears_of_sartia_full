using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DataCubeSpace;

public class CharController : MonoBehaviour
{
    Animator animator;
    Vector3 moveVec;
    Rigidbody rb;
    NavMeshAgent agent;
    public RaycastHit hit;
    public GameObject cursorLightObj;
    public int value;
    public LayerMask layerMask;
    public Vector3 highMoveVec;
    Light lightCursor;
    Vector3 highHitPointVec; Vector3 waitPosYVec; Vector3 cursorVec;
    Vector3 dashVec;
    public Vector3 lookVec;
    private bool _isGunAccess;
    public GameObject[] swords;
    Quaternion rotGoal;
    Vector3 directionPlayer;
    



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        agent = GetComponent<NavMeshAgent>();
        GameEvents.OnClikedOps1 += Event_OnClikedOps1;
        lightCursor = cursorLightObj.gameObject.GetComponent<Light>();
        swords = GameObject.FindGameObjectsWithTag("sword");






    }

    public void FightMode()
    {
        if (_isGunAccess && Input.GetKeyDown(KeyCode.R)) { swords[0].SetActive(false); swords[1].SetActive(false); _isGunAccess = false; }
        if (!_isGunAccess && Input.GetKeyDown(KeyCode.R)) { swords[0].SetActive(true); swords[1].SetActive(true); _isGunAccess = true; }
    }
    
   public void ShootMac()
    {

        //float hor = Input.GetAxis("Horizontal"); float ver = Input.GetAxis("Vertical"); float speed = 5f;
        //Vector2 normal = new Vector2(hor, ver).normalized * speed;
        //Vector3 moveDicAt = new Vector3(normal.x, 0, normal.y);
        //if (Input.GetKeyDown(KeyCode.W)) { transform.Rotate(Vector3.up*90); }
        //else if (Input.GetKeyDown(KeyCode.A)) { transform.Rotate(-Vector3.up * 90);}
        //if (Input.GetKeyDown(KeyCode.S)) { transform.Rotate(Vector3.up * 135); }
        //else if(Input.GetKeyDown(KeyCode.D)) { transform.Rotate(-Vector3.up * 135); }
 

    }

    public void LookDirectAndMove(Vector3 targetAIVec)
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         
        float playerToMouseDis = Vector3.Distance(hit.point, transform.position);
        if (Physics.Raycast(ray, out hit, layerMask)/*LayerMask.GetMask("Ground"))*/&& playerToMouseDis > 1f)
        {
            cursorVec = new Vector3(hit.point.x, 1f, hit.point.z);
            cursorLightObj.transform.position = cursorVec;

            if (Input.GetKeyDown(KeyCode.LeftShift)) { agent.speed = agent.speed*2f;  }
            if (Input.GetKeyUp(KeyCode.LeftShift)) { agent.speed = agent.speed/2f;  }

        }


        if (Input.GetMouseButton(0)&&hit.collider.tag=="Ground")
        {

           
            Action.isStopedWalkAttack = true;
            highMoveVec = targetAIVec;
            highHitPointVec = hit.point;
            Vector3 DisfootAndPlayer = new Vector3(transform.position.x, 0, transform.position.z);
          
            if (Vector3.Distance(DisfootAndPlayer, highHitPointVec) > 1.5f) {
                agent.SetDestination(highHitPointVec);
                directionPlayer = (hit.point - transform.position).normalized;
                rotGoal = Quaternion.LookRotation(directionPlayer);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, 1f);
         

            }
            if (Vector3.Distance(DisfootAndPlayer, highHitPointVec) <= 1.5f) { Action.isCompilatedPath = false; }
 
        }



        if (Vector3.Distance(transform.position, highHitPointVec) < 1.2f) { Action.isCompilatedPath = true; }
        else if (Vector3.Distance(transform.position, highHitPointVec) != 0 && Action.isStopedWalkAttack) { Action.isCompilatedPath = false; } 
     
        animator.SetBool("canWalk", Action.isCompilatedPath);

        //if (Input.GetMouseButtonDown(1) &&  !Action.isAttackActive) { Action.isAttackActive = true; lightCursor.color = Color.red; }
        //else if (Input.GetMouseButtonDown(1)  && Action.isAttackActive) { Action.isAttackActive = false; lightCursor.color = Color.green;  }

        if(agent.isPathStale) { animator.SetBool("isAttackStates", Action.isAttackActive); }
        //if (Action.isCompilatedPath && Vector3.Distance(transform.position,hit.point) > 1f) { if (!Action.isAttackActive) { transform.LookAt(hit.point); } }













    }

    // Update is called once per frame
    void Update()
    {
        lookVec = new Vector3(hit.point.x, hit.point.y + 1.5f, hit.point.z);
 


        //ShootMac();
        LookDirectAndMove(lookVec);
        FightMode();








    }

    private void Event_OnClikedOps1()
    {
        //Debug.Log("CodeBlocks!");
    }
}
