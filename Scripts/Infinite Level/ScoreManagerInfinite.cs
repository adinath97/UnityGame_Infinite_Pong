using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManagerInfinite : MonoBehaviour
{
    [SerializeField] GameObject playerScoreBox;
    [SerializeField] GameObject highScoreBox;
    [SerializeField] List<GameObject> lives = new List<GameObject>();
    public static float playerScoreInfinite;
    public static int playerLives;
    public static bool decrementLives, newHighScore, fiveInInfiniteLevel, tenInInfiniteLevel, fifteenInInfiniteLevel;

    void Start()
    {
        playerScoreInfinite = 0;
        playerLives = 0;
        decrementLives = false;
        newHighScore = false;
        highScoreBox.GetComponent<Text>().text = "BEST: " + PlayerPrefs.GetFloat("HighScore",0f).ToString();
    }

    void Update()
    {
        playerScoreBox.GetComponent<Text>().text = playerScoreInfinite.ToString();
        if(decrementLives) {
            decrementLives = false;
            this.GetComponent<AudioSource>().Play();
            lives[playerLives].gameObject.GetComponent<Animation>().Play("FadeToBlack");
            playerLives++;
        }

        if(playerLives == 3) {
            LevelManagerInfinite.infiniteLevelOver = true;
        }

        if(playerScoreInfinite > PlayerPrefs.GetFloat("HighScore", 0f))
        {
            newHighScore = true;
            PlayerPrefs.SetFloat("HighScore", playerScoreInfinite);
            highScoreBox.GetComponent<Text>().text = "BEST: " + PlayerPrefs.GetFloat("HighScore", 0f).ToString();
        }

        if(SceneManager.GetActiveScene().name == "5InInfiniteChallenge") {
            if(playerScoreInfinite >= 5 && ChallengeOptionsMenuManager.downAndOutChallengeCompleted && ChallengeOptionsMenuManager.lastPointWinsChallengeCompleted) {
                LevelManagerInfinite.infiniteLevelOver = true;
                ChallengeOptionsMenuManager.fiveInInfiniteChallengeCompleted = true;
            }
        }

        if(SceneManager.GetActiveScene().name == "10InInfiniteChallenge") {
            if(playerScoreInfinite >= 10 && ChallengeOptionsMenuManager.downAndOutChallengeCompleted && ChallengeOptionsMenuManager.lastPointWinsChallengeCompleted && ChallengeOptionsMenuManager.fiveInInfiniteChallengeCompleted) {
                LevelManagerInfinite.infiniteLevelOver = true;
                ChallengeOptionsMenuManager.tenInInfiniteChallengeCompleted = true;
            }
        } 

        if(SceneManager.GetActiveScene().name == "15InInfiniteChallenge") {
            if(playerScoreInfinite >= 15 && ChallengeOptionsMenuManager.downAndOutChallengeCompleted && ChallengeOptionsMenuManager.lastPointWinsChallengeCompleted && ChallengeOptionsMenuManager.fiveInInfiniteChallengeCompleted && ChallengeOptionsMenuManager.tenInInfiniteChallengeCompleted) {
                LevelManagerInfinite.infiniteLevelOver = true;
                ChallengeOptionsMenuManager.fifteenInInfiniteChallengeCompleted = true;
            }
        }   
    }
}
