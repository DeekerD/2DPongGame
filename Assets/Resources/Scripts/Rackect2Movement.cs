using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rackect2Movement : MonoBehaviour
{
    //movement of racket
    public float movementSpeed;

    //a methos to check if the user presses a buttonto determine movement of rackets
    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical2");

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * movementSpeed;
    }
}

