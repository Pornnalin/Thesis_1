using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_test : MonoBehaviour
{
    //Vector3 m_Movement;
    public Animator anim;
    public float turnSpeed;
    Rigidbody rigi;
    //public static bool IsInputEnabled = true;
    public SomeBoxs someBoxs;
    public Transform current;
    public bool facinfRignt;
    //jump
    bool ground = false;
    Collider[] groroundCollisions;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;
    public bool jump;
 
    void Start()
    {
        anim = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody>();
       
        facinfRignt = true;
    }

   
    // Update is called once per frame
    void FixedUpdate ()
    {
        if (GameManager.IsInputEnabled) 
        {
            if (ground && Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
                ground = false;
                anim.SetBool("IsGround", ground);
                rigi.AddForce(new Vector3(0, jumpHeight, 0));
            }
            //groroundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius,groundLayer);
            //if (groroundCollisions.Length > 0)
            //{
            //    ground = true;
            //}
            //else
            //{
            //    ground = false;
            //}
            //anim.SetBool("IsGround", ground);

            float move = Input.GetAxis("Horizontal");
            anim.SetFloat("Speed", Mathf.Abs(move));

            rigi.velocity = new Vector3(move *turnSpeed, rigi.velocity.y, 0);

            if (move > 0 && !facinfRignt)
            {
                Flip();
            }
            else if(move<0&& facinfRignt)
            {
                Flip();
            }
        }
        else
        {
            facinfRignt = !facinfRignt;

        }
       

     



        //anim.SetFloat("Forward", horizontal);
        //anim.SetFloat("Strafe", vertical);

    }
  

    

    void Flip()
    {
        facinfRignt = !facinfRignt;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
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

