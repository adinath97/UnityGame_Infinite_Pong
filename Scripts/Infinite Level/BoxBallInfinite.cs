using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBallInfinite : MonoBehaviour
{
    [SerializeField] GameObject paddle;
    public Vector3 direction;
    Vector3 offset;
    public bool startGame;
    public bool launchedInfinite;
    public static bool baseVelocitySetInfinite;
    Rigidbody2D rb;
    AudioSource myAudioSource;
    int rand1,rand2,rand3,rand4;
    public int hits;
    bool noCollisionsNow, noCollisionsNowAI;
    public static float xVelocityInfinite,yVelocityInfinite,baseXVelocityInfinite,baseYVelocityInfinite,xShiftInfinite;

    // Start is called before the first frame update
    void Start()
    { 
        LevelManagerInfinite.startGameInfinite = false;
        launchedInfinite = false;
        hits = 0;
        rb = this.GetComponent<Rigidbody2D>();
        baseXVelocityInfinite = 10f;
        baseYVelocityInfinite = 19f;
        myAudioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!baseVelocitySetInfinite) {
            baseVelocitySetInfinite = true;
            xVelocityInfinite = baseXVelocityInfinite;
            yVelocityInfinite = baseYVelocityInfinite;
        }
        
        InitialLaunchMetrics();
        BallMovementMetrics();
    }

    void BallMovementMetrics() {
        if(rb.velocity.y > 0) {
            direction = Vector3.up;
            LevelManagerInfinite.ballMovingUpInfinite = true;
        }
        else if(rb.velocity.y < 0) {
            direction = Vector3.down;
            LevelManagerInfinite.ballMovingUpInfinite = false;
        }
        if(transform.position.y > 0) noCollisionsNow = false;
        if(transform.position.y < 0) noCollisionsNowAI = false;
    }

    void InitialLaunchMetrics() {
        if(Input.GetKeyDown(KeyCode.Space)) LevelManager.startGame = true;
        if(LevelManagerInfinite.startGameInfinite && !launchedInfinite) {
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
            launchedInfinite = true;
        }
    }

    void IncreaseVelocityOnProgression() {
        xVelocityInfinite += .05f;
        yVelocityInfinite += .25f;
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
                AIPaddleInfinite.pickChasingSpotInfinite = true;
                //Debug.Log(rb.velocity.magnitude);
            }
            if(collisionInfo.gameObject.tag == "playerLeftPart") {
                noCollisionsNow = true;
                //Debug.Log("LEFT!");
                hits++;
                rb.velocity = new Vector2(-xVelocityInfinite,yVelocityInfinite);
            }
            else if(collisionInfo.gameObject.tag == "playerMiddlePart") {
                noCollisionsNow = true;
                //Debug.Log("MIDDLE!");
                hits++;
                xShiftInfinite = Random.Range(-1.2f,1.2f);
                if(hits == 1) {
                    rb.velocity = new Vector2(xShiftInfinite,20f);
                }
                else {
                    rb.velocity = new Vector2(xShiftInfinite,rb.velocity.magnitude);
                }
            }
            else if(collisionInfo.gameObject.tag == "playerRightPart") {
                noCollisionsNow = true;
                //Debug.Log("RIGHT!");
                hits++;
                rb.velocity = new Vector2(xVelocityInfinite,yVelocityInfinite);
            }
        }
        if(!noCollisionsNowAI) {
            if((collisionInfo.gameObject.tag == "AILeftPart" 
            || collisionInfo.gameObject.tag == "AIMiddlePart" || 
            collisionInfo.gameObject.tag == "AIRightPart") && hits > 1) {
                IncreaseVelocityOnProgression();
                //Debug.Log(rb.velocity.magnitude);
            }
            //RandomlyIncreaseVelocity();
            if(collisionInfo.gameObject.tag == "AILeftPart") {
                noCollisionsNowAI = true;
                //Debug.Log("AI LEFT!");
                hits++;
                rb.velocity = new Vector2(-xVelocityInfinite,-yVelocityInfinite);
            }
            else if(collisionInfo.gameObject.tag == "AIMiddlePart") {
                noCollisionsNowAI = true;
                //Debug.Log("AI MIDDLE!");
                xShiftInfinite = Random.Range(-1.2f,1.2f);
                hits++;
                if(hits == 1) {
                    rb.velocity = new Vector2(xShiftInfinite,-20f);
                }
                else {
                    rb.velocity = new Vector2(xShiftInfinite,-rb.velocity.magnitude);
                }
            }
            else if(collisionInfo.gameObject.tag == "AIRightPart") {
                noCollisionsNowAI = true;
                //Debug.Log("AI RIGHT!");
                rb.velocity = new Vector2(xVelocityInfinite,-yVelocityInfinite);
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
