using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] List<GameObject> playerPoints = new List<GameObject>();
    [SerializeField] List<GameObject> AIPoints = new List<GameObject>();
    public static int playerScore, AIScore;
    public static bool increasePlayerScore, increaseAIScore;

    void Start()
    {
        playerScore = 0;
        AIScore = 0;
        increasePlayerScore = false;
        increaseAIScore = false;
    }

    void Update()
    {
        if(increasePlayerScore) {
            increasePlayerScore = false;
            this.GetComponent<AudioSource>().Play();
            playerPoints[playerScore - 1].gameObject.GetComponent<Animation>().Play("FadeAnimP1");
        }
        if(increaseAIScore) {
            increaseAIScore = false;
            this.GetComponent<AudioSource>().Play();
            AIPoints[AIScore - 1].gameObject.GetComponent<Animation>().Play("FadeAnimP1");
        }
    }
}
