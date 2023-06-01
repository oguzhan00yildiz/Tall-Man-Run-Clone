using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpPoint : MonoBehaviour
{
    [SerializeField] private Transform landPoint;
    [SerializeField] private int jumpPower;//default = 3f


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.DOJump(landPoint.position, jumpPower, 1, 1.5f);
            other.transform.rotation= Quaternion.Euler(0,0,0);
            
        }

        if (gameObject.CompareTag("KickPoint"))
        {
            PlayerMovement.instance.anim.SetTrigger("Kick");
            StartCoroutine(KickDone());
        }
    }

    IEnumerator KickDone()
    {
      yield return new WaitForSeconds(1f);
      PlayerMovement.instance.isMoving=false;  
      PlayerMovement.instance.BonusRun=false;
      
    }
}
