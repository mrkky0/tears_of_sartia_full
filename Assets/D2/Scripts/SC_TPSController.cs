using UnityEngine;
using D2Action;

public class SC_TPSController : Action
{
 
    Camera MainCam;
    // **************
    float InputX;
    float InputY;
    public int damp;
    public Transform Model;
    Vector3 StickDirection;
    [Range(0,20)]
    public float rotSpeed;
    [Range(0,20)]
    public float StrafeTurnSpeed;
    float maxSpeed;

    int attackIndex;

    public KeyCode SprintButton = KeyCode.LeftShift;
    public KeyCode WalkButton = KeyCode.C;
 

    Animator Anim;

    [HideInInspector]
    public bool canMove = true;




    

    void Start()
    {
   
         
        Anim = GetComponent<Animator>();
        MainCam = Camera.main;
    }

    void FixedUpdate()
    {
        Movement();
        InputMove(); 
        InputRot();
    }


    void Movement()
    {
        if(typeMove == MovementType.Directional)
        {
            StickDirection = new Vector3(InputX, 0, InputY);

            if (Input.GetKey(SprintButton))
            {
                InputX = 2.5f * Input.GetAxis("Horizontal"); InputY = 2.5f * Input.GetAxis("Vertical"); maxSpeed = 2.5f;
                onRunning = true;

            }
            else if (Input.GetKey(WalkButton))
            {
                InputX = Input.GetAxis("Horizontal"); InputY = Input.GetAxis("Vertical"); maxSpeed = .3f;
                onRunning = false;

            }
            else
            {
                InputX = Input.GetAxis("Horizontal"); InputY = Input.GetAxis("Vertical"); maxSpeed = 1f;
                onRunning = false;

            }
        }
        else if(typeMove == MovementType.Strafe)
        {
            InputX = Input.GetAxis("Horizontal"); InputY = Input.GetAxis("Vertical");
            Anim.SetFloat("iX", InputX, damp, Time.deltaTime * 10);
            Anim.SetFloat("iY", InputY, damp, Time.deltaTime * 10);

            var onMoving = InputX != 0 || InputY != 0;

            if (onMoving)
            {
                float yawCamera = MainCam.transform.rotation.eulerAngles.y;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), StrafeTurnSpeed * Time.fixedDeltaTime);
                Anim.SetBool("stafeMoving", true);

            }

            else
            {
                Anim.SetBool("stafeMoving", false);
            }


        }


    }

    void InputMove()
    {
        Anim.SetFloat("speed", Vector3.ClampMagnitude(StickDirection, maxSpeed).magnitude, damp, Time.deltaTime * 10);
       
    }

    void InputRot()
    {
        Vector3 rotOfset = MainCam.transform.TransformDirection(StickDirection);
        rotOfset.y = 0;
        Model.forward = Vector3.Slerp(Model.forward, rotOfset, Time.deltaTime * rotSpeed);


    }

}