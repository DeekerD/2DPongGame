using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketPlayer2AI : MonoBehaviour
{
    public float movementSpeed;

    public GameObject ball;

    private void FixedUpdate()
    {
        //check if absolute value of racket position - position of ball is > 50
        if(Mathf.Abs(this.transform.position.y - ball.transform.position.y)> 50)
        {
            //if racket is less than ball
            if(transform.position.y < ball.transform.position.y)
            {
                //move up
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * movementSpeed;
            }
            else
            {
                //move down
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * movementSpeed;
            }
        }
        else
        {
            //do not move
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
