using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiChasePlayerState : AiState
{
    //float timer = 0.0f;
    float shootTime = 0.0f;
    bool fireMode = false;
    bool transition = false;
    
    

    public void Enter(AiAgent agent)
    {
            agent.navMeshAgent.autoBraking = true;
            
    }

    public void Exit(AiAgent agent)
    {
        
    }

    public AiStateId GetId()
    {
        return AiStateId.ChasePlayer;
    }

    public void Update(AiAgent agent)
    {
        if (!agent.enabled){
            return;
        }

        if (!transition){
            resetPath(agent);
            transition = true;
            //return;
        }
        if (shootTime<=0.0f){
            fireMode = false;
            
            shootTime = Random.Range(1f,5f);
            //Debug.Log(shootTime);
            resetPath(agent);
            moveAgent(agent,8f);
            return;
            } 
        

        if (agent.navMeshAgent.hasPath && !fireMode){
            moveAgent(agent,8f);
            return;
        }

        
        
        //Debug.Log("In chase");
        //
        
        //timer -= Time.deltaTime;

        while (!agent.navMeshAgent.hasPath && shootTime>0.0f){

            if (!fireMode){
                agent.navMeshAgent.speed = 0f;
                // agent.navMeshAgent.stoppingDistance = 5;
                agent.movementControl.movement(agent.navMeshAgent.velocity.magnitude);
            }
            //Debug.Log("enter no path block");
            fireMode = true;
            agent.aiWeapon.StartFiring();
            //Debug.Log("shots fired");
            agent.vision.Lookaround();
            //Debug.Log("look around");
            shootTime-=Time.deltaTime;
            //Debug.Log("exit time");
            //Debug.Log(shootTime);
                
            return;
                
                
            

            
        }

        
        

    
    }
    void resetPath(AiAgent agent){
        
        int index1 = Random.Range(0, (agent.combatCheckpoint.waypoints.Count));
        //Debug.Log("path reset");
        agent.navMeshAgent.destination = agent.combatCheckpoint.waypoints[index1].position;
    }

    void moveAgent(AiAgent agent, float speed){
        agent.navMeshAgent.speed = speed;
        // agent.navMeshAgent.stoppingDistance = 5;
        agent.movementControl.movement(agent.navMeshAgent.velocity.magnitude);
    }
}
