using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;

    void FixedUpdate()
    {
        verticalInput = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (verticalInput > 0)
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }
        else
        {
            if (verticalInput < 0)
            {
                transform.Rotate(Vector3.right * -rotationSpeed * Time.deltaTime);
            }
        }
    }
}
