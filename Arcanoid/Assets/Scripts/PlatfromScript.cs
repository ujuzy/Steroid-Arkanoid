using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromScript : MonoBehaviour
{
    private const float MovementSpeed = 0.3f;
    private const float Border = 8.0f;
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > (-1) * Border)
        {
            transform.position += new Vector3((-1) * MovementSpeed, 0);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < Border)
        {
            transform.position += new Vector3(MovementSpeed, 0);
        }
    }
}
