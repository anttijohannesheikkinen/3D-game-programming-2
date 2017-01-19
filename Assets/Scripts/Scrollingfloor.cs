using UnityEngine;
using System.Collections;

public class ScrollingFloor : MonoBehaviour {

    public FloorManager floorManager;

    public Vector3 startPosition;
    public Vector3 endPosition;

    protected Transform ownTransform;

    protected Vector3 direction;
    public float speed;

    // Use this for initialization
    private void Awake () {
        OnAwake();
	}

    protected void OnAwake ()
    {
        ownTransform = gameObject.GetComponent<Transform>();
        floorManager = GameObject.Find("FloorManager").GetComponent<FloorManager>();
    }

    private void Start ()
    {
        OnStart();
    }

    protected void OnStart()
    {
        direction = (endPosition - startPosition).normalized;
        ownTransform.position = startPosition;
    }

    // Update is called once per frame
    private void Update ()
    {

    }

    protected void OnUpdate()
    {

    }
}
