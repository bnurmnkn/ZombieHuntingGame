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
        float newXvalue=0;
        if(Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Moved)
        {

            LeftRightSpeed=250f;
            touchX=Input.GetTouch(0).deltaPosition.x/Screen.width;
        }
        else if(Input.GetMouseButton(0))
        {
            LeftRightSpeed=100f;
            touchX=Input.GetAxis("Mouse X");

        }
        newXvalue=transform.position.x+LeftRightSpeed*touchX*Time.deltaTime;
        Vector3 playerNewPosition=new Vector3(newXvalue,transform.position.y,transform.position.z+playerSpeed* Time.deltaTime);
        transform.position=playerNewPosition;
    }
}
