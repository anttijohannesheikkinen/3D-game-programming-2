using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    public CharacterController characterController;
    public float movementSpeed;
    public float jumpHeight = 2;
    public float jumpUpSpeed = 2;
    public float fallSpeed = -1;
    public float jumpTravelled;

    private float angleInDegrees;
    private float angleInRadians;
    private float moveY = 1;

    private bool jumpingUp = false;

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

        if (!jumpingUp && characterController.isGrounded && Input.GetButton("Jump"))
        {

            jumpingUp = true;
            jumpTravelled = 0;
        }


        if (jumpingUp)
        {
            if (jumpTravelled <= jumpHeight)
            {
                moveY = Time.deltaTime * jumpUpSpeed;
                jumpTravelled += moveY;
            }

            else
            {
                jumpingUp = false;
            }
        }

        else
        {
            moveY = Time.deltaTime * (0 - fallSpeed);
        }

        Vector3 movement = new Vector3(inputX * Time.deltaTime * movementSpeed, moveY , 0);
        characterController.Move(movement);

    }
}
