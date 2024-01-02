using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnerController : MonoBehaviour
{
    public GameObject ZombieGO;
    public int zombieCount=0;
    public List<GameObject> zombieList=new List<GameObject>();
    public GameObject playerSpawnerGO;
    public PlayerSpawnerController playerSpawnerControllerScript;
  
    void Start()
    {
        playerSpawnerGO=GameObject.FindGameObjectWithTag("playerSpawner");
        playerSpawnerControllerScript=playerSpawnerGO.GetComponent<PlayerSpawnerController>();
        SpawnZombie();
    }

    void Update()
    {
    
    }
    public void SpawnZombie()
    {
        for(int i=0;i<zombieCount;i++)
        {
            Quaternion zombieRotation=Quaternion.Euler(new Vector3(0,180,0));
            GameObject zombie=Instantiate(ZombieGO,GetZombiePosition(),zombieRotation,transform);
            zombieList.Add(zombie);
        }
    }
    public Vector3 GetZombiePosition()
    {
        Vector3 pos=Random.insideUnitSphere*0.05f;
        Vector3 newPos=transform.position+pos;
        return newPos;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="playerSpawner")
        {
            //playerSpawnerControllerScript.ZombieDetected();
            GetComponent<BoxCollider>().enabled = false;
        }
        if(other.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            
            
            

            
        }
        
    }
    
}
