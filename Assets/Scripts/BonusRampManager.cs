using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusRampManager : MonoBehaviour
{
    
   
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement.instance.BonusRun=true;
            PlayerMovement.instance.anim.SetTrigger("isChargeRunning");

        }
    }
}
