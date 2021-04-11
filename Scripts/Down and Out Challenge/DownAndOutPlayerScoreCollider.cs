using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownAndOutPlayerScoreCollider : MonoBehaviour
{
    public static bool infinitePlayerScored;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ball") {
            DownAndOutScoreManager.playerScore++;
            DownAndOutScoreManager.increasePlayerScore = true;
            DownAndOutLevelManager.resetBall = true;
            DownAndOutAIPaddle.moveSpeed += Random.Range(.1f,1.1f);
            Debug.Log("AIPaddle speed is: now " + AIPaddle.moveSpeed);
        }

        if(other.gameObject.tag == "BallInfinite") {
            infinitePlayerScored = true;
            ScoreManagerInfinite.playerScoreInfinite++;
            LevelManagerInfinite.resetBallInfinite = true;
            AIPaddleInfinite.moveSpeed += Random.Range(.1f,.3f);
            Debug.Log("AIPaddle speed is: now " + AIPaddleInfinite.moveSpeed);
        }
    }
}
