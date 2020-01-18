using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
   
    //public GameObject gameOjectTaget;
    //public GameObject gameOjectTaget2;
    //public GameObject gameOjectTaget3;
    public Transform[] view;
    public float traitionSpeed;
    public Transform currentView;
    public bool switchInput;
    int count = 0;
    //public GameObject player;
    //private Vector3 offset;//distance between the player's position and camera's position.


    // Start is called before the first frame update
    void Start()
    {
        //gameOjectTaget3.SetActive(false);
        //gameOjectTaget.SetActive(true);
        //gameOjectTaget2.SetActive(false);
        currentView = GetComponent<Transform>();
        switchInput = false;
        //offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Count =" + count);
        RunNumber();

        //if (Input.GetKeyDown(KeyCode.Mouse1))
        //{
        //    currentView = view[1];
        //    switchInput = false;
        //}
        //if (Input.GetKeyDown(KeyCode.Mouse2))
        //{
        //    currentView = view[0];
        //    switchInput = false;
        //}
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    currentView = view[2];
        //    switchInput = true;
        //}
        switch (count)
        {
            case -1:
                currentView = view[1];
                switchInput = true;
                break;

            case 0:
                currentView = view[0];
                switchInput = false;
                break;

            case 1:

                currentView = view[2];
                switchInput = false;
                break;


        }


        //ControlCamera();
    }
    
    public void RunNumber()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && count == 0) 
        {
            count = 1;

            
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && count == 0)
        {
            count = -1;

        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && count == 1) 
        {
            count -= 1;
            Debug.Log(count + "test2");
            
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && count == -1)
        {
            count += 1;
            Debug.Log(count + "test3");

        }

       
       


       
    }

    private void LateUpdate()
    {
        //transform.position = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * traitionSpeed);
        Vector3 currentAngle = new Vector3(
            Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * traitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * traitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * traitionSpeed));

        transform.eulerAngles = currentAngle;
        



    }

    public void ControlCamera()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //float xConvert = (float)12.58;
            //float yConvert = (float)16.39;
            //float zConvert = (float)-26.4;

            //transform.position = new Vector3(xConvert, yConvert, zConvert);

            //transform.position = new Vector3(12, 16, -26);
            //transform.eulerAngles = new Vector3(30, -45, 0);
            //gameOjectTaget3.SetActive(true);
            //gameOjectTaget.SetActive(false);
            //gameOjectTaget2.SetActive(false);

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {

            ////float xConvert = (float)1.6;
            ////float yConvert = (float)16.39;
            ////float zConvert = (float)-16;

            ////transform.position = new Vector3(xConvert, yConvert, zConvert);
            //transform.position = new Vector3(1, 16, -16);
            //transform.eulerAngles = new Vector3(30, 90, 0);
            //gameOjectTaget3.SetActive(false);
            //gameOjectTaget.SetActive(false);
            //gameOjectTaget2.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //float xConvert = (float)12.58;
            //float yConvert = (float)16.39;
            //float zConvert = (float)-26.4;

            //transform.position = new Vector3(xConvert, yConvert, zConvert);
            //transform.rotation = Quaternion.Slerp(gameOjectTaget2.rotation, gameOjectTaget3.rotation, 5f);
            //gameOjectTaget3.SetActive(false);
            //gameOjectTaget.SetActive(true);
            //gameOjectTaget2.SetActive(false);

        }
    }
}
