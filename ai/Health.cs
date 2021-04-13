using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    
    [HideInInspector] public float currentHealth;
    AiAgent agent;
    SkinnedMeshRenderer skinnedMeshRenderer;
    UIHealthBar healthBar;

    public float blinkIntensity;
    public float blinkDuration;
    float blinkTimer;
    public bool damageTaken = false;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<AiAgent>();
        skinnedMeshRenderer =GetComponentInChildren<SkinnedMeshRenderer>();
        healthBar = GetComponentInChildren<UIHealthBar>();
        currentHealth = maxHealth;
        


        var rigidBodies = GetComponentsInChildren<Rigidbody>();
        foreach(var rigidBody in rigidBodies){
            Hitbox hitBox = rigidBody.gameObject.AddComponent<Hitbox>();
            hitBox.health = this;
        }
    }

    // Update is called once per frame
    public void TakeDamage(float amount, Vector3 direction, RaycastWeapon weapon, Hitbox hs){   //changed argument, added weapon and hitbox, see hitbox script
        damageTaken = true;
        if (weapon.weaponName == "pistol" && hs.name == "Head"){ // added an If condition for the pistol check, all of if and else shell are additions, remove them in case of complications
            currentHealth = 0;
            agent.ragdoll.ActivateRagdoll();
            sfxManager.sfxInstance.Audio.PlayOneShot(sfxManager.sfxInstance.scream);
            direction.y = 1;
            agent.ragdoll.ApplyForce(direction * 100.0f); //ragdoll headshot fun
        }
        else {
        currentHealth -= amount;
        }
        healthBar.SetHealthBarPercentage(currentHealth / maxHealth);
        
        if (currentHealth <= 0.0f){
            Die(direction);
        }
        blinkTimer = blinkDuration;
        
    }

    private void Die(Vector3 direction){
        AiDeathState deathState = agent.stateMachine.GetState(AiStateId.Death) as AiDeathState;
        deathState.direction = direction;
        agent.stateMachine.ChangeState(AiStateId.Death);
    }
    private void Update(){
        blinkTimer -=Time.deltaTime;
        float lerp = Mathf.Clamp01(blinkTimer / blinkDuration);
        float intensity = (lerp * blinkIntensity) + 1.0f; 
        skinnedMeshRenderer.material.color = Color.white* intensity;
    }
}
