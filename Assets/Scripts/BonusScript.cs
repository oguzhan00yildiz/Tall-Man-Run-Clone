using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    [SerializeField] private float bonusAmount;
    [SerializeField] private Material defaultMat;
    [SerializeField] private Material flashMat;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ScoreTxtManager.instance.bonusMultiplier = bonusAmount;
            StartCoroutine(BonusSignFlash());
        }
    }

    private IEnumerator BonusSignFlash()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if(renderer != null)
        {
            renderer.material = flashMat;
            yield return new WaitForSeconds(0.3f);
            renderer.material = defaultMat;
        }
        
    }
}
