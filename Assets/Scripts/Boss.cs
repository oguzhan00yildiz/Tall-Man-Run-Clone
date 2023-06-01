using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetTrigger("BossDead");
            other.transform.GetComponent<Rigidbody>().useGravity=true;
            other.transform.GetComponent<Rigidbody>().isKinematic=false;
        }
    }
}
