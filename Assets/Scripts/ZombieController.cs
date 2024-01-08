using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator=GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    public void isWalkAttack()
    {
        animator.SetBool("isWalk", true);
    }
}
