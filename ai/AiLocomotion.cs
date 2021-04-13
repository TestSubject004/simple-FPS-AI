using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiLocomotion : MonoBehaviour
{
    
    NavMeshAgent agent;
    Animator animator;
    float m_speed;
    
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
    }

    
    void Update()
    {
       // m_speed = agent.velocity.magnitude;
       // movement(m_speed);
        
        
    }

    public void movement(float speed){
        if (agent.hasPath){
            animator.SetFloat("Speed", speed);
        }
        else{
            animator.SetFloat("Speed", 0);
        }
    }
}
