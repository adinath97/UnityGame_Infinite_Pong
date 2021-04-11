using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPointWinsBoxBall : MonoBehaviour
{
    [SerializeField] GameObject paddle;
    public Vector3 direction;
    Vector3 offset;
    public bool startGame, launched;
    public static bool baseVelocitySet;
    Rigidbody2D rb;
    AudioSource myAudioSource;
    int rand1,rand2,rand3,rand4;
    public int hits;
    public static float xVelocity,yVelocity,baseXVelocity,baseYVelocity,xShift;
    bool noCollisionsNow, noCollisionsNowAI;

    // Start is called before the first frame update
    void Start()
    { 
        LastPointWinsLevelManager.startGame = false;
        launched = false;
        hits = 0;
        rb = this.GetComponent<Rigidbody2D>();
        baseXVelocity = 9f;
        baseYVelocity = 18f;
        baseVelocitySet = false;
        myAudioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!baseVelocitySet) {
            baseVelocitySet = true;
            xVelocity = baseXVelocity;
            yVelocity = baseYVelocity;
        }
        InitialLaunchMetrics();
        BallMovementMetrics();
    }

    void BallMovementMetrics() {
        if(rb.velocity.y >= 0) {
            direction = Vector3.up;
            LastPointWinsLevelManager.ballMovingUp = true;
        }
        else if(rb.velocity.y < 0) {
            direction = Vector3.down;
             LastPointWinsLevelManager.ballMovingUp = false;
        }
        if(transform.position.y > 0) noCollisionsNow = false;
        if(transform.position.y < 0) noCollisionsNowAI = false;
    }

    void InitialLaunchMetrics() {
        if(Input.GetKeyDown(KeyCode.Space)) LastPointWinsLevelManager.startGame = true;
        if(LastPointWinsLevelManager.startGame && !launched) {
            //Debug.Log("Value of startGame is: " + LevelManager.startGame);
            rand3 = Mathf.RoundToInt(Random.Range(0,10));
            switch(rand3) {
                case 0:
                    //Debug.Log("case 0");
                    rb.velocity = new Vector2(2.5f,10f);
                    break;
                case 1:
                    //Debug.Log("case 1");
                    rb.velocity = new Vector2(-3f,10f);
                    break;
                case 2:
                    //Debug.Log("case 2");
                    rb.velocity = new Vector2(1f,10f);
                    break;
                case 3:
                    //Debug.Log("case 3");
                    rb.velocity = new Vector2(-5f,10f);
                    break;
                case 4:
                    //Debug.Log("case 4");
                    rb.velocity = new Vector2(4f,10f);
                    break;
                case 5:
                    //Debug.Log("case 5");
                    rb.velocity = new Vector2(2.5f,10f);
                    break;
                case 6:
                    //Debug.Log("case 6");
                    rb.velocity = new Vector2(-3f,-10f);
                    break;
                case 7:
                    //Debug.Log("case 7");
                    rb.velocity = new Vector2(1f,-10f);
                    break;
                case 8:
                    //Debug.Log("case 8");
                    rb.velocity = new Vector2(-5f,-10f);
                    break;
                case 9:
                    //Debug.Log("case 9");
                    rb.velocity = new Vector2(4f,-10f);
                    break;
            }
            launched = true;
        }
    }

    void IncreaseVelocityOnProgression() {
        xVelocity += .05f;
        yVelocity += .25f;
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        myAudioSource.Play();
        //Debug.Log(rb.velocity.magnitude);
        if(!noCollisionsNow) {
            //RandomlyIncreaseVelocity();
            if((collisionInfo.gameObject.tag == "playerLeftPart" 
            || collisionInfo.gameObject.tag == "playerMiddlePart" || 
            collisionInfo.gameObject.tag == "playerRightPart") && hits > 1) {
                IncreaseVelocityOnProgression();
                LastPointWinsAIPaddle.pickChasingSpot = true;
                Debug.Log(rb.velocity.magnitude);
            }
            if(collisionInfo.gameObject.tag == "playerLeftPart") {
                noCollisionsNow = true;
                //Debug.Log("LEFT!");
                //Debug.Log("Hits at " + hits + ": " + rb.velocity.magnitude);
                hits++;
                rb.velocity = new Vector2(-xVelocity,yVelocity);
            }
            else if(collisionInfo.gameObject.tag == "playerMiddlePart") {
                noCollisionsNow = true;
                //Debug.Log("MIDDLE!");
                hits++;
                xShift = Random.Range(-1.1f,1.1f);
                if(hits == 1) {
                    rb.velocity = new Vector2(xShift,20f);
                }
                else {
                    rb.velocity = new Vector2(xShift,rb.velocity.magnitude);
                }
                
            }
            else if(collisionInfo.gameObject.tag == "playerRightPart") {
                noCollisionsNow = true;
                //Debug.Log("Hits at " + hits + ": " + rb.velocity.magnitude);
                //Debug.Log("RIGHT!");
                hits++;
                rb.velocity = new Vector2(xVelocity,yVelocity);
            }
        }
        if(!noCollisionsNowAI) {
            if((collisionInfo.gameObject.tag == "AILeftPart" 
            || collisionInfo.gameObject.tag == "AIMiddlePart" || 
            collisionInfo.gameObject.tag == "AIRightPart") && hits > 1) {
                IncreaseVelocityOnProgression();
                Debug.Log(rb.velocity.magnitude);
            }
            //RandomlyIncreaseVelocity();
            if(collisionInfo.gameObject.tag == "AILeftPart") {
                noCollisionsNowAI = true;
                //Debug.Log("AI LEFT!");
                hits++;
                rb.velocity = new Vector2(-xVelocity,-yVelocity);
            }
            else if(collisionInfo.gameObject.tag == "AIMiddlePart") {
                noCollisionsNowAI = true;
                //Debug.Log("AI MIDDLE!");
                hits++;
                xShift = Random.Range(-1.1f,1.1f);
                if(hits == 1) {
                    rb.velocity = new Vector2(xShift,-20f);
                }
                else {
                    Debug.Log("ELSE! AI MID");
                    rb.velocity = new Vector2(xShift,-rb.velocity.magnitude);
                }
            }
            else if(collisionInfo.gameObject.tag == "AIRightPart") {
                noCollisionsNowAI = true;
                //Debug.Log("AI RIGHT!");
                hits++;
                rb.velocity = new Vector2(xVelocity,-yVelocity);
            }
        }
    }

    void RandomlyIncreaseVelocity() {
        //Debug.Log(rb.velocity.magnitude);
        //if(startGame) myAudioSource.Play();
        rand1 = Mathf.RoundToInt(Random.Range(0,10));
        rand2 = Mathf.RoundToInt(Random.Range(0,10));
        if(rand1 == rand2) {
            //Debug.Log("MATCH!");
            if(rb.velocity.x > 0 && rb.velocity.y > 0) {
                rb.velocity = new Vector2(rb.velocity.x + .1f, rb.velocity.y + .1f);
            }
            else if(rb.velocity.x > 0 && rb.velocity.y < 0) {
                rb.velocity = new Vector2(rb.velocity.x + .1f, rb.velocity.y - .1f);
            }
            else if(rb.velocity.x < 0 && rb.velocity.y > 0) {
                rb.velocity = new Vector2(rb.velocity.x - .1f, rb.velocity.y - .1f);
            }
            else if(rb.velocity.x < 0 && rb.velocity.y < 0) {
                rb.velocity = new Vector2(rb.velocity.x - .1f, rb.velocity.y - .1f);
            }
        }
    }
}
