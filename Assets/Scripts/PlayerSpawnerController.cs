using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : MonoBehaviour
{
    float playerSpeed=5f;
    float LeftRightSpeed;
    void Start()
    {
        
    }

    
    void Update()
    {
        float touchX=0;
        float newXValue=0;
        if(Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Moved)
        {
            LeftRightSpeed=250f;
            
            touchX=Input.GetTouch(0).deltaPosition.x/Screen.width;

        }
        else if(Input.GetMouseButton(0))
        {
            LeftRightSpeed=250f;
            touchX=Input.GetAxis("Mouse X");

        }
        newXValue=transform.position.z+LeftRightSpeed*touchX*Time.deltaTime;
        Vector3 playerNewPosition=new Vector3(transform.position.x-playerSpeed*Time.deltaTime,transform.position.y,newXValue);
        transform.position=playerNewPosition;
    }
}
