using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSceneManager : MonoBehaviour
{
    public static bool leavingMenuScene;
    [SerializeField] RawImage fade2;
    [SerializeField] RawImage fade1;

    void Awake()
    {
        leavingMenuScene = false;
        fade2.gameObject.SetActive(false);
        fade2.GetComponent<Animation>().enabled = false;
        Destroy(fade1,1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(leavingMenuScene == true) {
            leavingMenuScene = false;
            fade2.gameObject.SetActive(true);
            fade2.GetComponent<Animation>().enabled = true;
            //fade2.GetComponent<Animation>().Play("FadeScreen2");
        }
    }
}
