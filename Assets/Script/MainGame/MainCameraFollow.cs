using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 10f;

    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
     void FixedUpdate()
    {
        //Vector3 targetCampos = target.position + offset;

        //transform.position = Vector3.Lerp(transform.position, targetCampos, smoothing * Time.deltaTime);
    }

    private void Update()
    {
        Vector3 targetCampos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCampos, smoothing * Time.deltaTime);
    }

}
