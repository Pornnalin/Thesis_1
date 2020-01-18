using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Vector3 m_Movement;
    Animator anim;
    public float tureSpeed;
    Quaternion m_Rotation = Quaternion.identity;
    Rigidbody rigi;
    //public static bool IsInputEnabled = true;
    public SomeBoxs someBoxs;
    public Transform current;
    public CameraControl cameraControl;
    public bool isControlPlayer;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody>();
        current.transform.position = transform.position;
        
    }

   
    // Update is called once per frame
    void FixedUpdate ()
    {
        if (cameraControl.switchInput == false) 
        {
            isControlPlayer = true;
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            m_Movement.Set(horizontal, 0f, vertical);
            m_Movement.Normalize();

            bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
            bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

            bool IsWalking = hasHorizontalInput || hasVerticalInput;
            anim.SetBool("IsWalking", IsWalking);

            Vector3 desireForward = Vector3.RotateTowards(transform.forward, m_Movement, tureSpeed * Time.deltaTime, 0f);
            m_Rotation = Quaternion.LookRotation(desireForward);

        }
        else
        {
            Debug.Log(cameraControl.switchInput);
            Debug.Log("switchInput");
            float horizontal = Input.GetAxis("Horizontal_Inverst");
            float vertical = Input.GetAxis("Vertical_Inverst");
            m_Movement.Set(horizontal, 0f, vertical );
            m_Movement.Normalize();

            bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
            bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

            bool IsWalking = hasHorizontalInput || hasVerticalInput;
            anim.SetBool("IsWalking", IsWalking);

            Vector3 relative = Vector3.RotateTowards(transform.forward, m_Movement, tureSpeed * Time.deltaTime, 0f);
            m_Rotation = Quaternion.LookRotation(relative);
            relative = transform.InverseTransformDirection(Vector3.forward);
        }
       

     



        //anim.SetFloat("Forward", horizontal);
        //anim.SetFloat("Strafe", vertical);

    }

   
    public void Update()
    {
        StartPickup();

        if (Input.GetKeyDown(KeyCode.F) && someBoxs.isBoxInHand)
        {
            anim.SetBool("IsPickUp", false);
            someBoxs.DropItem();
            isPickup = false;
            //current.transform.position = transform.position;
            someBoxs.isBoxInHand = false;
            Debug.Log("Drop");
        }




    }


    public void OnAnimatorMove()
    {
        //rigi.MovePosition(transform.position + transform.forward * Time.deltaTime );
        rigi.MovePosition(rigi.position + m_Movement * anim.deltaPosition.magnitude);
        rigi.MoveRotation(m_Rotation);
    }

    bool isPickup;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            isPickup = true;
           

        }
        
        
    }

    public void OnTriggerExit(Collider other)
    {
        isPickup = false;
    }

    public void StartPickup()
    {
        if (isPickup)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("IsPickUp", true);
                someBoxs.PickUpItem();
                //current.transform.position = transform.position;
            }
           

        }
        else
        {
            isPickup = false;
        }
    }
}

