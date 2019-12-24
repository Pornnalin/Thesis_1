using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeBoxs : MonoBehaviour
{
    public GameObject handPlayer;
    public GameObject boxs;
    public Transform positonDrop;
    public bool isBoxInHand;

    //public Transform attachPoint;
    //public GameObject owner;
    // Start is called before the first frame update
    void Start()
    {
        //if (owner != null)
        //{
        //    transform.localScale = owner.transform.localScale;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //if (owner != null)
        //{
        //    transform.position = attachPoint.position;
        //    transform.rotation = attachPoint.rotation;
        //}
        //else Destroy(gameObject);
    }

    public void PickUpItem()
    {
        StartCoroutine(Pickup());
        isBoxInHand = true;
    }

    IEnumerator Pickup()
    {
        Debug.Log("Pickup");
        //yield return new WaitForSeconds(1.5f);
        yield return new WaitForSeconds(0.1f);
        boxs.transform.parent = handPlayer.transform;
        //boxs.transform.rotation = Quaternion.Euler(0, 0, 0);
        boxs.transform.position = handPlayer.transform.position;
        boxs.transform.rotation = handPlayer.transform.rotation;
      
        


    }
   

    public void DropItem()
    {
        if (boxs != null)
        {
            boxs.transform.parent = null;
            boxs.transform.position = positonDrop.transform.position;
            boxs.transform.rotation = Quaternion.Euler(0, 0, 0);
            isBoxInHand = false;
        }
    }


}
