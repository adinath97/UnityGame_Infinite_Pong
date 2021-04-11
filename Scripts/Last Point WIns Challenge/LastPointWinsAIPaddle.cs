using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPointWinsAIPaddle : MonoBehaviour
{
    float d, xPos, deltaX, direction, scale, xMin, yMin, xMax, yMax, subFactor;
    Vector3 move = Vector3.zero;
    public static bool startMoving, pickChasingSpot;
    int rand1;
    [SerializeField] GameObject ball;
    public static float moveSpeed;

    void Start() {
        //SetUpMoveBoundaries();
        xMin = -13.2f;
        xMax = 10.9f;
        startMoving = false;
        moveSpeed = Random.Range(18f,19f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //MovePlayer();
        if(startMoving && LastPointWinsLevelManager.ballMovingUp) {
            if(pickChasingSpot) {
                //Debug.Log("FOUND CHASING SPOT");
                pickChasingSpot = false;
                rand1 = Mathf.RoundToInt(Random.Range(0,3));
                switch(rand1) {
                    case 0:
                        subFactor = Random.Range(0,2f);
                        break;
                    case 2:
                        subFactor = Random.Range(0,1.5f);
                        break;
                    case 1:
                        subFactor = 0f;
                        break;
                }
            }
            MoveAIPaddle();
            /*
            //first attempt at AI that is variable in strength
            rand1 = Mathf.RoundToInt(Random.Range(0,4));
            rand2 = Mathf.RoundToInt(Random.Range(0,4));
            if(rand1 == rand2) {
                this.transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(ball.transform.position.x,transform.position.y),
                5f);
            }
            
            //perfect/unbeatable AI
            xPos = Mathf.Clamp(ball.transform.position.x,xMin,xMax);
            transform.position = new Vector2(xPos,transform.position.y);
            */
        }
        
    }

    void MoveAIPaddle() {
        switch(rand1) {
            case 0:
                d = ball.transform.position.x - transform.position.x - subFactor;
                //Debug.Log("CASE 0!");
                break;
            case 1:
                d = ball.transform.position.x - transform.position.x - subFactor;
                //Debug.Log("CASE 1!");
                break;
            case 2:
                d = ball.transform.position.x - transform.position.x - subFactor;
                //Debug.Log("CASE 2!");
                break;
        }
        //d = ball.transform.position.x - transform.position.x;
        if(d > 0){
            move.x = moveSpeed * Mathf.Min(d, 1.0f);    
        }
        if(d < 0){
            move.x = -(moveSpeed * Mathf.Min(-d, 1.0f));
        }

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x + move.x * Time.fixedDeltaTime,xMin,xMax),
            transform.position.y
        );
        /*
        if(ball.transform.localPosition.x < this.transform.localPosition.x) {
            this.transform.localPosition += new Vector3(-moveSpeed * Time.deltaTime,0f,0f);
        }
        if(ball.transform.localPosition.x > this.transform.localPosition.x) {
            this.transform.localPosition += new Vector3(moveSpeed * Time.deltaTime,0f,0f);
        }
        */
    }
}
