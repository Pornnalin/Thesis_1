using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LineRenderer line;
    public Transform s;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        //line.transform.position = s.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit))
        {
            if (hit.collider)
            {
                line.SetPosition(1, new Vector3(0, 0, hit.distance));
            }
            else
            {
                line.SetPosition(1, new Vector3(0, 0, 5000));
            }
        }
    }
}
