using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    public CharacterController characterController;
    public float movementSpeed;
    public float jumpUpSpeed = 2;
    public float gravity = -1;

    private float angleInDegrees;
    private float angleInRadians;
    private float moveY = 1;

    private Vector3 movement = Vector3.zero;


    void Awake ()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float inputX = Input.GetAxisRaw("Horizontal");

        if (characterController.isGrounded && Input.GetButton("Jump"))
        {
            moveY = jumpUpSpeed;
        }

        moveY -= gravity * Time.deltaTime;

        movement = new Vector3(inputX * movementSpeed, moveY , 0) * Time.deltaTime;
        characterController.Move(movement);

    }
}
