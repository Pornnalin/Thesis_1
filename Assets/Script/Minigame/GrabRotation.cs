using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRotation : MonoBehaviour
{
   
    public float speedRotation = 5f;
    [SerializeField]
    public Vector3 originalRotation;


    private void Start()
    {
        originalRotation = gameObject.transform.localEulerAngles;
    }
    void OnMouseDrag()
    {
        float XaxisRotaion = Input.GetAxis("Mouse X") * speedRotation;
        float YaxisRotaion = Input.GetAxis("Mouse Y") * speedRotation;


        //transform.Rotate(Vector3.right, YaxisRotaion);
        transform.Rotate(Vector3.down, XaxisRotaion);

    }
  

    private void OnMouseUp()
    {
        transform.eulerAngles = new Vector3(originalRotation.x, originalRotation.y, 0);
        Debug.Log("Original");
    }


}
