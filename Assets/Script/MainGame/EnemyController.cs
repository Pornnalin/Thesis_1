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
    }

    // Update is called once per frame
    void Update()
    {
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

                //agent.SetDestination(patrolPoint[currentPatrolPoint].position);
                if (agent.remainingDistance <= 2f)
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

    
}
