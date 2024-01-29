using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform player;
    NavMeshAgent nMesh;
    
    void Start()
    {
        nMesh=GetComponent<NavMeshAgent>();
        nMesh.destination=player.position;
        
    }
    
    void Update()
    {
        
    }
}
