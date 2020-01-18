using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public Animator anim;
    public bool factRight;
    float horizontaMove = 0f;
    public Transform scalePlayer;

    private CharacterController controller;
    private Vector3 moveDirection;
    private bool Isjump = false;

    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        controller = GetComponent<CharacterController>();

        Vector3 scaleP = scalePlayer.transform.localScale;

        float yStore = moveDirection.y;
        float hMove = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        moveDirection.Normalize();
        moveDirection = moveDirection * moveSpeed;
        moveDirection.y = yStore;


        //jump
        if (controller.isGrounded)
        {
            moveDirection.y= 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
                Isjump = true;
                Debug.Log("Jump");
            }
        }

        //rotation
        if (hMove < 0)
        {
            scaleP.z = -1;
        }
        if (hMove > 0)
        {
            scaleP.z = 1;
        }
        scalePlayer.transform.localScale = scaleP;


        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;
        //Debug.Log("gravity" + Physics.gravity.y);
       

        controller.Move(moveDirection * Time.deltaTime);
       

        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal"))));

       
    }
    


}
    

