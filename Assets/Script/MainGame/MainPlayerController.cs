﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public bool isSlide = false;
    public Animator anim;
    float horizontaMove = 0f;
    public Transform scalePlayer;
    public LayerMask mask;
    public GameObject rayMark;



    private CharacterController charController;
    private Vector3 moveDirection;
    private bool Isjump = false;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        charController = GetComponent<CharacterController>();

        //Vector3 scaleP = scalePlayer.transform.localScale;

        float yStore = moveDirection.y;
        //float hMove = Input.GetAxis("Horizontal");
        //float VMove = Input.GetAxis("Vertical");

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        moveDirection.Normalize();
        moveDirection = moveDirection * moveSpeed;
        moveDirection.y = yStore;


        //jump
        JumpInput();
        CheckGround();

        //rotation
        RotationChar();


        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;
        //Debug.Log("gravity" + Physics.gravity.y);

        charController.Move(moveDirection * Time.deltaTime);

       

        anim.SetBool("isGrounded", charController.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal"))));


    }
    private void JumpInput()
    {
        if (charController.isGrounded)
        {
            moveDirection.y = 0f;


            if (Input.GetKeyDown(KeyCode.Space) && !Isjump)
            {
                moveDirection.y = jumpForce;
                Isjump = true;
                Debug.Log("Jump");
            }
            else
            {
                Isjump = false;
            }

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
        //if (Physics.Raycast(ray, out hitInfo, 30, mask, QueryTriggerInteraction.Ignore))
        //{
        //    Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
        //    print(hitInfo.collider.gameObject.tag);

        //    if (hitInfo.collider.tag == "Slide")
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


}
    
