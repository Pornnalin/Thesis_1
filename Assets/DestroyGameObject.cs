using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public GameObject FB;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Destroy(gameObject,2f);
    }

   public void OnTriggerEnter(Collider other)
    {
       
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "FB")
        {
            Destroy(FB,2f);
            
        }
    }
}