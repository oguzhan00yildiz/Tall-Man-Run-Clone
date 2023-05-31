using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpPoint : MonoBehaviour
{
    [SerializeField] private Transform landPoint;
    [SerializeField] private int jumpPower;//default = 3f
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.DOJump(landPoint.position, jumpPower, 1, 1.5f);
        }
    }
}
