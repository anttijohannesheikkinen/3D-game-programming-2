using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    public CharacterController characterController;
    public float movementSpeed;
    public float jumpHeight = 2;
    public float jumpUpSpeed = 2;
    public float jumpDownSpeed = 1;

    private float angleInDegrees;
    private float angleInRadians;
    private float posY = 1;

    private bool jumping;

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

        if (!jumping && characterController.isGrounded && Input.GetButton("Jump"))
        {

            jumping = true;
            angleInDegrees = 0;
        }

        if (jumping)
        {
            if (angleInDegrees <= 90)
            {
                angleInDegrees = angleInDegrees + Time.deltaTime * jumpUpSpeed * jumpHeight;
            }

            else
            {
                angleInDegrees = angleInDegrees + Time.deltaTime * jumpDownSpeed * jumpHeight;
            }

            angleInRadians = angleInDegrees * Mathf.Deg2Rad;
            posY = Mathf.Cos(angleInRadians);
        }

        else
        {
            posY = -1;
        }

        if (angleInDegrees > 180)
        {
            jumping = false;
        }

        Vector3 movement = new Vector3(inputX * Time.deltaTime * movementSpeed, posY, 0);
        characterController.Move(movement);

    }
}
