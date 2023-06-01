using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiScript : MonoBehaviour
{
   [SerializeField] ParticleSystem[] confettis;

   void OnTriggerEnter(Collider other)
   {
        if(other.CompareTag("Player"))
        {
            foreach(ParticleSystem confetti in confettis)
            {
                confetti.Play();
            }
        }
   }
}
