using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class level5ScriptController : MonoBehaviour
{
    public float playerSpeed=8f;
    float LeftRightSpeed;
    public TextMeshProUGUI time,life;
    public Button btnAgain;
    public Button btnHomePage;
    public float timeCounter=20f;
    public float remainingLife=4;
    bool playerAlive=true;
    float maxXPosition=4.7f;
    public AudioSource PlayerSpawnerAudioSource;
    public AudioClip shootClip,failClip,congratsClip;
    public GameObject bulletGO;
    public Transform bulletSpawnTransform;
    private float bulletSpeed = 13f;
    
    
     Transform Player;
     Transform Zombi;

    void Start()
    {
       Player=GameObject.FindGameObjectWithTag("player").transform;
       Zombi=GameObject.FindGameObjectWithTag("Zombi").transform;
       
    }

    
    void Update()
    {
       
        timeCounter-=Time.deltaTime;
        time.text=(int)timeCounter+"";
        life.text=remainingLife+"";
       
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
            Debug.Log("Yön kkontrol");
        }

        newXvalue=transform.position.x+LeftRightSpeed*touchX*Time.deltaTime;
        newXvalue=Mathf.Clamp(newXvalue,-maxXPosition,maxXPosition);
        Vector3 playerNewPosition=new Vector3(newXvalue,transform.position.y,transform.position.z+playerSpeed* Time.deltaTime);
        transform.position=playerNewPosition;

        if(timeCounter<0)
        {
            int level=SceneManager.GetActiveScene().buildIndex;
                PlayerPrefs.SetInt("Level",level);
                PlayerPrefs.Save();
            playerAlive=false;
            StopBackgroundMusic();
            PlayAudio(failClip);
            btnAgain.gameObject.SetActive(true);
            btnHomePage.gameObject.SetActive(true);
            Time.timeScale=0f;
        }
        float mesafe=Vector3.Distance(Player.position,Zombi.position);
       
       if(mesafe<13 )
       {
        Debug.Log("mesafe");
        Shoot();
        
        
       }
    }
    private void  OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("finishtag"))  
        {
            playerAlive=true;
            StopBackgroundMusic();
            PlayAudio(congratsClip);
            btnHomePage.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        if(other.CompareTag("over"))
        {
            int level=SceneManager.GetActiveScene().buildIndex;
                PlayerPrefs.SetInt("Level",level);
                PlayerPrefs.Save();
            remainingLife=0;
            playerAlive=false;
            StopBackgroundMusic();
            PlayAudio(failClip);
            btnAgain.gameObject.SetActive(true);
            btnHomePage.gameObject.SetActive(true);
            Time.timeScale=0f;

        }
        else if(other.CompareTag("bnm"))
        {
            remainingLife-=1;
            life.text=remainingLife+"";
            if(remainingLife==0)
            {
                int level=SceneManager.GetActiveScene().buildIndex;
                PlayerPrefs.SetInt("Level",level);
                PlayerPrefs.Save();
                playerAlive=false;
                StopBackgroundMusic();
                PlayAudio(failClip);
                btnAgain.gameObject.SetActive(true);
                btnHomePage.gameObject.SetActive(true);
                Time.timeScale=0f;
            }
        }
    }

    private void PlayAudio(AudioClip clip)
    {
        if(PlayerSpawnerAudioSource !=null)
        {
            PlayerSpawnerAudioSource.PlayOneShot(clip,0.4f);
        }
    }
    
    private void StopBackgroundMusic()
    {
        Camera.main.GetComponent<AudioSource>().Stop();
    }
    
    public void ZombieDetected()
    {
        Debug.Log("beyza");
        
    }
  
    private void Shoot()
    {
    GameObject bullet = Instantiate(bulletGO, bulletSpawnTransform.position, Quaternion.identity);
    Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
    bulletRB.velocity = transform.forward * bulletSpeed;
    PlayAudio(shootClip);
    }
}
