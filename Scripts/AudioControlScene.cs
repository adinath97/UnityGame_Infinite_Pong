using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControlScene : MonoBehaviour
{
    public static bool leavingAudioControlScene;
    [SerializeField] RawImage fade1;
    [SerializeField] RawImage fade2;
    
    // Start is called before the first frame update
    void Awake()
    {
        fade2.gameObject.SetActive(false);
        fade2.GetComponent<Animation>().enabled = false;
        Destroy(fade1, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(leavingAudioControlScene == true) {
            leavingAudioControlScene = false;
            fade2.gameObject.SetActive(true);
            fade2.GetComponent<Animation>().enabled = true;
            //fade2.GetComponent<Animation>().Play("FadeScreen2");
        }
    }
}
