using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public BallMovement ballMovement;
    public ScoreController scoreController;

    //method that take care of the way the ball moves due to the bounce from Rackets
    void BounceFromRacket(Collision2D c)
    {
        //so to know the ball should go top or buttom we need ball position, racket position amd racket height

        //to get ball position(it is done this way cause it is the ball that has the Collision Controller Script)
        Vector3 ballPosition = this.transform.position;

        //to get Racket position, racket should be the game object that we collide with
        Vector3 racketPosition = c.gameObject.transform.position;

        //to get the height of racket
        float racketHeight = c.collider.bounds.size.y;

        float x;

        //need to determine if ball will move to left or right depending on the player's racket
        if(c.gameObject.name == "RacketPlayer1")
        {
            x = 1; //go to the right
        }
        else
        {
            x = -1; // go to the left
        }

        //to determine buttom or top
        float y = (ballPosition.y - racketPosition.y) / racketHeight;

        this.ballMovement.IncreaseHitCounter();
        this.ballMovement.Moveball(new Vector2(x, y));
    }

    //whenever our gameObject collides with a 2d object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "RacketPlayer1" || collision.gameObject.name == "RacketPlayer2")
        {
            this.BounceFromRacket(collision);
        }
        else if(collision.gameObject.name == "WallLeft")
        {
            this.scoreController.GoalPlayer2();
            StartCoroutine(this.ballMovement.StartBall(true));
        }
        else if (collision.gameObject.name == "WallRight")
        {
            this.scoreController.GoalPlayer1();
            StartCoroutine(this.ballMovement.StartBall(false));
        }

    }


}