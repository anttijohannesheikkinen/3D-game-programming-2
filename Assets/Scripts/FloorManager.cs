using UnityEngine;
using System.Collections;

public class FloorManager : MonoBehaviour {

    public GameObject[] prefabs;

    public Vector3 startPosition;
    public Vector3 endPosition;

    public float travelTime;

    //public float spawnFrequency = 1.0f;

	// Use this for initialization
	void Start () {
        Spawn();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void FloorDestroyed ()
    {
        Instantiate(prefabs[Random.Range(0, prefabs.Length - 1 )]);
    }

    private void Spawn ()
    {
        GameObject floorTile = Instantiate(prefabs[Random.Range(0, prefabs.Length - 1)]);
        FloorMover floorMover = floorTile.GetComponent<FloorMover>();
        floorMover.floorManager = this;
        floorMover.duration = travelTime;
        floorMover.startPosition = startPosition;
        floorMover.endPosition = endPosition;
    }
}
