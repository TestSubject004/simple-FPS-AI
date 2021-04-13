using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{
    public AiAggroTrigger aggroTrigger;
    public AIIdleWander wandercheckpoint;
    public AIChaseCover combatCheckpoint;
    public AILookaround vision;
    public EnemyRaycastWeapon aiWeapon;
    public AiLocomotion movementControl;
    public AiStateMachine stateMachine;
    public AiStateId initialState;
    public NavMeshAgent navMeshAgent;
    public AiAgentConfig config;
    public Ragdoll ragdoll;
    public SkinnedMeshRenderer mesh;
    public UIHealthBar ui;
    public Transform playerTransform;
    public Health damageTest;
    // Start is called before the first frame update
    void Start()
    {
        
        vision = GetComponent<AILookaround>();
        damageTest = GetComponent<Health>();
        aiWeapon = GetComponentInChildren<EnemyRaycastWeapon>();
        ragdoll = GetComponent<Ragdoll>();
        movementControl = GetComponent<AiLocomotion>();
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        ui = GetComponentInChildren<UIHealthBar>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        stateMachine = new AiStateMachine(this);
        stateMachine.RegisterState(new AiChasePlayerState());
        stateMachine.RegisterState(new AiDeathState());
        stateMachine.RegisterState(new AiIdleState());
        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    public void Destroy(){
        Destroy(gameObject, 3f);
    }
}
