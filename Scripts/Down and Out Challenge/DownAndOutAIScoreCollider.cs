using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownAndOutAIScoreCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ball") {
            DownAndOutScoreManager.AIScore++;
            DownAndOutScoreManager.increaseAIScore = true;
            DownAndOutLevelManager.resetBall = true;
        }

        if(other.gameObject.tag == "BallInfinite") {
            LevelManagerInfinite.resetBallInfinite = true;
            ScoreManagerInfinite.decrementLives = true;
        }
    }
}
