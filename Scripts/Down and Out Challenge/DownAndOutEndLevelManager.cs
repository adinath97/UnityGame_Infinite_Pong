using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownAndOutEndLevelManager : MonoBehaviour
{
    [SerializeField] GameObject playerOutcomeMessage;
    public static bool leavingDownAndOutEndLevel;
    [SerializeField] RawImage fade1;
    [SerializeField] RawImage fade2;

    void Awake()
    {
        leavingDownAndOutEndLevel = false;
        fade2.gameObject.SetActive(false);
        fade2.GetComponent<Animation>().enabled = false;
        Destroy(fade1, 1f);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if(DownAndOutScoreManager.AIScore > DownAndOutScoreManager.playerScore) {
            playerOutcomeMessage.GetComponent<Text>().text = "A VALIANT DISPLAY, BUT A DISAPPOINTING END NONETHELESS";
        }
        else {
            playerOutcomeMessage.GetComponent<Text>().text = "A WIN FOR THE AGES!";
        }
    }

    void Update()
    {
        if(leavingDownAndOutEndLevel) {
            leavingDownAndOutEndLevel = false;
            fade2.gameObject.SetActive(true);
            fade2.GetComponent<Animation>().enabled = true;
        }
    }
}
