using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField] private GameObject caplsulePrefab;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            float randX = Random.Range(-1, 1);
            float randY = Random.Range(2, 3);
            float randZ = Random.Range(0, 3);

            if (caplsulePrefab)
            {
                GameObject capsule = Instantiate(caplsulePrefab, transform.position + new Vector3(randX, randY, randZ), Quaternion.identity);
                
            /* float obstacleHeight = transform.localScale.y;
            float capsuleHeight = capsule.GetComponent<CapsuleCollider>().height;

            Vector3 scale = capsule.transform.localScale;
            scale.y = obstacleHeight / capsuleHeight; */

            // Apply the scale to the capsule
            capsule.transform.localScale = new Vector3(capsule.transform.localScale.x,gameObject.GetComponent<BoxCollider>().size.y,capsule.transform.localScale.z);

            

            Rigidbody capsuleRigidbody = capsule.AddComponent<Rigidbody>();
            capsuleRigidbody.useGravity = true;
            StartCoroutine(CapsuleCoroutine(capsule));
            }
        }
    }


    
    

    private IEnumerator CapsuleCoroutine(GameObject capsule)
    {
        yield return new WaitForSeconds(1f);
        Destroy(capsule);
    }
}
