using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfiniteEndLevelManager : MonoBehaviour
{
    [SerializeField] GameObject endLevelMessageText;
    [SerializeField] GameObject infiniteLevelScoreText;
    [SerializeField] GameObject infiniteLevelHighScoreText;
    [SerializeField] RawImage fade1;
    [SerializeField] RawImage fade2;
    public static bool leavingInfiniteEndLevel, fiveLeavingInfiniteEndLevel,
    tenLeavingInfiniteEndLevel, fifteenLeavingInfiniteEndLevel;

    void Awake()
    {
        leavingInfiniteEndLevel = false;
        tenLeavingInfiniteEndLevel = false;
        fiveLeavingInfiniteEndLevel = false;
        fifteenLeavingInfiniteEndLevel = false;
        fade2.gameObject.SetActive(false);
        fade2.GetComponent<Animation>().enabled = false;
        Destroy(fade1, 1f);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "InfiniteLevelOver") {
            if(ScoreManagerInfinite.newHighScore) {
                endLevelMessageText.GetComponent<Text>().text = "NEW HIGH SCORE! WELL DONE!";
            }
            else if(!ScoreManagerInfinite.newHighScore) {
                endLevelMessageText.GetComponent<Text>().text = "WELL DONE!";
            }
            infiniteLevelScoreText.GetComponent<Text>().text = "SCORE: " + ScoreManagerInfinite.playerScoreInfinite.ToString();
            infiniteLevelHighScoreText.GetComponent<Text>().text = "BEST: " + PlayerPrefs.GetFloat("HighScore",0f).ToString();
        }
        
        if(SceneManager.GetActiveScene().name == "5InInfiniteChallengeOver") {
            if(ScoreManagerInfinite.playerScoreInfinite >= 5) {
                endLevelMessageText.GetComponent<Text>().text = "YOU WIN! WELL DONE!";
            }
            else if(ScoreManagerInfinite.playerScoreInfinite < 5) {
                endLevelMessageText.GetComponent<Text>().text = "YOU LOST, BUT GREAT EFFORT!";
            }
        }

        if(SceneManager.GetActiveScene().name == "10InInfiniteChallengeOver") {
            if(ScoreManagerInfinite.playerScoreInfinite >= 10) {
                endLevelMessageText.GetComponent<Text>().text = "YOU WIN! WELL DONE!";
            }
            else if(ScoreManagerInfinite.playerScoreInfinite < 10) {
                endLevelMessageText.GetComponent<Text>().text = "YOU LOST, BUT GREAT EFFORT!";
            }
        } 

        if(SceneManager.GetActiveScene().name == "15InInfiniteChallengeOver") {
            if(ScoreManagerInfinite.playerScoreInfinite >= 15) {
                endLevelMessageText.GetComponent<Text>().text = "YOU WIN! WELL DONE!";
            }
            else if(ScoreManagerInfinite.playerScoreInfinite < 15) {
                endLevelMessageText.GetComponent<Text>().text = "YOU LOST, BUT GREAT EFFORT!";
            }
        }  
    }

    void Update()
    {
        if(leavingInfiniteEndLevel || fiveLeavingInfiniteEndLevel || tenLeavingInfiniteEndLevel || fifteenLeavingInfiniteEndLevel) {
            leavingInfiniteEndLevel = false;
            fiveLeavingInfiniteEndLevel = false;
            tenLeavingInfiniteEndLevel = false;
            fifteenLeavingInfiniteEndLevel = false;
            fade2.gameObject.SetActive(true);
            fade2.GetComponent<Animation>().enabled = true;
        }
    }
}
