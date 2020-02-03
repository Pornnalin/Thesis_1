using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushItem : MonoBehaviour
{
    Rigidbody _rigidbody;
    public float speed;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPush)
        {

            if (Input.GetKey(KeyCode.E) && GameManager.IsInputEnabled && !MainPlayerController.instance.isClimb && !MainPlayerController.instance.Isjump)  
            {

                //MainPlayerController.instance.anim.SetBool("IsPush", true);
                //MainPlayerController.instance.charController.height = 1.7f;
                //rigidbody.velocity = Vector3.right * Time.deltaTime * speed;
                //transform.Translate(Vector3.right * Time.deltaTime);
                checkRotaion();



            }
            else
            {
                isPush = false;
                MainPlayerController.instance.anim.SetBool("IsPush", false);
                MainPlayerController.instance.charController.height = 1.86f;
                
            }
           
        }

        


        //if (Input.GetKey(KeyCode.E))
        //{
        //    Debug.Log("E");
        //}
        //if (Input.GetKeyUp(KeyCode.F))
        //{
        //    Debug.Log("UpF");
        //}
        //if (Input.GetButton("Fire1"))
        //{
        //    Debug.Log("GetButtonDownA");
        //}
    }
   

    public bool isPush;
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Isplayer");
            MainPlayerController.instance.charController.height = 1.7f;
            isPush = true;
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        isPush = false;
        MainPlayerController.instance.anim.SetBool("IsPush", false);
        MainPlayerController.instance.charController.height = 1.86f;

    }

    public void checkRotaion()
    {
        if (MainPlayerController.instance.playerModel.transform.rotation.eulerAngles.y == 0)
        {
            MainPlayerController.instance.anim.SetBool("IsPush", true);
            MainPlayerController.instance.charController.height = 1.7f;
            //rigidbody.velocity = Vector3.right * Time.deltaTime * speed;
            transform.Translate(Vector3.right * Time.deltaTime);

            Debug.Log("0");
        }
        if (MainPlayerController.instance.playerModel.transform.rotation.eulerAngles.y == 180)
        {
            MainPlayerController.instance.anim.SetBool("IsPush", true);
            MainPlayerController.instance.charController.height = 1.7f;
            //rigidbody.velocity = Vector3.right * Time.deltaTime * speed;
            transform.Translate(Vector3.left * Time.deltaTime);

            Debug.Log("180");
        }
    }
}
