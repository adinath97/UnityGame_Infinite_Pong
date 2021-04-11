using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPointWinsAIScoreCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ball") {
            LastPointWinsScoreManager.increaseAIScore = true;
            LastPointWinsScoreManager.AIScore++;
        }
    }
}
