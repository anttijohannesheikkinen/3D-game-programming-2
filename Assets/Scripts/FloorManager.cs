﻿using UnityEngine;
using System.Collections;

public class FloorManager : MonoBehaviour {

    public GameObject[] prefabs;
    public GameObject enemyPrefab;

    public Vector3 startPosition;
    public Vector3 endPosition;
    public float minimumSpeed;
    public float maximumSpeed;
    public float speed;
    public float speedIncrement;
    public float delayBetweenSpeedUp;

    public float nextEnemySpawnTime;
    private float enemySpawnTimerStart;

    public int floorTiles;

    private bool initialSpawn;
    private float speedUpPhaseStartTime;

    // Use this for initialization
    void Start () {


        speedUpPhaseStartTime = Time.time;
        speed = minimumSpeed;

        enemySpawnTimerStart = Time.time;
        nextEnemySpawnTime = Random.Range(1.0f, 3.0f);

        float zPos = startPosition.z;
        float floorLength = Mathf.Abs(startPosition.z) + Mathf.Abs(endPosition.z);

        while (zPos > endPosition.z) {
            SpawnFloor(new Vector3(0, 0, zPos), 0);
            zPos -= 5.0f;
        }


    }
	
	// Update is called once per frame
	void Update () {

        if ((Time.time - enemySpawnTimerStart) > nextEnemySpawnTime)
        {
            enemySpawnTimerStart = Time.time;
            nextEnemySpawnTime = Random.Range(1.0f, 3.0f);
            SpawnEnemy();
        }

        if (((Time.time - speedUpPhaseStartTime) > delayBetweenSpeedUp) && (speed < maximumSpeed))
        {
            speed = Mathf.Clamp(speed += speedIncrement, speed, maximumSpeed);

            GameObject[] floorParts = GameObject.FindGameObjectsWithTag("FloorParts");

            foreach (GameObject go in floorParts)
            {
                go.GetComponent<FloorPart>().speed = speed;
            }

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject go in enemies)
            {
                go.GetComponent<EnemyMover>().speed = speed;
            }


            speedUpPhaseStartTime = Time.time;
        }

	}

    public void FloorDestroyed (float offsetZ)
    {
        floorTiles--;

        SpawnFloor(new Vector3(startPosition.x, startPosition.y, startPosition.z + offsetZ), Random.Range(0, prefabs.Length - 1));

    }

    private void SpawnFloor (Vector3 startPos, int prefabIndex)
    {
        floorTiles++;

        GameObject floorTile = Instantiate(prefabs[prefabIndex], startPos, Quaternion.identity);
        FloorPart floorMover = floorTile.GetComponent<FloorPart>();
        floorMover.speed = speed;
        floorMover.startPosition = startPos;
        floorMover.endPosition = endPosition;
    }

    private void SpawnEnemy ()
    {
        GameObject enemy = Instantiate(enemyPrefab, startPosition, Quaternion.identity);
        EnemyMover enemyMover = enemy.GetComponent<EnemyMover>();
        enemyMover.speed = speed;
        enemyMover.startPosition = startPosition + ;
        enemyMover.endPosition = endPosition;
    }
}
