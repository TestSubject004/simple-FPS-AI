using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemy : MonoBehaviour
{
    public GameObject portalManager; //addded for portal
    public GameObject toEnable;
    private void OnTriggerEnter(Collider other){
       toEnable.SetActive(true);
       if (!(portalManager.activeSelf)){
           portalManager.SetActive(true);
       }
       
        
       
   }
}
