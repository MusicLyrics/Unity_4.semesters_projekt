using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Reference to an OnCollisionEnterDeath component attached to the collided object
        OnCollisionEnterDeath death = other.GetComponent<OnCollisionEnterDeath>();

        //If the Dead() component exists.
        if (death != null)
        {
            //Passing the position of the current game object for the Enemy component
            death.enemy.Dead(transform.position);
        }
    }
}
