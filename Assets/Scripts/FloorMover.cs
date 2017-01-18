using UnityEngine;
using System.Collections;

public class FloorMover : MonoBehaviour {

    public FloorManager floorManager;

    public Vector3 startPosition;
    public Vector3 endPosition;

    private Transform ownTransform;

    private Vector3 direction;
    public float speed;

    // Use this for initialization
    void Awake () {
        ownTransform = gameObject.GetComponent<Transform>();
        floorManager = GameObject.Find("FloorManager").GetComponent<FloorManager>();
	}

    void Start ()
    {
        direction = (endPosition - startPosition).normalized;
        ownTransform.position = startPosition;
    }
	
	// Update is called once per frame
	void Update () {

        if (ownTransform.position.z <= endPosition.z)
        {
            floorManager.FloorDestroyed(ownTransform.position.z - endPosition.z);
            Destroy(gameObject);
        }

        ownTransform.Translate(direction * speed * Time.deltaTime);
    }
}
