using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    public void LoadAudioControlMenu() {
        this.GetComponent<AudioSource>().Play();
        if(SceneManager.GetActiveScene().name == "StartMenu") {
            Debug.Log(SceneManager.GetActiveScene().name);
            MenuSceneManager.leavingMenuScene = true;
        }
        StartCoroutine(WaitAndLoadRoutine10());
    }
    public void LoadClassicLevel() {
        this.GetComponent<AudioSource>().Play();
        if(SceneManager.GetActiveScene().name == "StartMenu") {
            Debug.Log(SceneManager.GetActiveScene().name);
            MenuSceneManager.leavingMenuScene = true;
        }
        if(SceneManager.GetActiveScene().name == "ClassicLevelOver") {
            Debug.Log(SceneManager.GetActiveScene().name);
            ClassicEndLevelManager.leavingClassicEndLevel = true;
        }
        StartCoroutine(WaitAndLoadRoutine1());
    }

    public void Load5InInfiniteChallenge() {
        if(ChallengeOptionsMenuManager.downAndOutChallengeCompleted) {
            this.GetComponent<AudioSource>().Play();
            ScoreManagerInfinite.tenInInfiniteLevel = false;
            ScoreManagerInfinite.fifteenInInfiniteLevel = false;
            ScoreManagerInfinite.fiveInInfiniteLevel = true;
            if(SceneManager.GetActiveScene().name == "ChallengeOptionsMenu") {
                Debug.Log(SceneManager.GetActiveScene().name);
                ChallengeOptionsMenuManager.leavingChallengeOptionsMenuScene = true;
            }
            if(SceneManager.GetActiveScene().name == "5InInfiniteChallengeOver") {
                Debug.Log(SceneManager.GetActiveScene().name);
                InfiniteEndLevelManager.fiveLeavingInfiniteEndLevel = true;
            }
            StartCoroutine(WaitAndLoadRoutine5());
        }
    }

    public void Load10InInfiniteChallenge() {
        if(ChallengeOptionsMenuManager.fiveInInfiniteChallengeCompleted) {
            this.GetComponent<AudioSource>().Play();
            ScoreManagerInfinite.tenInInfiniteLevel = true;
            ScoreManagerInfinite.fifteenInInfiniteLevel = false;
            ScoreManagerInfinite.fiveInInfiniteLevel = false;
            if(SceneManager.GetActiveScene().name == "ChallengeOptionsMenu") {
                Debug.Log(SceneManager.GetActiveScene().name);
                ChallengeOptionsMenuManager.leavingChallengeOptionsMenuScene = true;
            }
            if(SceneManager.GetActiveScene().name == "10InInfiniteChallengeOver") {
                Debug.Log(SceneManager.GetActiveScene().name);
                InfiniteEndLevelManager.tenLeavingInfiniteEndLevel = true;
            }
            StartCoroutine(WaitAndLoadRoutine6());
        }
        
    }

    public void Load15InInfiniteChallenge() {
        if(ChallengeOptionsMenuManager.tenInInfiniteChallengeCompleted) {
            this.GetComponent<AudioSource>().Play();
            ScoreManagerInfinite.tenInInfiniteLevel = false;
            ScoreManagerInfinite.fifteenInInfiniteLevel = true;
            ScoreManagerInfinite.fiveInInfiniteLevel = false;
            if(SceneManager.GetActiveScene().name == "ChallengeOptionsMenu") {
                Debug.Log(SceneManager.GetActiveScene().name);
                ChallengeOptionsMenuManager.leavingChallengeOptionsMenuScene = true;
            }
            if(SceneManager.GetActiveScene().name == "15InInfiniteChallengeOver") {
                Debug.Log(SceneManager.GetActiveScene().name);
                InfiniteEndLevelManager.fifteenLeavingInfiniteEndLevel = true;
            }
            StartCoroutine(WaitAndLoadRoutine7());
        }
    }

    public void LoadDownAndOutChallenge() {
        if(ChallengeOptionsMenuManager.lastPointWinsChallengeCompleted) {
            this.GetComponent<AudioSource>().Play();
            if(SceneManager.GetActiveScene().name == "ChallengeOptionsMenu") {
                Debug.Log(SceneManager.GetActiveScene().name);
                ChallengeOptionsMenuManager.leavingChallengeOptionsMenuScene = true;
            }
            if(SceneManager.GetActiveScene().name == "DownAndOutChallengeOver") {
                Debug.Log(SceneManager.GetActiveScene().name);
                DownAndOutEndLevelManager.leavingDownAndOutEndLevel = true;
            }
            StartCoroutine(WaitAndLoadRoutine8());
        }
        
    }

    public void LoadInfiniteLevel() {
        this.GetComponent<AudioSource>().Play();
        if(SceneManager.GetActiveScene().name == "StartMenu") {
            Debug.Log(SceneManager.GetActiveScene().name);
            MenuSceneManager.leavingMenuScene = true;
        }
        if(SceneManager.GetActiveScene().name == "InfiniteLevelOver") {
            Debug.Log(SceneManager.GetActiveScene().name);
            InfiniteEndLevelManager.leavingInfiniteEndLevel = true;
        }
        StartCoroutine(WaitAndLoadRoutine3());
    }

    public void QuitGame() {
        this.GetComponent<AudioSource>().Play();
        Application.Quit();
    }

    public void LoadMainMenu() {
        this.GetComponent<AudioSource>().Play();
        if(SceneManager.GetActiveScene().name == "AudioControlMenu") {
            AudioControlScene.leavingAudioControlScene = true;
        }
        if(SceneManager.GetActiveScene().name == "ClassicLevelOver") {
            ClassicEndLevelManager.leavingClassicEndLevel = true;
        }
        if(SceneManager.GetActiveScene().name == "InfiniteLevelOver") {
            Debug.Log(SceneManager.GetActiveScene().name);
            InfiniteEndLevelManager.leavingInfiniteEndLevel = true;
        }
        if(SceneManager.GetActiveScene().name == "CreditsScene") {
            Debug.Log(SceneManager.GetActiveScene().name);
            CreditsSceneManager.leavingCreditsScene = true;
        }
        if(SceneManager.GetActiveScene().name == "15InInfiniteChallengeOver") {
            Debug.Log(SceneManager.GetActiveScene().name);
            InfiniteEndLevelManager.fifteenLeavingInfiniteEndLevel = true;
        }
        if(SceneManager.GetActiveScene().name == "10InInfiniteChallengeOver") {
            Debug.Log(SceneManager.GetActiveScene().name);
            InfiniteEndLevelManager.tenLeavingInfiniteEndLevel = true;
        }
        if(SceneManager.GetActiveScene().name == "5InInfiniteChallengeOver") {
            Debug.Log(SceneManager.GetActiveScene().name);
            InfiniteEndLevelManager.fiveLeavingInfiniteEndLevel = true;
        }
        if(SceneManager.GetActiveScene().name == "DownAndOutChallengeOver") {
            Debug.Log(SceneManager.GetActiveScene().name);
            DownAndOutEndLevelManager.leavingDownAndOutEndLevel = true;
        }
        if(SceneManager.GetActiveScene().name == "LastPointWinsChallengeOver") {
            Debug.Log(SceneManager.GetActiveScene().name);
            LastPointWinsEndLevelManager.leavingLastPointWinsEndLevel = true;
        }
        if(SceneManager.GetActiveScene().name == "ChallengeOptionsMenu") {
            Debug.Log(SceneManager.GetActiveScene().name);
            ChallengeOptionsMenuManager.leavingChallengeOptionsMenuScene = true;
        }
        StartCoroutine(WaitAndLoadRoutine2());
    }

    public void LoadCredits() {
        this.GetComponent<AudioSource>().Play();
        MenuSceneManager.leavingMenuScene = true;
        StartCoroutine(WaitAndLoadRoutine0());
    }

    public void LoadChallengeOptionsMenu() {
        this.GetComponent<AudioSource>().Play();
        if(SceneManager.GetActiveScene().name == "StartMenu") {
            Debug.Log(SceneManager.GetActiveScene().name);
            MenuSceneManager.leavingMenuScene = true;
        }
        if(SceneManager.GetActiveScene().name == "15InInfiniteChallengeOver") {
            Debug.Log(SceneManager.GetActiveScene().name);
            InfiniteEndLevelManager.fifteenLeavingInfiniteEndLevel = true;
        }
        if(SceneManager.GetActiveScene().name == "10InInfiniteChallengeOver") {
            Debug.Log(SceneManager.GetActiveScene().name);
            InfiniteEndLevelManager.tenLeavingInfiniteEndLevel = true;
        }
        if(SceneManager.GetActiveScene().name == "5InInfiniteChallengeOver") {
            Debug.Log(SceneManager.GetActiveScene().name);
            InfiniteEndLevelManager.fiveLeavingInfiniteEndLevel = true;
        }
        if(SceneManager.GetActiveScene().name == "DownAndOutChallengeOver") {
            Debug.Log(SceneManager.GetActiveScene().name);
            DownAndOutEndLevelManager.leavingDownAndOutEndLevel = true;
        }
        if(SceneManager.GetActiveScene().name == "LastPointWinsChallengeOver") {
            Debug.Log(SceneManager.GetActiveScene().name);
            LastPointWinsEndLevelManager.leavingLastPointWinsEndLevel = true;
        }
        StartCoroutine(WaitAndLoadRoutine4());
    }

    public void LoadLastPointWinsChallenge() {
        this.GetComponent<AudioSource>().Play();
        if(SceneManager.GetActiveScene().name == "ChallengeOptionsMenu") {
            Debug.Log(SceneManager.GetActiveScene().name);
            ChallengeOptionsMenuManager.leavingChallengeOptionsMenuScene = true;
        }
        if(SceneManager.GetActiveScene().name == "LastPointWinsChallengeOver") {
            Debug.Log(SceneManager.GetActiveScene().name);
            LastPointWinsEndLevelManager.leavingLastPointWinsEndLevel = true;
        }
        StartCoroutine(WaitAndLoadRoutine9());
    }

    private IEnumerator WaitAndLoadRoutine0() {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("CreditsScene");
    }

    private IEnumerator  WaitAndLoadRoutine1()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("ClassicLevel");
    }

    private IEnumerator  WaitAndLoadRoutine2()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("StartMenu");
    }

    private IEnumerator WaitAndLoadRoutine3() {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("InfiniteLevel");
    }

    private IEnumerator WaitAndLoadRoutine4() {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("ChallengeOptionsMenu");
    }

    private IEnumerator WaitAndLoadRoutine5() {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("5InInfiniteChallenge");
    }

    private IEnumerator WaitAndLoadRoutine6() {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("10InInfiniteChallenge");
    }

    private IEnumerator WaitAndLoadRoutine7() {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("15InInfiniteChallenge");
    }

    private IEnumerator WaitAndLoadRoutine8() {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("DownAndOutChallenge");
    }

    private IEnumerator WaitAndLoadRoutine9() {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("LastPointWinsChallenge");
    }

    private IEnumerator WaitAndLoadRoutine10() {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("AudioControlMenu");
    }
}
