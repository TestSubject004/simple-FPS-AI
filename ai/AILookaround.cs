using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILookaround : MonoBehaviour
{
    public float turnSpeed = 15;
    Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("/Character_Hacker_Female_01/Root/Hips/Spine_01/Spine_02/Spine_03/Neck/Head").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    public void Lookaround(){
        transform.LookAt(playerTransform); 
        //float yawCamera = playerTransform.transform.rotation.eulerAngles.y;
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera+180, 0), turnSpeed * Time.fixedDeltaTime);
    }
}
