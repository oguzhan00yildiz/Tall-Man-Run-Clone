using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{public float speed = 5f;
    public float rotationSpeed = 30f;

    private bool isMoving = false;

    void Update()
    {
        // Mouse sol tuşa basılıysa karakteri ileri doğru hareket ettir
        if (Input.GetMouseButton(0))
        {
            isMoving = true;

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
        }

        if (isMoving)
        {
            // Karakterin ileri doğru hareketi
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
