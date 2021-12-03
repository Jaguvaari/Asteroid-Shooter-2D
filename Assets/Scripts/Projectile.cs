using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Projectile : MonoBehaviour
{
    private float moveSpeed = 5f;

    public AudioClip explosionClip;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy enemies that enter the trigger area
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit");
            AudioSource.PlayClipAtPoint(explosionClip, transform.position);
            Destroy(collision.gameObject); // Destroy the enemy
            Destroy(gameObject); // Destroy the projectile to prevent it from plowing through many enemies
            GameDirector.Instance.Score += 50; // Add points for the kill
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
