using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DownAndOutLevelManager : MonoBehaviour
{
    public static bool startGame, ballMovingUp, resetBall, leavingDownAndOutLevel;
    int rand1, rand2;
    [SerializeField] List<Transform> ballInstantiationPoints = new List<Transform>(); 
    [SerializeField] GameObject ball;
    [SerializeField] GameObject playerPaddle;
    [SerializeField] GameObject AIpaddle;
    [SerializeField] GameObject instructionsText;
    [SerializeField] RawImage fade1;
    [SerializeField] RawImage fade2;
    
    // Start is called before the first frame update
    void Awake()
    {
        fade2.gameObject.SetActive(false);
        fade2.GetComponent<Animation>().enabled = false;
        Destroy(fade1,1f);
        SetUpRound();
        startGame = false;
        ballMovingUp = false;
        resetBall = false;
        leavingDownAndOutLevel = false;
        instructionsText.GetComponent<Animation>().enabled = false;
        rand2 = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Space)) {
            startGame = true;
            DownAndOutAIPaddle.startMoving = true;
            if(rand2 == 0) {
                instructionsText.GetComponent<Animation>().enabled = true;
                instructionsText.GetComponent<Animation>().Play("FadeOutText");
            }
            rand2++;
        }

        if(resetBall) {
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            SetUpRound();
            resetBall = false;
            ball.GetComponent<DownAndOutBoxBall>().launched = false;
            ball.GetComponent<DownAndOutBoxBall>().hits = 0;
            startGame = false;
            //Debug.Log("IN LEVELMANAGER: startGame is " + ball.GetComponent<Ball>().startGame);
            DownAndOutAIPaddle.startMoving = false;
            DownAndOutBoxBall.baseVelocitySet = false;
        }

        if(DownAndOutScoreManager.AIScore >= 10 || DownAndOutScoreManager.playerScore >= 10) {
            leavingDownAndOutLevel = true;
            if(ChallengeOptionsMenuManager.lastPointWinsChallengeCompleted && DownAndOutScoreManager.playerScore >= 10) {
                ChallengeOptionsMenuManager.downAndOutChallengeCompleted = true;
            }
            StartCoroutine(WaitAndLoadRoutine());
        }

        if(leavingDownAndOutLevel) {
            leavingDownAndOutLevel = false;
            fade2.gameObject.SetActive(true);
            fade2.GetComponent<Animation>().enabled = true;
        }

        IEnumerator WaitAndLoadRoutine() {
            yield return new WaitForSeconds(.5f);
            SceneManager.LoadScene("DownAndOutChallengeOver");
        }
    }

    void SetUpRound() {
        rand1 = Mathf.RoundToInt(Random.Range(0,5));
        switch(rand1) {
            case 0:
                //Debug.Log("POSITION 0!");
                ball.transform.position = ballInstantiationPoints[0].position;
                //Instantiate(ball,ballInstantiationPoints[0].position,Quaternion.identity);
                break;
            case 1:
                //Debug.Log("POSITION 1!");
                ball.transform.position = ballInstantiationPoints[1].position;
                break;
            case 2:
                //Debug.Log("POSITION 2!");
                ball.transform.position = ballInstantiationPoints[2].position;
                break;
            case 3:
                //Debug.Log("POSITION 3!");
                ball.transform.position = ballInstantiationPoints[3].position;
                break;
            case 4:
                //Debug.Log("POSITION 4!");
                ball.transform.position = ballInstantiationPoints[4].position;
                break;
        }
    }
}
