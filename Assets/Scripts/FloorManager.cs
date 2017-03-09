using UnityEngine;
using System.Collections;

// TODO : Refactor this shit.

public class FloorManager : MonoBehaviour {

    public float Speed { get; private set; }
    public GameObject LastFLoorTile { get; private set; }
    public GameObject PreviousFloorTile { get; private set; }

    public GameObject[] prefabs;
    public GameObject enemyPrefab;
    public GameObject coinPrefab;

    public Vector3 startPosition;
    public Vector3 endPosition;
    public float minimumSpeed;
    public float maximumSpeed;
    public float speedIncrement;
    public float delayBetweenSpeedUp;

    public float nextEnemySpawnTime;
    private float enemySpawnTimerStart;

    public float nextCoinSpawnTime;
    private float coinSpawnTimerStart;
    public float floorLength = 5.0f;

    public int floorTiles;

    private bool initialSpawn;
    private float speedUpPhaseStartTime;

    public bool initial;

    private GameObject lastSpawned;

    // Use this for initialization
    void Start () {


        speedUpPhaseStartTime = Time.time;
        Speed = minimumSpeed;

        enemySpawnTimerStart = Time.time;
        nextEnemySpawnTime = Random.Range(1.0f, 3.0f);

        coinSpawnTimerStart = Time.time;
        nextCoinSpawnTime = Random.Range(0.5f, 5.0f);
        float floorLength = Mathf.Abs(startPosition.z) + Mathf.Abs(endPosition.z);

        initial = true;

        float zPos = endPosition.z;

        while (zPos < startPosition.z) {
            SpawnFloor(new Vector3(0, 0, zPos), 0);
            zPos += 5.0f;
        }

        initial = false;
    }
	
	// Update is called once per frame
	void Update () {

        if ((Time.time - enemySpawnTimerStart) > nextEnemySpawnTime)
        {
            enemySpawnTimerStart = Time.time;
            nextEnemySpawnTime = Random.Range(1.0f, 3.0f);
            SpawnEnemy();
        }

        if (((Time.time - speedUpPhaseStartTime) > delayBetweenSpeedUp) && (Speed < maximumSpeed))
        {
            Speed = Mathf.Clamp(Speed += speedIncrement, Speed, maximumSpeed);
            speedUpPhaseStartTime = Time.time;
        }

	}

    private void FixedUpdate ()
    {
        if ((Time.time - coinSpawnTimerStart) > nextCoinSpawnTime)
        {
            AttemptToSpawnCoins();
        }
    }

    public void FloorDestroyed ()
    {
        floorTiles--;

        SpawnFloor(new Vector3(LastFLoorTile.transform.position.x, 
                               LastFLoorTile.transform.position.y, 
                               LastFLoorTile.transform.position.z + floorLength),
                               Random.Range(0, prefabs.Length));
    }


    private void SpawnFloor (Vector3 startPos, int prefabIndex)
    {

        floorTiles++;
        PreviousFloorTile = LastFLoorTile;
        GameObject floorTile = Instantiate(prefabs[prefabIndex], startPos, Quaternion.identity);
        FloorPart floorMover = floorTile.GetComponent<FloorPart>();
        floorMover.startPosition = startPos;
        floorMover.endPosition = endPosition;

        LastFLoorTile = floorTile;

        if (initial)
        {
            floorMover.initial = true;
        }

        else
        {
            floorMover.initial = false;
        }
    }

    private void SpawnEnemy ()
    {
        GameObject enemy = Instantiate(enemyPrefab, startPosition, Quaternion.identity);
        EnemyMover enemyMover = enemy.GetComponent<EnemyMover>();
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

    private void AttemptToSpawnCoins()
    {



        float xPosition = startPosition.x + 2.0f;

        Vector3[] validPositions = new Vector3[5];
        int validPositionCount = 0;

        while (xPosition >= -2.0f)
        {

            Vector3 drawRayStart = new Vector3(xPosition, startPosition.y + 2, startPosition.z);

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
            SpawnCoin(validPositions[Random.Range(0, validPositionCount)]);
        }

    }

    private void SpawnCoin (Vector3 startPos)
    {
        coinSpawnTimerStart = Time.time;
        nextCoinSpawnTime = Random.Range(1.5f, 5.0f);

        GameObject coin = Instantiate(coinPrefab, startPos, Quaternion.identity);
        ScrollingFloor coinMover = coin.GetComponent<ScrollingFloor>();

        coinMover.startPosition = startPos;
        coinMover.endPosition = startPos + new Vector3(0, 0, - 40);

    }
}
