using UnityEngine;
using System.Collections;

public class FloorManager : MonoBehaviour {

    public GameObject[] prefabs;

    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed;
    //public float travelTime;
    public float spawnFrequency = 1.0f;
    public int maxFloorTiles;
    public int floorTiles;


    private float timerStart;



    // Use this for initialization
    void Start () {

        float zPos = startPosition.z;

        float floorLength = Mathf.Abs(startPosition.z) + Mathf.Abs(endPosition.z);


        while (zPos > -floorLength) {
            Spawn(new Vector3(0, 0, zPos), 6);
            zPos -= 5.0f;
        }

    }
	
	// Update is called once per frame
	void Update () {
        //if ((Time.time - timerStart >= spawnFrequency))
        //{
        //    Spawn(startPosition, endPosition);
        //}

	}

    public void FloorDestroyed ()
    {
        floorTiles--;
        Spawn(startPosition, Random.Range(0, prefabs.Length - 1));
        //Instantiate(prefabs[Random.Range(0, prefabs.Length - 1 )]);
    }

    private void Spawn (Vector3 startPos, int prefabIndex)
    {
        timerStart = Time.time;
        floorTiles++;

        GameObject floorTile = Instantiate(prefabs[prefabIndex]);
        FloorMover floorMover = floorTile.GetComponent<FloorMover>();
        //floorMover.floorManager = this;
        //floorMover.duration = travelTime;
        floorMover.speed = speed;
        floorMover.startPosition = startPos;
        floorMover.endPosition = endPosition;
    }
}
