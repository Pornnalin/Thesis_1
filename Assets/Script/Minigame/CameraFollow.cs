using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public Transform playerTraform;
    //public Transform lookTarget;

    //public float speed = 10.0f;

    //public float distanceFromObject = 6f;

    //[Range(0.01f, 1.0f)]
    //public float smooth = 0.01f;
    // Vector3 cameraOffset;
    //public Controller controller;
    public GameObject player;
    private Vector3 offset;//distance between the player's position and camera's position.


    // Start is called before the first frame update
    void Start()
    {
        //cameraOffset = transform.position - playerTraform.position;
        //cameraOffset = GetComponent<Vector3>();
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //cameraFollow

        //Vector3 lookObject = playerTraform.position - transform.position;
        //lookObject = playerTraform.position - transform.position;
        //transform.forward = lookObject.normalized;

        //Vector3 playerLastPosition;
        //playerLastPosition = playerTraform.position - lookObject.normalized * distanceFromObject;
        //transform.position = playerLastPosition;
    }

    private void LateUpdate()
    {
        Debug.Log("cameraFollow");
        transform.position = player.transform.position + offset;

        //Vector3 newPos = playerTraform.position + cameraOffset;
        //transform.position = Vector3.Slerp(transform.position, newPos, 0);
        //transform.LookAt(playerTraform);

       
       

        //Vector3 smoothPosition = Vector3.Lerp(transform.position, newPos, smooth);
        //transform.position = smoothPosition;
        //transform.LookAt(playerTraform);
    }

    //public void FixedUpdate()
    //{
    //    Vector3 dpos = cameraTaget.position + cameraOffset;
    //    Vector3 spos = Vector3.Lerp(transform.position, dpos, speed * Time.deltaTime);
    //    transform.position = spos;
    //    transform.LookAt(lookTarget.position);
    //}
}
