using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3d : MonoBehaviour
{
   
    [Header("PlayerMovement")]
    public float _moveSpeedCurrent;
    public float _startMoveSpeed;
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
    bool isClimbing;
    public GameObject[] closeWay;

    [Header("Crouched")]
    public bool isStartCrouched = false;
    public bool isCrouched = false;
    public float _speedCrouched;
    public int num = 0;
    //private Collider _colliderCha;
    public GameObject _checkCeilie;


    [Header("CheckDistGround")]
    public LayerMask mask;
    public GameObject rayMark;
    //public Transform distanceGround;
    public float distanceGround;
    private Vector3 rotation;



    public CharacterController charController;
    private Vector3 moveDirection;
    private Vector3 moveDirection_C;
    public bool Isjump = false;
    public Vector3 _centerCharacter;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(distanceGround + "start");
        charController = GetComponent<CharacterController>();
        distanceGround = GetComponent<Collider>().bounds.extents.y;
        anim.SetBool("Jump", false);
        current = transform.position;
        //rigidbody = GetComponent<Rigidbody>();
        //charController.height = 1.78f;
        //_colliderCha = GetComponent<Collider>();
        _startMoveSpeed = _moveSpeedCurrent;
        closeWay[1].SetActive(false);
        _centerCharacter = charController.center;

    }
   

    // Update is called once per frame
    void Update()
    {
        Debug.Log("move" + _moveSpeedCurrent);
        Debug.Log("start" + _startMoveSpeed);


        if (GameManager.IsInputEnabled)
        {

            float yStore = moveDirection.y;
            //float hMove = Input.GetAxis("Horizontal");
            //float VMove = Input.GetAxis("Vertical");

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection.Normalize();
            moveDirection = moveDirection * _moveSpeedCurrent;
            moveDirection.y = yStore;


            //jump
            if (charController.isGrounded)
            {
                JumpInput();
                

            }
            else
            {

            }
            //Climb



            CrounchedInput();
            if (isCrouched)
            {

                _moveSpeedCurrent = 1f;

                CapsuleCollider mycc = GetComponent(typeof(CapsuleCollider)) as CapsuleCollider;
                mycc.height = 1.24f;
                mycc.center = new Vector3(0, 0.62f, 0);

                CharacterController cc = GetComponent(typeof(CharacterController)) as CharacterController;
                cc.height = 1.25f;
                cc.center = new Vector3(0, 0.64f, 0);
                //charController.height = 1.25f;



            }
            else
            {

                isCrouched = false;
                _moveSpeedCurrent = _startMoveSpeed;
                CapsuleCollider mycc = GetComponent(typeof(CapsuleCollider)) as CapsuleCollider;
                mycc.height = 1.78f;
                mycc.center = new Vector3(0, 0.94f, 0);


                CharacterController cc = GetComponent(typeof(CharacterController)) as CharacterController;
                cc.height = 1.86f;
                //cc.center = new Vector3(0, 0.96f, 0);
                charController.center = _centerCharacter;
            }

            CheckCeilie();



            //rotation
            //RotationChar();
            //transform.right = Vector3.Slerp(transform.right, Vector3.right * Input.GetAxis("Horizontal"), 0.1f);
            //if (moveDirection != Vector3.zero)
            //    transform.rotation = Quaternion.LookRotation(moveDirection);
           


            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;


            charController.Move(moveDirection * Time.deltaTime);



            anim.SetBool("isGrounded", charController.isGrounded);
            //anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal")))/*+ Mathf.Abs(Input.GetAxis("Vertical"))*/);
            anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal"))) + Mathf.Abs(Input.GetAxis("Vertical")));

            //CheckGround();
            //CheckBox();



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

            if (isClimb && !Isjump && !isCrouched)
            {

                if (Input.GetKey(KeyCode.W))
                {
                    isClimbing = true;
                    anim.SetBool("IsHang", false);
                    //charController.height = 1.22f;
                    //charController.center = new Vector3(0, 1.59f, 0);
                    gravityScale = 0;
                    transform.Translate(Vector3.up * Input.GetAxis("Vertical") * _speedCilmb * Time.deltaTime);
                    Debug.Log("up");
                    anim.SetBool("IsClimb", true);

                    //CapsuleCollider mycc = GetComponent(typeof(CapsuleCollider)) as CapsuleCollider;
                    //mycc.height = 1.35f;
                    //mycc.center = new Vector3(0, 1.71f, 0);
                }

                else if (Input.GetKey(KeyCode.S))
                {
                    isClimbing = true;
                    anim.SetBool("IsHang", false);
                    //charController.height = 1.22f;
                    //charController.center = new Vector3(0, 1.59f, 0);
                    //gravityScale = 1;
                    transform.Translate(Vector3.up * Input.GetAxis("Vertical") * _speedCilmb * Time.deltaTime);
                    anim.SetBool("IsClimb", true);
                    Debug.Log("down");

                    //CapsuleCollider mycc = GetComponent(typeof(CapsuleCollider)) as CapsuleCollider;
                    //mycc.height = 1.35f;
                    //mycc.center = new Vector3(0, 1.71f, 0);

                }


                else
                {

                    anim.SetBool("IsClimb", false);
                    //charController.height = 1.86f;
                    //charController.height = _startHeightChara;
                    //charController.height = _startHeightChara;
                    //charController.center = new Vector3(0, 0.64f, 0);
                    //_heightChara = charController.height;
                    anim.SetBool("IsHang", true);


                }
            }

            else
            {
                isClimbing = false;
                anim.SetBool("IsClimb", false);
                //charController.height = 1.86f;
                //charController.height = _startHeightChara;
                //charController.height = _startHeightChara;

                //_heightChara = charController.height;
            }




        }
    }

    private void CrounchedInput()
    {

        if (Input.GetKeyDown(KeyCode.C) && !Isjump)
        {
            Debug.Log("num = " + num);
            Debug.Log("crouched");
            isStartCrouched = true;
            anim.SetBool("IsStartCrouched", true);
            isCrouched = true;

            if (isCrouched && !Isjump)
            {

                num += 1;
                _moveSpeedCurrent = 1f;
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


        if (Input.GetKeyDown(KeyCode.Space) && !Isjump && !isCrouched && !isStartCrouched)
        {

            moveDirection.y = jumpForce;
            
            _moveSpeedCurrent = 3;
            anim.SetBool("Jump", true);
            Isjump = true;
            Debug.Log("Jump");
        }
        else
        {

            //_moveSpeed = 5;
            _moveSpeedCurrent = _startMoveSpeed;
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

    public void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Ladder")
        //{
        //    labber.transform.position = other.transform.position;
        //}

        //if(other.gameObject.tag== "Hang to crouch")
        //{
        //    GameManager.IsInputEnabled = false;
        //    anim.SetBool("Hang to crouch",true);
        //}

        if (other.gameObject.tag == "Getup")
        {
            transform.Translate(Vector3.right * 2);
            anim.SetBool("IsClimb", false);

            Debug.Log("can get up");
        }

    }

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
        closeWay[0].SetActive(false);
        closeWay[1].SetActive(true);
        //GameObject[] gameObj;
        //gameObj = GameObject.FindGameObjectsWithTag("Getup");
        //if (gameObj.Length == 1)
        //{
        //    gameObj[0].SetActive(false);
        //    Debug.Log("find get up obj");
        //}
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
    public void CheckCeilie()
    {
        RaycastHit hit;

        Debug.DrawRay(_checkCeilie.transform.position, transform.TransformDirection(Vector3.up) * 10f, Color.green);
        if (Physics.Raycast(_checkCeilie.transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.CompareTag("Ceiling"))
            {
                num = 0;
                Debug.Log("hitCeiling");
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.C))
                {
                    anim.SetBool("IsStartCrouched", false);
                }
            }
            //hit.collider.gameObject.GetComponent<ChangeColor>().BeenHit();
            Debug.Log("i've hit somthing");
        }
    }
}



    



