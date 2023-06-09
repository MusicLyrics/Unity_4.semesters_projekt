using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    public Transform playerTarget;
    public Transform playerHead;
    public float stopDistance = 5;
    public FireBulletOnActivate gun;

    // private Quaternion localRotationGun;

    // Start is called before the first frame update
    void Start()
    {
        SetupRagdoll();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        //localRotationGun = gun.spawnPoint.localRotation;
    }

    // Update is called once per frame
    void Update()
    {

        //AI agent's destination move to a player target's position,
        //if the agent gets close enough to the target (within the stopDistance range),
        //Stops moving and triggers a shooting animation.
        agent.SetDestination(playerTarget.position);

        float distance = Vector3.Distance(playerTarget.position, transform.position);
        if (distance < stopDistance)
        {
            agent.isStopped = true;
            animator.SetBool("Shoot", true);
        }
    }

    //Option for grab the enemys weapon
    //public void ThrowGun()
    //{
    //    gun.spawnPoint.localRotation = localRotationGun;
    //    gun.transform.parent = null;
    //    Rigidbody rb = gun.GetComponent<Rigidbody>();
    //    rb.velocity = BallisticVelocityVector(gun.transform.position, playerHead.position, 45);
    //    rb.angularVelocity = Vector3.zero;
    //}

    //Vector3 BallisticVelocityVector(Vector3 source, Vector3 target, float angle)
    //{
    //    Vector3 direction = target - source;
    //    float h = direction.y;
    //    direction.y = 0;
    //    float distance = direction.magnitude;
    //    float a = angle * Mathf.Deg2Rad;
    //    direction.y = distance * Mathf.Tan(a);
    //    distance += h / Mathf.Tan(a);

    //    // calculate velocity
    //    float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * a));
    //    return velocity * direction.normalized;
    //}


    // generates a random position around the player's head and orients the gun towards that position and fires a bullet.
    public void ShootEnemy()
    {
        Vector3 playerHeadPosition = playerHead.position - Random.Range(0, 0.4f) * Vector3.up;

        gun.spawnPoint.forward = (playerHeadPosition - gun.spawnPoint.position).normalized;

        gun.FireBullet();
    }


    //function sets all the Rigidbody components in the game object's children to kinematic.
    public void SetupRagdoll()
    {
        foreach (var item in GetComponentsInChildren<Rigidbody>())
        {
            item.isKinematic = true;
        }
    }


    //Makes all the Rigidbody components in the game object's children non-kinematic and applies an explosion force to them.
    //It also disables the animator, agent, and the script itself.
    public void Dead(Vector3 hitPosition)
    {
        foreach(var item in GetComponentsInChildren<Rigidbody>())
        {
            item.isKinematic = false;
        }

        foreach(var item in Physics.OverlapSphere(hitPosition, 0.3f))
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(1000, hitPosition, 0.3f);
            }
        }

        //ThrowGun();
        //disables the animator, agent, and the script itself.
        animator.enabled = false;
        agent.enabled = false;
        this.enabled = false;
    }
}
