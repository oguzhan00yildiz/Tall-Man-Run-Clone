using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField] private GameObject caplsulePrefab;
    private bool tc;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Barricade"))
        {
            tc=false;
        }
        else
        {
            tc=true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")&&tc)
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
            ScaleControl.instance.TriggerDecrease=true;
            ScaleControl.instance.TriggerDecreaseHeight=true;
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")&&!tc)
        {
            ScaleControl.instance.TriggerDecrease=true;
            ScaleControl.instance.TriggerDecreaseHeight=true;
        }
    }
    

    private IEnumerator CapsuleCoroutine(GameObject capsule)
    {
        yield return new WaitForSeconds(1f);
        Destroy(capsule);
    }
}
