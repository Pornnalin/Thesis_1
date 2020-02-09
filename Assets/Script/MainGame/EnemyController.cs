using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform[] patrolPoint;
    public int currentPatrolPoint;


    public NavMeshAgent agent;
    public Animator anim;
    public enum AIState
    {
        isIdle, IsPatrolling
    }
    public AIState currentState;

    public float waitAtPoint;
    private float waitCounter;



    // Start is called before the first frame update
    void Start()
    {
        waitCounter = waitAtPoint;
       
        agent.baseOffset = -0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.IsInputEnabled)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, MainPlayerController.instance.transform.position);
            //Debug.Log(distanceToPlayer + "position");
            switch (currentState)
            {
                case AIState.isIdle:
                    anim.SetBool("IsMoving", false);

                    if (waitCounter > 0)
                    {
                        waitCounter -= Time.deltaTime;
                    }
                    else
                    {
                        currentState = AIState.IsPatrolling;
                        agent.SetDestination(patrolPoint[currentPatrolPoint].position);

                    }


                    break;

                case AIState.IsPatrolling:


                    if (agent.remainingDistance <= 0.5f)
                    {
                        currentPatrolPoint++;
                        if (currentPatrolPoint >= patrolPoint.Length)//เช็คว่าครบตำแหน่งยัง
                        {
                            currentPatrolPoint = 0;//ถ้าครบทำการเริ่มใหม่
                        }
                        currentState = AIState.isIdle;
                        waitCounter = waitAtPoint;
                    }


                    anim.SetBool("IsMoving", true);
                    break;






            }
        }
        else
        {
            anim.SetBool("IsMoving", false);
           
        }

       
    }
}
