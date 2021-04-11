using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeOptionsMenuManager : MonoBehaviour
{
    public static bool leavingChallengeOptionsMenuScene, lastPointWinsChallengeCompleted,
    downAndOutChallengeCompleted, fiveInInfiniteChallengeCompleted, tenInInfiniteChallengeCompleted, fifteenInInfiniteChallengeCompleted;
    [SerializeField] RawImage fade2;
    [SerializeField] RawImage fade1;
    [SerializeField] Text downAndOutText;
    [SerializeField] Text fiveInInfiniteText;
    [SerializeField] Text tenInInfiniteText;
    [SerializeField] Text fifteenInInfiniteText;

    void Start()
    {
        leavingChallengeOptionsMenuScene = false;
        fade2.gameObject.SetActive(false);
        fade2.GetComponent<Animation>().enabled = false;
        Destroy(fade1,1f);
        if(!lastPointWinsChallengeCompleted && !downAndOutChallengeCompleted
        && !fiveInInfiniteChallengeCompleted && !tenInInfiniteChallengeCompleted) {
            downAndOutText.text = "LOCKED";
            fiveInInfiniteText.text = "LOCKED";
            tenInInfiniteText.text = "LOCKED";
            fifteenInInfiniteText.text = "LOCKED";
        }
        if(lastPointWinsChallengeCompleted && !downAndOutChallengeCompleted
        && !fiveInInfiniteChallengeCompleted && !tenInInfiniteChallengeCompleted) {
            downAndOutText.text = "DOWN AND OUT";
            fiveInInfiniteText.text = "LOCKED";
            tenInInfiniteText.text = "LOCKED";
            fifteenInInfiniteText.text = "LOCKED";
        }
        if(lastPointWinsChallengeCompleted && downAndOutChallengeCompleted
        && !fiveInInfiniteChallengeCompleted && !tenInInfiniteChallengeCompleted) {
            downAndOutText.text = "DOWN AND OUT";
            fiveInInfiniteText.text = "FIVE IN INFINITE";
            tenInInfiniteText.text = "LOCKED";
            fifteenInInfiniteText.text = "LOCKED";
        }
        if(lastPointWinsChallengeCompleted && downAndOutChallengeCompleted
        && fiveInInfiniteChallengeCompleted && !tenInInfiniteChallengeCompleted) {
            downAndOutText.text = "DOWN AND OUT";
            fiveInInfiniteText.text = "FIVE IN INFINITE";
            tenInInfiniteText.text = "TEN IN INFINITE";
            fifteenInInfiniteText.text = "LOCKED";
        }
        if(lastPointWinsChallengeCompleted && downAndOutChallengeCompleted
        && fiveInInfiniteChallengeCompleted && tenInInfiniteChallengeCompleted) {
            downAndOutText.text = "DOWN AND OUT";
            fiveInInfiniteText.text = "FIVE IN INFINITE";
            tenInInfiniteText.text = "TEN IN INFINITE";
            fifteenInInfiniteText.text = "FIFTEEN IN INFINITE";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(leavingChallengeOptionsMenuScene == true) {
            leavingChallengeOptionsMenuScene = false;
            fade2.gameObject.SetActive(true);
            fade2.GetComponent<Animation>().enabled = true;
            //fade2.GetComponent<Animation>().Play("FadeScreen2");
        }
    }
}
