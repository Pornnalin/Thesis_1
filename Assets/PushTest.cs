using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushTest : MonoBehaviour
{
    Rigidbody rigidbody;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPush)
        {

            if (Input.GetKey(KeyCode.E) && GameManager.IsInputEnabled) 
            {

                MainPlayerController.instance.anim.SetBool("IsPush", true);
                MainPlayerController.instance.charController.height = 1.7f;
                rigidbody.velocity = Vector3.right * Time.deltaTime * speed;
                rigidbody.isKinematic = false;

            }
            else
            {
                isPush = false;
                MainPlayerController.instance.anim.SetBool("IsPush", false);
                MainPlayerController.instance.charController.height = 1.86f;
                rigidbody.isKinematic = true;
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
    bool isPush;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Isplayer");
            isPush = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPush = false;
        MainPlayerController.instance.anim.SetBool("IsPush", false);
        MainPlayerController.instance.charController.height = 1.86f;

    }
}
