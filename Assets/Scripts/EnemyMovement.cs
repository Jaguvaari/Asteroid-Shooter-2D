using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private float moveSpeed = 1.5f;

    private Vector3 targetWaypoint;

    bool allowShooting = true;

    public GameObject projectilePrefab;

    private GameObject heroShip;

    // Start is called before the first frame update
    void Start()
    {
        heroShip = GameDirector.Instance.GetHeroShip();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckDistance() || targetWaypoint == Vector3.zero)
        {
            targetWaypoint = GetNewTargetWaypoint();
        }

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Checks if the enemy is close enough of the target waypoint to be 'Arrived'.
    /// </summary>
    /// <returns></returns>
    private bool CheckDistance()
    {
        bool retVal = false;

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

    private void Shooting()
    {
        if (allowShooting)
        {
            allowShooting = false;
            Fire();
            StartCoroutine(SlowDownShots());
        }
    }

    private void Fire()
    {
        // Instantiate a projectile from prefab, place it on players position and rotate it to player heading
        GameObject bullet = Instantiate(projectilePrefab, gameObject.transform.position, transform.rotation);
    }

    IEnumerator SlowDownShots()
    {
        float delay = UnityEngine.Random.Range(1f, 5f);
        yield return new WaitForSeconds(delay);
        allowShooting = true;
    }
}
