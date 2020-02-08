using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFindPlayer : MonoBehaviour
{
    //public float rotationSpeed;
    public float distance;
    private bool spawnCase = false;
    private bool findTarget;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        //Vector3 direction = transform.TransformDirection(Vector3.forward) * 10;
        if (GameManager.gameEnd == false) 
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, distance))
            {
                if (hitInfo.collider.CompareTag("Player"))
                {

                    //StartCoroutine(WaitForTureOff());
                    //GameManager.gameEnd = true;
                    //MainPlayerController.instance.anim.SetBool("IsDead", true);
                    Debug.Log(hitInfo.collider.gameObject.name);
                    Debug.Log("PlayerDead");
                    //spawnCase = true;
                    //Instantiate(GameManager._GameManager.caseModel, MainPlayerController.instance.playerModel.transform.position, Quaternion.identity);
                }

                else
                {
                    Debug.Log("Not found anything");
                }
                Debug.DrawLine(ray.origin, hitInfo.point, Color.green);

            }
        }
        else
        {
            if (spawnCase)
            {
                distance = 0f;
                StartCoroutine(WaitLoadScene());
                spawnCase = false;
            }

        }

       
        //soundManager.PlaySound(SoundManager.soundInGame.em_sound);
    }
    public void FixedUpdate()
    {
        //Vector3 direction = transform.TransformDirection(Vector3.forward) * 10;
        //if (Physics.Raycast(transform.position, direction, 10))
        //{
        //    print("There is something in front of the object!");
        //    Debug.Log(gameObject.name);
        //}
          

        //Debug.DrawRay(transform.position, direction, Color.green);
    }

    IEnumerator WaitForTureOff()
    {
        //Instantiate(GameManager._GameManager.caseModel, MainPlayerController.instance.playerModel.transform.position, Quaternion.identity);
        SoundManager.soundManager.audioS.volume = 0.3f;
        SoundManager.soundManager.PlaySound(soundInGame.em_sound);
        yield return new WaitForSeconds(5f);
        SoundManager.soundManager.audioS.volume = 0f;
    }

    IEnumerator WaitLoadScene()
    {
        Instantiate(GameManager._GameManager.caseModel, MainPlayerController.instance.playerModel.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        GameManager._GameManager.LoadScene();
    }
}
