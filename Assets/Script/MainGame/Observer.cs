using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;

    bool isPlayerInRange;
    bool isDead;
    private bool spawnCase = false;
    public Collider _collider;
    

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.IsInputEnabled)
        {
            if (isPlayerInRange)
            {
                Vector3 direction = player.position - transform.position + Vector3.forward;
                Ray ray = new Ray(transform.position, direction);
                RaycastHit raycastHit;
                //Debug.DrawLine(ray.origin, ray, Color.red);
                if (Physics.Raycast(ray, out raycastHit))
                {
                    
                    _collider.enabled = true;

                    StartCoroutine(WaitForTureOff());
                    Debug.Log("HitPlaye");
                    GameManager.gameEnd = true;
                    MainPlayerController.instance.anim.SetBool("IsDead", true);

                    GameManager.IsInputEnabled = false;
                    spawnCase = true;


                }
            }
        }
        else
        {
            if (spawnCase)
            {
               
                _collider.enabled = false;
                CapsuleCollider cc = GetComponent(typeof(CapsuleCollider)) as CapsuleCollider;
                cc.isTrigger = false;
                StartCoroutine(WaitLoadScene());
                spawnCase = false;
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

    IEnumerator WaitForTureOff()
    {
        anim.speed = 0;
        //Instantiate(GameManager._GameManager.caseModel, MainPlayerController.instance.playerModel.transform.position, Quaternion.identity);
        SoundManager.soundManager.audioS.volume = 0.3f;
        SoundManager.soundManager.PlaySound(soundInGame.em_sound);
        yield return new WaitForSeconds(5f);
        SoundManager.soundManager.audioS.volume = 0f;
    }

    IEnumerator WaitLoadScene()
    {
        
        Instantiate(GameManager._GameManager.caseModel, MainPlayerController.instance.playerModel.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(7f);
        GameManager._GameManager.LoadScene();
    }

   

  
}
