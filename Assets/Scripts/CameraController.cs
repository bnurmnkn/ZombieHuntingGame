using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    [SerializeField] private Vector3 offset;
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        if(target!=null)
        {
             transform.position=target.position+offset;

        }

    }
}
