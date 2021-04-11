using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreCollider : MonoBehaviour
{
    public static bool infinitePlayerScored;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ball") {
            ScoreManager.playerScore++;
            ScoreManager.increasePlayerScore = true;
            LevelManager.resetBall = true;
            AIPaddle.moveSpeed += Random.Range(.1f,1.1f);
            Debug.Log("AIPaddle speed is: now " + AIPaddle.moveSpeed);
        }

        if(other.gameObject.tag == "BallInfinite") {
            this.GetComponent<AudioSource>().Play();
            infinitePlayerScored = true;
            ScoreManagerInfinite.playerScoreInfinite++;
            LevelManagerInfinite.resetBallInfinite = true;
            AIPaddleInfinite.moveSpeed += Random.Range(.1f,.3f);
            Debug.Log("AIPaddle speed is: now " + AIPaddleInfinite.moveSpeed);
        }


    }
}
