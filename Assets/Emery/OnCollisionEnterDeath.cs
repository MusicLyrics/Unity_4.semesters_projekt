using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnterDeath : MonoBehaviour
{
    //Used to specify the tag of the object that can trigger the collision
    public string targetTag;
    public Enemy enemy;


    private void OnCollisionEnter(Collision collision)
    {
        //If the collision's game object has the same tag as the targetTag variable.
        if (collision.gameObject.tag == targetTag)
        {
            //If the tag matches, calls the Dead() function, from the enemy component. Passes the point of contact between the two colliding objects.
            enemy.Dead(collision.contacts[0].point);
        }
    }
}
