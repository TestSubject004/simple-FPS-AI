using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiIdleState : AiState
{
    public void Enter(AiAgent agent)
    {
        
    }

    public void Exit(AiAgent agent)
    {
        
    }

    public AiStateId GetId()
    {
        return AiStateId.Idle;
    }

    public void Update(AiAgent agent)
    {
        //Debug.Log("in Idle");
        
        agent.navMeshAgent.speed = 1.7f;
        agent.movementControl.movement(agent.navMeshAgent.velocity.magnitude);
        Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;
        if (agent.aggroTrigger.aggro){ //check if player crossed the aggro trigger
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
        }
        if (playerDirection.magnitude > agent.config.maxSightDistance){
            if (agent.navMeshAgent.hasPath){
                if (agent.damageTest.damageTaken == true){ // if ai is peacefully walking, we shoot it to get its attention
            
                agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
                }
                return;
            }
            int index = Random.Range(0, (agent.wandercheckpoint.waypoints.Count));
            agent.navMeshAgent.destination = agent.wandercheckpoint.waypoints[index].position;
            
            return;
        }

        Vector3 agentDirection = agent.transform.forward;
        playerDirection.Normalize();
        float dotProduct = Vector3.Dot(playerDirection, agentDirection);

        

        if (dotProduct > 0.0f){
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
        }
    }
}
