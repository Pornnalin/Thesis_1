using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;

    bool isPlayerInRange;
    bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.forward;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            //Debug.DrawLine(ray.origin, ray, Color.red);
            if (Physics.Raycast(ray,out raycastHit))
            {
                Debug.Log("HitPlaye");
                GameManager.gameEnd = true;
                MainPlayerController.instance.anim.SetBool("IsDead", true);
                GameManager.IsInputEnabled = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerInRange = false;
        }
    }
}
