using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{public float speed = 5f;
    public float rotationSpeed = 30f;

    public bool isMoving = false;
    public Animator anim;
    public static PlayerMovement instance;
    public bool BonusRun;

    void Update()
    {
        
        if (Input.GetMouseButton(0)&&!BonusRun)
        {
            isMoving = true;

            anim.SetBool("isRunning",true);

            // Mouse'u sağa veya sola çekince karakterin dönmesi
            float mouseX = Input.GetAxis("Mouse X");

            if (Mathf.Abs(mouseX) > 0.1f)
            {
                // Karakterin dönüşü
                float rotationAmount = mouseX * rotationSpeed * Time.deltaTime;
                transform.Rotate(Vector3.up, rotationAmount);
            }
        }
        else
        {
            isMoving = false;
            anim.SetBool("isRunning",false);
        }

        if (BonusRun)
        {
            isMoving = true;
        }


        if (isMoving)
        {
            // Karakterin ileri doğru hareketi
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void Start()
    {
        instance=this;
    }

}
