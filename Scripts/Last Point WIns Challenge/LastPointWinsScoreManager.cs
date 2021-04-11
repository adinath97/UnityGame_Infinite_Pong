using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPointWinsScoreManager : MonoBehaviour
{
    [SerializeField] List<GameObject> playerPoints = new List<GameObject>();
    [SerializeField] List<GameObject> AIPoints = new List<GameObject>();
    public static int playerScore, AIScore;
    public static bool increasePlayerScore, increaseAIScore;

    void Start()
    {
        playerScore = 9;
        AIScore = 9;
        playerPoints[playerScore - 1].gameObject.GetComponent<Animation>().Play("FadeAnimP1");
        AIPoints[AIScore - 1].gameObject.GetComponent<Animation>().Play("FadeAnimP1");
        increasePlayerScore = false;
        increaseAIScore = false;
        for(int i = 0; i < playerPoints.Count - 1; i++) {
            playerPoints[i].gameObject.GetComponent<Animation>().Play("FadeAnimP1");
        }
        for(int i = 0; i < AIPoints.Count - 1; i++) {
            AIPoints[i].gameObject.GetComponent<Animation>().Play("FadeAnimP1");
        }
    }

    void Update()
    {
        if(increasePlayerScore) {
            //Debug.Log("PLAYER INCR WIN");
            increasePlayerScore = false;
            this.GetComponent<AudioSource>().Play();
            playerPoints[9].gameObject.GetComponent<Animation>().Play("FadeAnimP1");
        }
        if(increaseAIScore) {
            //Debug.Log("AI INCR WIN");
            increaseAIScore = false;
            this.GetComponent<AudioSource>().Play();
            AIPoints[9].gameObject.GetComponent<Animation>().Play("FadeAnimP1");
        }
    }
}
