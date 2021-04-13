using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AiAgentConfig : ScriptableObject
{
    public float maxTime= 1.0f;
    public float maxDistance = 1.0f;
    public float dieForce= 10.0f;
    public float maxSightDistance = 5.0f;
}
