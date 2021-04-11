using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsSceneManager : MonoBehaviour
{
    [SerializeField] RawImage fade1;
    [SerializeField] RawImage fade2;
    public static bool leavingCreditsScene;
    
    // Start is called before the first frame update
    void Awake()
    {
        fade2.gameObject.SetActive(false);
        fade2.GetComponent<Animation>().enabled = false;
        Destroy(fade1,1f);
        leavingCreditsScene = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(leavingCreditsScene) {
            leavingCreditsScene = false;
            fade2.gameObject.SetActive(true);
            fade2.GetComponent<Animation>().enabled = true;
        }
    }
}
