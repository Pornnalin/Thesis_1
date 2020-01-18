using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMap : MonoBehaviour
{
    public GameObject[] map;
    public GameObject[] cameraPostion;
    
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
   
        map[0].SetActive(true);
        cameraPostion[0].SetActive(true);

        map[1].SetActive(false);
        cameraPostion[1].SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(count);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && count == 0) 
        {
            Debug.Log("checkTag = " + tag);

            map[1].SetActive(true);
            cameraPostion[1].SetActive(true);

            map[0].SetActive(false);
            cameraPostion[0].SetActive(false);

           
        }

         if(other.gameObject.CompareTag("Player") && count == 1)
        {
            map[1].SetActive(false);
            cameraPostion[1].SetActive(false);

            map[0].SetActive(true);
            cameraPostion[0].SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        count++;
        Debug.Log("exitMap1");
        if (count > 1)
        {
            count = 0;
        }
    }

   
}
