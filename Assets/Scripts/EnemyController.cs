using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movementSpeed = 6f;

    Rigidbody rb;
    Camera viewCamera;
    Vector3 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y)); // convert on screen mouse pos to coordinate.
		transform.LookAt(mousePos + Vector3.up * transform.position.y); // point enemy in dir of mouse pos.
		velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * movementSpeed; // movement obtained by WASD.
	}

	void FixedUpdate()
	{
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime); // move player in dir facing by velocity.
	}
}
