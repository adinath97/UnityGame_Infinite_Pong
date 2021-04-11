using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantVelocity : MonoBehaviour
{
    //These are just to give the rigidbody an initial velocity
    private float randomX;
    private float randomY;
    float hitTracker, hitAmount;
 
    private Rigidbody2D rb;
 
    private void Awake()
    {
        //Randomize the initial velocity
        randomX = Random.Range(1f, 5f);
        randomY = Random.Range(1f, 5f);
        hitAmount = 0;

        hitTracker = Random.Range(200f,400f);

        //Get a reference to our Rigidbody2D component, set it's body type to Kinematic      
        //UseFullKinematicContacts means this will still register collisions with the Physics2D system
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        rb.useFullKinematicContacts = true;
 
        //Set the initial velocity of the Rigidbody
        rb.velocity = new Vector2(randomX, randomY);
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //When we register a collision, we're going to get the first point of collision
        //Then we just reflect our rigidbody about the contact normal, maintaining velocity
        ContactPoint2D hit = collision.GetContact(0);
        if(hit.otherCollider.gameObject.tag == "playerLeftPart") {
            Debug.Log("LEFT");
        }
        else if(hit.otherCollider.tag == "playerMiddlePart") {
            Debug.Log("MIDDLE");
        }
        else if(hit.otherCollider.tag == "playerRightPart") {
            Debug.Log("RIGHT");
        }
        rb.velocity = Vector2.Reflect(rb.velocity, hit.normal);

        hitAmount++;
        if(hitAmount >= hitTracker) {
            //have 4 cases and add to velocity. need to first determine how much to add (do the math later)
        }
    }
 
    private void FixedUpdate()
    {
        //Logging the velocity magnitude will show us the speed not changing
        //Note, you may see tiny tiny changes due to floating point precision
        //Debug.Log(rb.velocity.magnitude.ToString());
    }
}
