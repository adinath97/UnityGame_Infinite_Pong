using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPointWInsPlayerPaddle : MonoBehaviour
{
    float xPos, deltaX, direction, scale, xMin, yMin, xMax, yMax;
    [SerializeField] GameObject ball;
    [SerializeField] float padding = 23.9f;
    [SerializeField] float moveSpeed = 50f;
    public static bool launchBall;

    void Start() {
        //SetUpMoveBoundaries();
        xMin = -13.2f;
        xMax = 10.9f;
        launchBall = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(LastPointWinsLevelManager.startGame) {
            MovePlayer();
        }
        //transform.position = new Vector2(ball.transform.position.x,transform.position.y);
    }

    void MovePlayer() {
        deltaX = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * moveSpeed;
        xPos = Mathf.Clamp(transform.position.x + deltaX,xMin,xMax);
        transform.position = new Vector2(xPos,transform.position.y);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
