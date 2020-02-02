using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public bool isP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isP = true;
            transform.Translate(Vector3.right * Time.deltaTime);
        }
    }
}
