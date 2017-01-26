using UnityEngine;
using System.Collections;

public class FloorManager : MonoBehaviour {

    public GameObject[] prefabs;
    public GameObject enemyPrefab;
    public GameObject coinPrefab;

    public Vector3 startPosition;
    public Vector3 endPosition;
    public float minimumSpeed;
    public float maximumSpeed;
    public float speed;
    public float speedIncrement;
    public float delayBetweenSpeedUp;

    public float nextEnemySpawnTime;
    private float enemySpawnTimerStart;

    public float nextCoinSpawnTime;
    private float coinSpawnTimerStart;

    public int floorTiles;

    private bool initialSpawn;
    private float speedUpPhaseStartTime;

    private GameObject lastSpawned;

    // Use this for initialization
    void Start () {


        speedUpPhaseStartTime = Time.time;
        speed = minimumSpeed;

        enemySpawnTimerStart = Time.time;
        nextEnemySpawnTime = Random.Range(1.0f, 3.0f);

        coinSpawnTimerStart = Time.time;
        nextCoinSpawnTime = Random.Range(0.5f, 5.0f);

        float zPos = endPosition.z;
        float floorLength = Mathf.Abs(startPosition.z) + Mathf.Abs(endPosition.z);

        while (zPos < startPosition.z) {
            SpawnFloor(new Vector3(0, 0, zPos), 0);
            zPos += 5.0f;
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

            GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

            foreach (GameObject go in coins)
            {
                go.GetComponent<ScrollingFloor>().speed = speed;
            }

            speedUpPhaseStartTime = Time.time;
        }

	}

    public void FloorDestroyed (float offsetZ)
    {
        floorTiles--;

        SpawnFloor(new Vector3(startPosition.x, startPosition.y, startPosition.z + offsetZ), Random.Range(0, prefabs.Length - 1));

        if ((Time.time - coinSpawnTimerStart) > nextCoinSpawnTime)
        {

            nextCoinSpawnTime = Random.Range(0.5f, 5.0f);
            DrawRaysForCoinSpawnPositions();
        }
    }


    private void SpawnFloor (Vector3 startPos, int prefabIndex)
    {

        floorTiles++;

        GameObject floorTile = Instantiate(prefabs[prefabIndex], startPos, Quaternion.identity);
        FloorPart floorMover = floorTile.GetComponent<FloorPart>();
        floorMover.speed = speed;
        floorMover.startPosition = startPos;
        floorMover.endPosition = endPosition;

        lastSpawned = floorTile;

        DrawRaysForCoinSpawnPositions();

    }

    private void SpawnEnemy ()
    {
        GameObject enemy = Instantiate(enemyPrefab, startPosition, Quaternion.identity);
        EnemyMover enemyMover = enemy.GetComponent<EnemyMover>();
        enemyMover.speed = speed;
        enemyMover.startPosition = startPosition + new Vector3(0, 2, 0);
        enemyMover.endPosition = endPosition + new Vector3(0, 2, 0);

        int random = Random.Range(0, 2);

        if (random == 0)
        {
            enemyMover.fromLeftToRight = true;
        }

        else
        {
            enemyMover.fromLeftToRight = false;
        }
    }

    private void DrawRaysForCoinSpawnPositions()
    {



        float xPosition = startPosition.x + 2.0f;

        Vector3[] validPositions = new Vector3[5];
        int validPositionCount = 0;

        while (xPosition >= -2.0f)
        {

            Vector3 drawRayStart = new Vector3(xPosition, startPosition.y + 2, startPosition.z);

            Debug.Log(drawRayStart);

            RaycastHit hit;

            if (Physics.Raycast(drawRayStart, Vector3.down, out hit, 8.0f))
            {
                validPositions[validPositionCount] = drawRayStart;
                validPositionCount++;
                Debug.DrawLine(drawRayStart, drawRayStart + Vector3.down * 3, Color.blue, 1.0f);
            }

            else
            {
                Debug.DrawLine(drawRayStart, drawRayStart + Vector3.down * 3, Color.red, 1.0f);
            }

            xPosition -= 1.0f;

        }

        if (validPositionCount > 0)
        {
            SpawnCoin(validPositions[Random.Range(0, validPositionCount - 1)]);
        }

    }

    private void SpawnCoin (Vector3 startPos)
    {
        coinSpawnTimerStart = Time.time;

        GameObject coin = Instantiate(coinPrefab, startPos, Quaternion.identity);
        ScrollingFloor coinMover = coin.GetComponent<ScrollingFloor>();
        coinMover.speed = speed;

        coinMover.startPosition = startPos;
        coinMover.endPosition = startPos + new Vector3(0, 0, - 40);


    }
}
