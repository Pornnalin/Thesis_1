using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerController_yest : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public Animator anim;

    private CharacterController charController;
    private Vector3 moveDirection;
    private bool Isjump = false;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {



        //Vector3 scaleP = scalePlayer.transform.localScale;


        //float hMove = Input.GetAxis("Horizontal");
        //float VMove = Input.GetAxis("Vertical");
        float yStore = moveDirection.y;
        //moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, 0);
        moveDirection = (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        //jump
        JumpInput();
        if (charController.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        //rotation



        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        //Debug.Log("gravity" + Physics.gravity.y);

        charController.Move(moveDirection * Time.deltaTime);

        anim.SetBool("isGrounded", charController.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal"))));



    }
    private void JumpInput()
    {
        //if (charController.isGrounded)
        //{
        //    moveDirection.y = 0f;


        //    if (Input.GetKeyDown(KeyCode.Space) && !Isjump)
        //    {
        //        moveDirection.y = jumpForce;
        //        Isjump = true;
        //        Debug.Log("Jump");
        //    }
        //    else
        //    {
        //        Isjump = false;
        //    }

        }
    }
 



    

