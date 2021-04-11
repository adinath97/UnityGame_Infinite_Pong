using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPointWinsPlayerScoreCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ball") {
            LastPointWinsScoreManager.playerScore++;
            LastPointWinsScoreManager.increasePlayerScore = true;
            LastPointWinsAIPaddle.moveSpeed++;
            Debug.Log("AIPaddle speed is: now " + LastPointWinsAIPaddle.moveSpeed);
        }
    }
}
