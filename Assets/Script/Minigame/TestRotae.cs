using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotae : MonoBehaviour
{
    public Transform[] map;
    public Transform currentObject;
    int count = 0;


    private float traitionSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        currentObject = GetComponent<Transform>();
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
                currentObject = map[1];
                map[1].gameObject.SetActive(true);
                map[2].gameObject.SetActive(false);
                map[0].gameObject.SetActive(false);

                break;

            case 0:
                currentObject = map[0];
                map[0].gameObject.SetActive(true);
                map[1].gameObject.SetActive(false);
                map[2].gameObject.SetActive(false);

                break;

            case 1:

                currentObject = map[2];
                map[2].gameObject.SetActive(true);
                map[1].gameObject.SetActive(false);
                map[0].gameObject.SetActive(false);

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
        //        //transform.position = player.transform.position + offset;
        //        transform.position = Vector3.Lerp(transform.position, currentObject.transform.position, Time.deltaTime * traitionSpeed);
        //        Vector3 currentAngle = new Vector3(
        //            Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentObject.transform.rotation.eulerAngles.x, Time.deltaTime * traitionSpeed),
        //            Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentObject.transform.rotation.eulerAngles.y, Time.deltaTime * traitionSpeed),
        //            Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentObject.transform.rotation.eulerAngles.z, Time.deltaTime * traitionSpeed));

        //        transform.eulerAngles = currentAngle;


        transform.rotation = Quaternion.Lerp(transform.rotation, currentObject.rotation, traitionSpeed);
        transform.position = Vector3.Lerp(transform.position, currentObject.transform.position, Time.deltaTime * traitionSpeed);

    }




}
