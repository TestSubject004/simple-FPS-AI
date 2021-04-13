using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public Health  health;
    
    public void OnRaycastHit(RaycastWeapon weapon, Vector3 direction){
        health.TakeDamage(weapon.damage, direction, weapon, this);  //added 2 new arguments to check for hitbox and weapon for headshot implementation
    }
}
