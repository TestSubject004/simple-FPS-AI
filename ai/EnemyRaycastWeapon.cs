using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaycastWeapon : MonoBehaviour
{

    //public bool isFiring = false;
    public float fireDelay = 0.2f;
    float timer = 0;
    public Transform raycastOrigin;
    Transform playerTransform;
    Ray ray;
    RaycastHit hitInfo;
    public ParticleSystem aiMuzzleFlash;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("/Character_Hacker_Female_01/Root/Hips/Spine_01/Spine_02").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //StartFiring(); //this was used for testing, now we will call this function via the AI chase state interface
    }

    public void StartFiring(){
        timer +=Time.deltaTime;
        //isFiring = true;
        ray.origin = raycastOrigin.position;
        ray.direction = playerTransform.position - raycastOrigin.position;
        while(timer>0.0f){
            if (Physics.Raycast(ray, out hitInfo)){
                aiMuzzleFlash.Emit(1); 
                sfxManager.sfxInstance.Audio.PlayOneShot(sfxManager.sfxInstance.enemyShoot, 0.1f);
                Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 10.0f);
                //Debug.Log(hitInfo.collider.name);

                var hitBox = hitInfo.collider.GetComponentInChildren<playerHitbox>(); //code to check if enemy hits the player (additions)
                if (hitBox){
                    //Debug.Log(hitInfo.collider.name);
                    hitBox.EnemyRaycastHit();
                }
            }
            timer -= fireDelay;
        }
    }
}
