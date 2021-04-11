using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastPointWinsEndLevelManager : MonoBehaviour
{
    [SerializeField] GameObject playerOutcomeMessage;
    public static bool leavingLastPointWinsEndLevel;
    [SerializeField] RawImage fade1;
    [SerializeField] RawImage fade2;

    void Awake()
    {
        leavingLastPointWinsEndLevel = false;
        fade2.gameObject.SetActive(false);
        fade2.GetComponent<Animation>().enabled = false;
        Destroy(fade1, 1f);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if(LastPointWinsScoreManager.AIScore > LastPointWinsScoreManager.playerScore) {
            playerOutcomeMessage.GetComponent<Text>().text = "BETTER LUCK NEXT TME!";
        }
        else {
            playerOutcomeMessage.GetComponent<Text>().text = "WELL DONE, MY FRIEND!";
        }
    }

    void Update()
    {
        if(leavingLastPointWinsEndLevel) {
            leavingLastPointWinsEndLevel = false;
            fade2.gameObject.SetActive(true);
            fade2.GetComponent<Animation>().enabled = true;
        }
    }
}
