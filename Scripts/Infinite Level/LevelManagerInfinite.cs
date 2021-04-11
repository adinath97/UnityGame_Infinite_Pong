using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManagerInfinite : MonoBehaviour
{
    public static bool startGameInfinite, ballMovingUpInfinite, resetBallInfinite, infiniteLevelOver, 
    leavingInfiniteLevel, fiveLeavingInfiniteLevel, tenLeavingInfiniteLevel, fifteenLeavingInfiniteLevel;
    int rand1, rand2;
    [SerializeField] List<Transform> ballInstantiationPoints = new List<Transform>(); 
    [SerializeField] GameObject ball;
    [SerializeField] GameObject playerPaddleInfinite;
    [SerializeField] GameObject AIPaddleInfiniteObject;
    [SerializeField] GameObject startMessage;
    [SerializeField] RawImage fade1;
    [SerializeField] RawImage fade2;
    
    // Start is called before the first frame update
    void Awake()
    {
        fade2.gameObject.SetActive(false);
        fade2.GetComponent<Animation>().enabled = false;
        Destroy(fade1,1f);
        SetUpRound();
        startMessage.GetComponent<Animation>().enabled = false;
        startGameInfinite = false;
        resetBallInfinite = false;
        infiniteLevelOver = false;
        ballMovingUpInfinite = false;
        leavingInfiniteLevel = false;
        fiveLeavingInfiniteLevel = false;
        tenLeavingInfiniteLevel = false;
        fifteenLeavingInfiniteLevel = false;
        rand2 = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(rand2 == 0) {
                startMessage.GetComponent<Animation>().enabled = true;
                startMessage.GetComponent<Animation>().Play("FadeOutText");
                rand2++;
            }
            startGameInfinite = true;
            AIPaddleInfiniteObject.GetComponent<AIPaddleInfinite>().startMovingInfinite = true;
        }

        if(resetBallInfinite) {
            AIPaddleInfiniteObject.GetComponent<AIPaddleInfinite>().startMovingInfinite = false;
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            SetUpRound();
            resetBallInfinite = false;
            ball.GetComponent<BoxBallInfinite>().launchedInfinite = false;
            ball.GetComponent<BoxBallInfinite>().hits = 0;
            startGameInfinite = false;
            BoxBallInfinite.baseVelocitySetInfinite = false;
            //Debug.Log("IN LEVELMANAGER: startGame is " + ball.GetComponent<Ball>().startGame);
            //AIPaddleInfiniteObject.GetComponent<AIPaddleInfinite>().startMovingInfinite = true;
        }

        if(leavingInfiniteLevel || fiveLeavingInfiniteLevel || tenLeavingInfiniteLevel || fifteenLeavingInfiniteLevel) {
            leavingInfiniteLevel = false;
            fiveLeavingInfiniteLevel = false;
            tenLeavingInfiniteLevel = false;
            fifteenLeavingInfiniteLevel = false;
            fade2.gameObject.SetActive(true);
            fade2.GetComponent<Animation>().enabled = true;
            //fade2.GetComponent<Animation>().Play("FadeScreen2");
        }

        if(infiniteLevelOver) {
            leavingInfiniteLevel = true;
            StartCoroutine(WaitAndLoadRoutine());
        }

        if(infiniteLevelOver && ScoreManagerInfinite.fiveInInfiniteLevel) {
            fiveLeavingInfiniteLevel = true;
            StartCoroutine(WaitAndLoadRoutine1());
        }

        if(infiniteLevelOver && ScoreManagerInfinite.tenInInfiniteLevel) {
            tenLeavingInfiniteLevel = true;
            StartCoroutine(WaitAndLoadRoutine2());
        }

        if(infiniteLevelOver && ScoreManagerInfinite.fifteenInInfiniteLevel) {
            fifteenLeavingInfiniteLevel = true;
            StartCoroutine(WaitAndLoadRoutine3());
        }
    }

    private IEnumerator WaitAndLoadRoutine() {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("InfiniteLevelOver");
    }

    private IEnumerator WaitAndLoadRoutine1() {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("5InInfiniteChallengeOver");
    }

    private IEnumerator WaitAndLoadRoutine2() {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("10InInfiniteChallengeOver");
    }

    private IEnumerator WaitAndLoadRoutine3() {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("15InInfiniteChallengeOver");
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
