using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleInfinite : MonoBehaviour
{
    float xPos, deltaX, direction, scale, xMin, yMin, xMax, yMax;
    [SerializeField] GameObject ball;
    [SerializeField] float padding = 23.9f;
    [SerializeField] float moveSpeed = 50f;
    public static bool launchBallInfinite;

    void Start() {
        //SetUpMoveBoundaries();
        xMin = -13.2f;
        xMax = 10.9f;
        launchBallInfinite = false;
    }

    void Update()
    {
        if(PlayerScoreCollider.infinitePlayerScored) {
            PlayerScoreCollider.infinitePlayerScored = false;
            if(this.transform.localScale.x > 1.25f) {
                this.transform.localScale = new Vector3(
                this.transform.localScale.x - .1f,
                this.transform.localScale.y,
                this.transform.localScale.z);
                Debug.Log("Player paddle size decreased!");
                if(xMin > -13.8f) {
                    xMin -= .05f;
                }
                if(xMax < 12.4f) {
                    xMax += .15f;
                }
            }
            else if(this.transform.localScale.x < 1.25f) {
                this.transform.localScale = new Vector3(
                1.25f,
                this.transform.localScale.y,
                this.transform.localScale.z);
            }
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(LevelManagerInfinite.startGameInfinite) {
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
