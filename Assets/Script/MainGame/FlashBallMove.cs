using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashBallMove : MonoBehaviour
{
    //public Transform startPos;
    //public Transform endPos;

    public GameObject flashBall;

    public float speed;
    //private float startTime;
    //private float journeyLength;

    public bool ispass;
    // Start is called before the first frame update
    void Start()
    {
        //    startTime = Time.time;
        //    journeyLength = Vector3.Distance(startPos.position, endPos.position);
        //}}

    }

    // Update is called once per frame
    void Update()
    {
        if (ispass)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            //float distCovered = (Time.time - startTime) * speed;
            //float fractionOfJoureny = distCovered / journeyLength;
            //transform.position = Vector3.Lerp(startPos.position, endPos.position, fractionOfJoureny);
        }
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ispass = true;
            
        }

    }
}

    
