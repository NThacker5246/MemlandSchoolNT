using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 5f;
	public float jumpForce = 10f;
	private Rigidbody rb;
	private Animator anim;
	public bool isGrounded;
	public VectorValue pos;
	public float rot = 10f;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		transform.position = pos.initalValue;
	}
	private void FixedUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal");
		transform.eulerAngles = new Vector3(0f, ((horizontal * rot)+transform.eulerAngles.y), 0f);
		float vertical = Input.GetAxis("Vertical")*moveSpeed;
		Vector3 movement = new Vector3((vertical * (transform.eulerAngles.y % moveSpeed)), 0f, vertical);
		if (transform.eulerAngles.y == 180 || transform.eulerAngles.y == -180){
			movement.z = -movement.z;
		}
		rb.AddForce(movement);
	}

	private void Update(){
		//isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

		if(isGrounded == true && Input.GetKeyDown(KeyCode.Space)){
			rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
		}

	}
	public void SpeedForc(float speed)
	{
		moveSpeed = moveSpeed + speed;
	}

	public void JumpForc(float jump)
	{
		jumpForce = jumpForce + jump;
	}
}