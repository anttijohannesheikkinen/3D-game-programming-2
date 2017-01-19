using UnityEngine;
using System.Collections;

public class FloorManager : MonoBehaviour {

    public GameObject[] prefabs;

    public Vector3 startPosition;
    public Vector3 endPosition;
    public float minimumSpeed;
    public float maximumSpeed;
    public float speed;
    public float speedIncrement;
    public float delayBetweenSpeedUp;

    public int floorTiles;

    private bool initialSpawn;
    private float speedUpPhaseStartTime;

    // Use this for initialization
    void Start () {


        speedUpPhaseStartTime = Time.time;
        speed = minimumSpeed;

        float zPos = startPosition.z;
        float floorLength = Mathf.Abs(startPosition.z) + Mathf.Abs(endPosition.z);

        while (zPos > endPosition.z) {
            Spawn(new Vector3(0, 0, zPos), 0);
            zPos -= 5.0f;
        }


    }
	
	// Update is called once per frame
	void Update () {

        if (((Time.time - speedUpPhaseStartTime) > delayBetweenSpeedUp) && (speed < maximumSpeed))
        {

            speed += speedIncrement;


            GameObject[] floorParts = GameObject.FindGameObjectsWithTag("FloorParts");

            foreach (GameObject go in floorParts)
            {
                go.GetComponent<FloorMover>().speed = speed;
            }

            speedUpPhaseStartTime = Time.time;
        }

	}

    public void FloorDestroyed (float offsetZ)
    {
        floorTiles--;

        Spawn(new Vector3(startPosition.x, startPosition.y, startPosition.z + offsetZ), Random.Range(0, prefabs.Length - 1));

    }

    private void Spawn (Vector3 startPos, int prefabIndex)
    {
        floorTiles++;

        GameObject floorTile = Instantiate(prefabs[prefabIndex], startPos, Quaternion.identity);
        FloorMover floorMover = floorTile.GetComponent<FloorMover>();
        floorMover.speed = speed;
        floorMover.startPosition = startPos;
        floorMover.endPosition = endPosition;
    }
}
