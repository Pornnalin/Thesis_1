using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerController : MonoBehaviour
{
    [Header("PlayerMovement")]
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    //private float Gravity = 20.0f;
    public bool isSlide = false;
    public Animator anim;
    float horizontaMove = 0f;
    public Transform scalePlayer;
    [Header("Climb")]
    public bool isClimb = false;

    [Header("CheckDistGround")]
     public LayerMask mask;
    public GameObject rayMark;
    //public Transform distanceGround;
    public float distanceGround;



    private CharacterController charController;
    private Vector3 moveDirection;
    private Vector3 moveDirection_C;
    private bool Isjump = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(distanceGround + "start");
        charController = GetComponent<CharacterController>();
        distanceGround = GetComponent<Collider>().bounds.extents.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.IsInputEnabled)
        {
            float yStore = moveDirection.y;
            //float hMove = Input.GetAxis("Horizontal");
            //float VMove = Input.GetAxis("Vertical");

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection.Normalize();
            moveDirection = moveDirection * moveSpeed;
            moveDirection.y = yStore;


            //jump
            if (charController.isGrounded)
            {
                JumpInput();
                //if (isClimb)
                //{
                //    StartClimb();
                //}

            }
            else
            {
              
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                if (isClimb)
                {
                    StartClimb();
                    anim.SetBool("IsClimb", true);
                }
            }
            
            //if (Input.GetKeyDown(KeyCode.W))
            //{
            //    Debug.Log("up");
                
            //}
           
            //rotation
            RotationChar();
           
            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;
            //moveDirection.y -= Gravity * Time.deltaTime;
            //Debug.Log("gravity" + Physics.gravity.y);

            charController.Move(moveDirection * Time.deltaTime);



            anim.SetBool("isGrounded", charController.isGrounded);
            anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal"))));
         
            //CheckGround();

        }
    }
    public void FixedUpdate()
    {
        if (!Physics.Raycast(transform.position, -Vector3.up, distanceGround + 0.1f))
        {
            Debug.DrawLine(rayMark.transform.position, -Vector3.up, Color.red);
            Debug.Log("we are in air");
            anim.SetBool("Jump", true);
            Debug.Log(distanceGround+"while fall");
            //anim.SetBool("Lading", true);

        }
        else
        {
            Debug.Log(distanceGround + "end");
            Debug.Log("Ground");
            //anim.SetBool("Lading", false);
        }
    }
    private void JumpInput()
    {

        moveDirection.y = 0f;


        if (Input.GetKeyDown(KeyCode.Space) && !Isjump)
        {
            moveDirection.y = jumpForce;
            moveSpeed = 3;
            anim.SetBool("Jump", true);
            Isjump = true;
            Debug.Log("Jump");
        }
        else
        {
            moveSpeed = 5;
            anim.SetBool("Jump", false);
            Isjump = false;
        }


    }
    private void RotationChar()
    {
        Vector3 scaleP = scalePlayer.transform.localScale;
        float hMove = Input.GetAxis("Horizontal");

        if (hMove < 0)
        {
            scaleP.z = -1;
        }
        if (hMove > 0)
        {
            scaleP.z = 1;
        }
        scalePlayer.transform.localScale = scaleP;
    }

    private void CheckGround()
    {

        //Ray ray = new Ray(rayMark.transform.position, -transform.up);
        //RaycastHit hitInfo;
        //Debug.Log(ray);
        //if (Physics.Raycast(ray, out hitInfo, 30, mask, QueryTriggerInteraction.Ignore))
        //{
        //    Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
        //    print(hitInfo.collider.gameObject.tag);

        //    if (hitInfo.collider.tag == "ground")
        //    {
        //        Debug.Log(isSlide + "1");
        //        isSlide = true;

        //    }


        //}
        //else
        //{

        //    Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
        //    Debug.Log(isSlide + "2");
        //}


    }

    public void StartClimb()
    {
        gravityScale = -1 * Time.deltaTime;
        float VMove = Input.GetAxis("Vertical");
             
        Debug.Log("Climb");
        moveDirection_C = new Vector3(Input.GetAxis("Vertical"), 0, 0);

        //charController.Move(moveDirection_C * Time.deltaTime);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical"))));

        //anim.SetBool("IsClimb", true);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ladder") 
        {
            Debug.Log("ClimbAnimation");
            isClimb = true;
            //moveDirection = new Vector3(0, Input.GetAxis("Vertical"), 0);
            //anim.SetBool("IsClimb", true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        isClimb = false;
        anim.SetBool("IsClimb", false);
        gravityScale = 3;
    }


}

    

