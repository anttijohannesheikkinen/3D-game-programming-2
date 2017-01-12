using UnityEngine;
using System.Collections;

public class FloorManager : MonoBehaviour {

    public GameObject[] prefabs;

    public Vector3 startPosition;
    public Vector3 endPosition;
    public float travelTime;
    public float spawnFrequency = 1.0f;
    //public int maxFloorTiles;
    public int floorTiles;

    private float timerStart;



    // Use this for initialization
    void Start () {
        Spawn(Vector3.zero, new Vector3(0, 0, -10));
	}
	
	// Update is called once per frame
	void Update () {
        if ((Time.time - timerStart >= spawnFrequency))
        {
            Spawn(startPosition, endPosition);
        }
	}

    public void FloorDestroyed ()
    {
        floorTiles--;
        //Instantiate(prefabs[Random.Range(0, prefabs.Length - 1 )]);
    }

    private void Spawn (Vector3 startPos, Vector3 endPos)
    {
        timerStart = Time.time;
        floorTiles++;

        GameObject floorTile = Instantiate(prefabs[Random.Range(0, prefabs.Length - 1)]);
        FloorMover floorMover = floorTile.GetComponent<FloorMover>();
        //floorMover.floorManager = this;
        floorMover.duration = travelTime;
        floorMover.startPosition = startPos;
        floorMover.endPosition = endPos;
    }
}
