using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody enemyPhysics;

    /// <summary>
    /// Boolean which traces when the enemy needs a new waypoint
    /// </summary>
    private bool HasArrived = true;

    private float moveSpeed = 1.5f;

    private Vector3 targetWaypoint;

    public float currentVelocity;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        enemyPhysics = GetComponent<Rigidbody>();

        if (enemyPhysics == null)
        {
            Debug.Log("Enemy is missing physics!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckDistance() || targetWaypoint == Vector3.zero)
        {
            targetWaypoint = GetNewTargetWaypoint();
            Debug.Log("New XXXXXXXXXXwaypoint taken");
        }

        /// Ei n‰‰ heelvetin fysiikat vaan pelaa
        //if (enemyPhysics.velocity.magnitude < moveSpeed)
        //{
        //    enemyPhysics.AddForce(Vector3.MoveTowards(targetWaypoint,  transform.position,  moveSpeed * Time.deltaTime));
        //}

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Checks if the enemy is close enough of the target waypoint to be 'Arrived'.
    /// </summary>
    /// <returns></returns>
    private bool CheckDistance()
    {
        bool retVal = false;
        this.distance = (transform.position - targetWaypoint).magnitude;

        if ((transform.position - targetWaypoint).magnitude < 0.1f)
        {
            this.targetWaypoint = Vector3.zero;
            retVal = true;
        }

        return retVal;
    }

    private Vector3 GetNewTargetWaypoint()
    {
        Vector3 retWaypoint = new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-8f, 8f), 0f);
        return retWaypoint;
    }
}
