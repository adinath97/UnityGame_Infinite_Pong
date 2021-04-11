using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScoreCollider : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ball") {
            ScoreManager.AIScore++;
            ScoreManager.increaseAIScore = true;
            LevelManager.resetBall = true;
        }

        if(other.gameObject.tag == "BallInfinite") {
            LevelManagerInfinite.resetBallInfinite = true;
            ScoreManagerInfinite.decrementLives = true;
        }
    }
}
