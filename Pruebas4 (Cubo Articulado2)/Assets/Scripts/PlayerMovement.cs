using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController controller;
	public float speed = -12f;
	public int rotationSpeed;

	// Update is called once per frame
	void Update()
	{
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * z + transform.forward * (-x);

		controller.Move(move * speed * Time.deltaTime);

		if (Input.GetKey("q"))
		{
			transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
		}

		if (Input.GetKey("e"))
		{
			transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
		}


	}
}
