using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashBallFind : MonoBehaviour
{
    // Start is called before the first frame update
    public float distance;
    private bool spawnCase = false;
    private bool findTarget;

    // Start is called before the first frame update
    void Start()
    {
        findTarget = true;
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        //Vector3 direction = transform.TransformDirection(Vector3.forward) * 10;
        if (GameManager.IsInputEnabled && findTarget)
        {
            Ray ray = new Ray(transform.position, -transform.up);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, distance))
            {
                if (hitInfo.collider.CompareTag("Player"))
                {

                       
                    StartCoroutine(WaitForTurnOff());
                    MainPlayerController.instance.anim.SetBool("IsDead", true);
                    Debug.Log(hitInfo.collider.gameObject.name);
                    Debug.Log("PlayerDead2");
                    spawnCase = true;
                    GameManager.gameEnd = true;
                  
                }

                else
                {
                    Debug.Log("Not found anything2");
                }
                Debug.DrawLine(ray.origin, hitInfo.point, Color.green);

            }
        }
        else
        {
            findTarget = false;
            if (spawnCase)
            {
                StartCoroutine(SpawnCase());
                distance = 0f;
                spawnCase = false;
            }

        }


        
    }
    

    IEnumerator WaitForTurnOff()
    {
        
        SoundManager.soundManager.audioS.volume = 0.3f;
        SoundManager.soundManager.PlaySound(soundInGame.em_sound);
        yield return new WaitForSeconds(3f);
        SoundManager.soundManager.audioS.volume = 0f;
        TrasitionScene.Trasition.EndGame();
    }

    IEnumerator SpawnCase()
    {
        Instantiate(MainPlayerController.instance.caseModel, MainPlayerController.instance.playerModel.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);

    }

}


