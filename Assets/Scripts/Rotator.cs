using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{

    public float speed;
    public Transform objectTransform;
    public Direction directionInput;

    public enum Direction
    {
        up,
        down,
        forward,
        backwards,
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
        switch (directionInput)
        {
            case Direction.up:
                objectTransform.Rotate(Vector3.up * Time.deltaTime * speed, Space.Self);
                break;

            case Direction.down:
                objectTransform.Rotate(Vector3.down * Time.deltaTime * speed, Space.Self);
                break;

            case Direction.forward:
                objectTransform.Rotate(Vector3.forward * Time.deltaTime * speed, Space.Self);
                break;

            case Direction.backwards:
                objectTransform.Rotate(Vector3.back * Time.deltaTime * speed, Space.Self);
                break;

            case Direction.left:
                objectTransform.Rotate(Vector3.left * Time.deltaTime * speed, Space.World);
                break;

            case Direction.right:
                objectTransform.Rotate(Vector3.right * Time.deltaTime * speed, Space.World);
                break;
        }
    }
}