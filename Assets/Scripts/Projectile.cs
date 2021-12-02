using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float moveSpeed = 5f;
    public LayerMask collisionLayers;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DieAfterTime());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision collision)
    {

        if (collision.gameObject.layer == 8)
        {
            Destroy(collision.gameObject);
        }
    }

    /// <summary>
    /// Coroutine for destroying the projectile after set time, so it is easy to get rid of the instances.
    /// </summary>
    /// <returns></returns>
    IEnumerator DieAfterTime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
