using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private CheckPointControl check;
    // Start is called before the first frame update
    void Start()
    {
        check = GameObject.FindGameObjectWithTag("CPC").GetComponent<CheckPointControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            check.lastCheckPos = transform.position;
        }
    }
}
