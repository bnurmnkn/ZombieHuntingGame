using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : MonoBehaviour
{
    float playerSpeed=5f;
    void Start()
    {
        
    }

    
    void Update()
    {
        Vector3 playerNewPosition=new Vector3(transform.position.x-playerSpeed*Time.deltaTime,transform.position.y,transform.position.z);
        transform.position=playerNewPosition;
    }
}
