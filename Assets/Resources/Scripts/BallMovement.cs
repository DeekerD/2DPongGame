using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //a variable for movement speed for the ball
    public float movementSpeed;

    //a variable for how fast it can go per hit
    public float extraSpeed;

    //a variable for maximum speed
    public float maxSpeed; 

    //variable to count how many times a Racket has been hit
    int hitCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.StartBall());
    }

    //method to reposition thE ball
    void PositionBall(bool isStartingPlayer1)
    {
        //no velocity
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

        if (isStartingPlayer1)
        {
            this.gameObject.transform.localPosition = new Vector3(-100, 0, 0);//Left of the centre

        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(100, 0, 0);//Right of the centre
        }
    }

    //creating a that returns an IEnumerator to use in a couroutine
    //coroutine forces everything else to wait for it before a new action happens
    public IEnumerator StartBall(bool isStartingPlayer1 = true)//this mean that if no value is given,
                                                               //Player1 will be true and ball will move from left to right
    {
        this.PositionBall(isStartingPlayer1);

        this.hitCounter = 0;
        //we make our game wait for two seconds
        yield return new WaitForSeconds(2);

        //check if  player1 is starting
        if (isStartingPlayer1)
        {
            //means the ball will move to the left
            this.Moveball(new Vector2(-1, 0));
        }
        else
        {
            //means the ball will move to the right
            this.Moveball(new Vector2(1, 0));
        }
    }

   //A method that indicates how fast the ball can move
   public void Moveball(Vector2 dir)
    {
        //first we need to normalize our direction
        dir = dir.normalized;

        //create a speed
        float speed = this.movementSpeed + this.hitCounter * this.extraSpeed;

        //to apply the speed to our ball, need to apply a force to a rigid body
        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

        rigidbody2D.velocity = dir * speed;
    }

    //method to increment hitCounter
    public void IncreaseHitCounter()
    {
        if(this.hitCounter * this.extraSpeed <= this.maxSpeed)
        {
            this.hitCounter++;
        }
    }
}
