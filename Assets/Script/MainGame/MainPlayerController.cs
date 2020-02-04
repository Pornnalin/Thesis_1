using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerController : MonoBehaviour
{
    public static MainPlayerController instance;
    [Header("PlayerMovement")]
    public float _moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public GameObject playerModel;
    //private float Gravity = 20.0f;
    public bool isSlide = false;
    public Animator anim;
    float horizontaMove = 0f;
    public Transform scalePlayer;

    [Header("Climb")]
    public bool isClimb = false;
    public Vector3 current;
    //Rigidbody rigidbody;
    public float _speedCilmb;
    public Transform labber;

    [Header("Crouched")]
    public bool isStartCrouched = false;
    public bool isCrouched = false;
    public float _speedCrouched;
    public int num = 0;
    private float startHeight;


    [Header("CheckDistGround")]
    public LayerMask mask;
    public GameObject rayMark;
    //public Transform distanceGround;
    public float distanceGround;



    public CharacterController charController;
    private Vector3 moveDirection;
    private Vector3 moveDirection_C;
    public bool Isjump = false;
  


   
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(distanceGround + "start");
        charController = GetComponent<CharacterController>();
        distanceGround = GetComponent<Collider>().bounds.extents.y;
        anim.SetBool("Jump", false);
        current = transform.position;
        //rigidbody = GetComponent<Rigidbody>();
        charController.height = 1.78f;
        startHeight = charController.height;


    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        if (GameManager.IsInputEnabled)
        {

            float yStore = moveDirection.y;
            //float hMove = Input.GetAxis("Horizontal");
            //float VMove = Input.GetAxis("Vertical");

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0/* Input.GetAxis("Vertical")*/);
            moveDirection.Normalize();
            moveDirection = moveDirection * _moveSpeed;
            moveDirection.y = yStore;


            //jump
            if (charController.isGrounded)
            {
                JumpInput();
              

            }
            else
            {

            }

         

            //rotation
            //RotationChar();
            transform.right = Vector3.Slerp(transform.right, Vector3.right * Input.GetAxis("Horizontal"), 0.1f);

            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;
           

            charController.Move(moveDirection * Time.deltaTime);

           

            anim.SetBool("isGrounded", charController.isGrounded);
            anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal")))/*+ Mathf.Abs(Input.GetAxis("Vertical"))*/);

            //CheckGround();
            //CheckBox();
            if (isCrouched)
            {
                //_moveSpeed = 1f;
                //charController.center=Vector3.down*(startHeight-charController.height)/2.0f;
                
                CharacterController cc = GetComponent(typeof(CharacterController)) as CharacterController;
                cc.enabled = false;

            }
            else
            {
                _moveSpeed = 5f;
            }

        }
    }
    public void FixedUpdate()
    {
        if (GameManager.IsInputEnabled)
        {
            //checkGround while jump
            if (!Physics.Raycast(rayMark.transform.position, Vector3.down, distanceGround + 0.1f))
            {
                Debug.DrawLine(rayMark.transform.position, Vector3.down, Color.red);
                Debug.Log("we are in air");
                anim.SetBool("Jump", true);
                Debug.Log(distanceGround + "while fall");
                anim.SetBool("Lading", true);

            }
            else
            {
                Debug.Log(distanceGround + "end");
                Debug.Log("Ground");
                anim.SetBool("Lading", false);
                anim.SetBool("Jump", false);

            }

            //climb
            if (isClimb && !Isjump)
            {


                if (Input.GetKey(KeyCode.W))
                {
                    anim.SetBool("IsHang", false);
                    charController.height = 1.2f;
                    gravityScale = 0;
                    transform.Translate(Vector3.up * Input.GetAxis("Vertical") * _speedCilmb * Time.deltaTime);
                    Debug.Log("up");
                    anim.SetBool("IsClimb", true);



                }

                else if (Input.GetKey(KeyCode.S))
                {
                    anim.SetBool("IsHang", false);
                    charController.height = 1.2f;
                    //gravityScale = 1;
                    transform.Translate(Vector3.up * Input.GetAxis("Vertical") * _speedCilmb * Time.deltaTime);
                    anim.SetBool("IsClimb", true);
                    Debug.Log("down");
                }


                else
                {

                    anim.SetBool("IsClimb", false);
                    charController.height = 1.86f;
                    anim.SetBool("IsHang", true);


                }
            }

            else
            {
                anim.SetBool("IsClimb", false);
                charController.height = 1.86f;
            }

            CrounchedInput();

        }
    }

    private void CrounchedInput()
    {
        if (Input.GetKeyUp(KeyCode.C) && !Isjump)
        {
            Debug.Log("num = " + num);
            Debug.Log("crouched");
            isStartCrouched = true;
            anim.SetBool("IsStartCrouched", true);
            isCrouched = true;

            if (isCrouched && !Isjump)
            {

                num += 1;
                _moveSpeed = 1f;
                anim.SetBool("IsCrouching", true);
                anim.SetBool("Jump", false);
            }

        }

        if (num >= 2)
        {

            num = 0;
            isCrouched = false;
            isStartCrouched = false;
            anim.SetBool("IsStartCrouched", false);

        }
        else
        {


        }
    }
   
    private void JumpInput()
    {

        moveDirection.y = 0f;


        if (Input.GetKeyDown(KeyCode.Space) && !Isjump && !isCrouched  && !isStartCrouched) 
        {
           
            moveDirection.y = jumpForce;
            _moveSpeed = 3;
            anim.SetBool("Jump", true);
            Isjump = true;
            Debug.Log("Jump");
        }
        else
        {

            _moveSpeed = 5;
            anim.SetBool("Jump", false);
            Isjump = false;
        }


    }

    //bool isTrunRight;
    //private void RotationChar()
    //{
    //    Vector3 scaleP = scalePlayer.transform.localScale;
    //    float hMove = Input.GetAxis("Horizontal");

    //    if (hMove < 0)
    //    {
    //        isTrunRight = false;
    //        scaleP.z = -1;
    //    }
    //    if (hMove > 0)
    //    {
    //        isTrunRight = true;
    //        scaleP.z = 1;
    //    }
    //    scalePlayer.transform.localScale = scaleP;
    //}

    //public void OnTriggerEnter(Collider other)
    //{
    //    //if (other.gameObject.tag == "Ladder")
    //    //{
    //    //    labber.transform.position = other.transform.position;
    //    //}

    //    //if(other.gameObject.tag== "Hang to crouch")
    //    //{
    //    //    GameManager.IsInputEnabled = false;
    //    //    anim.SetBool("Hang to crouch",true);
    //    //}

        

    //}

    public void OnTriggerStay(Collider other)
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
        anim.SetBool("IsHang", false);
        //GameManager.IsInputEnabled = true;
        //anim.SetBool("Hang to crouch", false);

    }
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (charController.gameObject.tag == "ceiling")
        {
            Debug.Log("hit");
        }
       
    }

    public void CheckBox()
    {

        //Ray ray = new Ray(checkBox.transform.position, transform.right);
        //RaycastHit hitInfo;
        ////Debug.Log(ray);
        //if (Physics.Raycast(ray, out hitInfo, 1, mask, QueryTriggerInteraction.Ignore))
        //{
        //    Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
        //    print(hitInfo.collider.gameObject.tag);

        //    if (hitInfo.collider.CompareTag("Ob_Box"))
        //    {
        //        isFoundBox = true;
        //        Debug.Log("foundbox");
        //    }
        //    else
        //    {
        //        isFoundBox = false;
        //    }

        //}
    }
}



    

