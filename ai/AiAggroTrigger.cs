using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAggroTrigger : MonoBehaviour
{
    public bool aggro = false;
    
    private void OnTriggerEnter(Collider other){
       
        
       if (other.tag == "Player"){
           aggro = true;
       }
   }
}
