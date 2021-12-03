using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public static GameDirector Instance;
    public GameObject HeroShip;
    public GameObject SpawnPointPrefab;
    public int Score = 0;
    private bool allowSpawn = true;

    public Text scoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Manage spawn points
        if (allowSpawn)
        {
            allowSpawn = false;
            CreateSpawnPoint();
            StartCoroutine(WaitBetweenSpawn());
        }

        //scoreText
        scoreText.text = "Score " + Score.ToString();
    }

    private void CreateSpawnPoint()
    {
        Vector3 newSpawnLocation = new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-8f, 8f), 0f);
        GameObject newSpawn = Instantiate(SpawnPointPrefab, newSpawnLocation, Quaternion.identity);
    }

    IEnumerator WaitBetweenSpawn()
    {
        float delay = UnityEngine.Random.Range(1f, 5f);
        yield return new WaitForSeconds(delay);
        allowSpawn = true;
    }

    public GameObject GetHeroShip()
    {
        return this.HeroShip;
    }
}
