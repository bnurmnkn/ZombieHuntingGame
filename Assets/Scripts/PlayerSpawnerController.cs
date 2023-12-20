using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerSpawnerController : MonoBehaviour
{
    float playerSpeed=8f;
    float LeftRightSpeed;
    public TextMeshProUGUI time,life;
    public Button btnAgain;
    public Button btnContinue;
    public Button btnHomePage;
    float timeCounter=20f;
    float remainingLife=4;

    bool playerAlive= true;
    //bool playerDied=false;
    
    
   
    void Start()
    {
        
    }

    
    void Update()
    {
        if(playerAlive)
        {
            timeCounter-=Time.deltaTime;
            time.text=(int)timeCounter+"";

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
        if(timeCounter<0)
        {
            playerAlive=false;
            btnAgain.gameObject.SetActive(true);
            btnHomePage.gameObject.SetActive(true);
        }
       
        
    }
    private void  OnTriggerEnter(Collider other)
    {
        if(other.tag=="finishtag")
        {
           
            playerAlive=true;
            btnContinue.gameObject.SetActive(true);
            btnHomePage.gameObject.SetActive(true);
            
        }
        if(other.tag=="bnm")
        {
            remainingLife-=1;
            life.text=remainingLife+"";
            if(remainingLife==0)
            {
                btnAgain.gameObject.SetActive(true);
                btnHomePage.gameObject.SetActive(true);
                playerAlive=false;
            }
        }
    }
  
}
