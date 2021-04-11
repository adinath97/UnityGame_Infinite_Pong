using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassicEndLevelManager : MonoBehaviour
{
    [SerializeField] GameObject endLevelMessageText;
    [SerializeField] GameObject playerScoreText;
    [SerializeField] GameObject AIScoreText;
    [SerializeField] RawImage fade1;
    [SerializeField] RawImage fade2;
    public static bool leavingClassicEndLevel;
    
    void Awake()
    {
        leavingClassicEndLevel = false;
        fade2.gameObject.SetActive(false);
        fade2.GetComponent<Animation>().enabled = false;
        Destroy(fade1, 1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(ScoreManager.playerScore > ScoreManager.AIScore) {
            endLevelMessageText.GetComponent<Text>().text = "YOU WON! WELL DONE!";
        }
        else if(ScoreManager.playerScore < ScoreManager.AIScore) {
            endLevelMessageText.GetComponent<Text>().text = "BETTER LUCK NEXT TIME!";
        }
        playerScoreText.GetComponent<Text>().text = ScoreManager.playerScore.ToString();
        AIScoreText.GetComponent<Text>().text = ScoreManager.AIScore.ToString();
    }

    void Update()
    {
        if(leavingClassicEndLevel) {
            leavingClassicEndLevel = false;
            fade2.gameObject.SetActive(true);
            fade2.GetComponent<Animation>().enabled = true;
        }
    }
}
