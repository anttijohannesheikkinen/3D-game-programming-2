using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    public CharacterController characterController;
    public float movementSpeed;

    void Awake ()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float inputX = Input.GetAxis("Horizontal");

        Debug.Log(inputX);

	}
}
