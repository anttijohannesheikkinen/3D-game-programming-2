using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{

    public float speed;
    public Transform objectTransform;
    public Direction direction;

    public enum Direction
    {
        left,
        right
    }

    // Use this for initialization
    void Awake()
    {
        objectTransform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (direction)
        {
            case Direction.left:
                objectTransform.Rotate(Vector3.down * Time.deltaTime * speed, Space.World);
                break;

            case Direction.right:
                objectTransform.Rotate(Vector3.up * Time.deltaTime * speed, Space.World);
                break;
        }
    }
}