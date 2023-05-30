using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] private ParticleSystem diamondPS;
    // Start is called before the first frame update
    void Start()
    {
        //diamondPS = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            IncreaseScore();
            diamondPS.Play();
            StartCoroutine(DiamondCoroutine());
        }
    }

    private void IncreaseScore()
    {
        ScoreTxtManager.instance.diamondScore++;
    }

    private IEnumerator DiamondCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
