using UnityEngine;
using System.Collections;

public class ScrollingFloor : MonoBehaviour {

    public FloorManager floorManager;

    public Vector3 startPosition;
    public Vector3 endPosition;

    protected Vector3 direction;

    // Use this for initialization
    protected void Awake () {
        floorManager = GameObject.Find("FloorManager").GetComponent<FloorManager>();
    }

    protected void Start ()
    {
        direction = (endPosition - startPosition).normalized;
        transform.position = startPosition;
    }

    // Update is called once per frame
    protected void Update ()
    {
        transform.position += direction * floorManager.Speed * Time.deltaTime;

        if (transform.position.z <= endPosition.z)
        {
            Destroy(gameObject);
        }
    }

    protected void DestroyThis ()
    {
        Destroy(gameObject);
    }
}
