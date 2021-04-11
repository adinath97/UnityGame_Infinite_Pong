using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLeftPaddle : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Ball") {
            //Debug.Log("HIT!");
        }
        
    }
}
