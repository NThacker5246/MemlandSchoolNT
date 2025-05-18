using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC2 : MonoBehaviour
{
	[SerializeField] private float speed;
	[SerializeField] private Rigidbody rb;
	[SerializeField] private float mouseSensitivity = 100f;
	[SerializeField] private Transform other;
	[SerializeField] private float jumpForce;

	public int JumpsRemain = 1;
	public int JumpMax;
	public GameManager Gm;
	
	private float rotationY = 0f;
	
	private void FixedUpdate()
	{
		MovePlayer();
	}

	private void MovePlayer()
	{
		float horizontal = Input.GetAxis("Horizontal") * speed;
		float vertical = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3(horizontal, 0f, vertical);

		if (movement != Vector3.zero)
		{
			movement = Quaternion.Euler(0f, rotationY, 0f) * movement;
			//rb.AddForce(movement);
			rb.linearVelocity = movement;
		}
	}


	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		LockCursor();
		//Gm = GameObject.FindGameObjectWithTag("Respawn").GetComponent<GameManager>();
	}

	public void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void Update()
	{
		RotatePlayerWithMouse();
		CheckJumpInput();
		if(Input.GetKeyDown(KeyCode.L)){
			LockCursor();
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			UnlockCursor();
		}
	}

	private void RotatePlayerWithMouse()
	{
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		rotationY += mouseX;
		transform.localRotation = Quaternion.Euler(0f, rotationY, 0f);
	}

	public void UnlockCursor()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	private void CheckJumpInput()
	{
		if(JumpsRemain > 0 && Input.GetKeyDown(KeyCode.Space)){
			rb.linearVelocity += Vector3.up*jumpForce;
			JumpsRemain -= 1;
		}
		if(transform.position.y < -200){
			Gm.RestartGame();
		}

		if(isGrounded()){
			JumpsRemain = JumpMax;
		}
	}

	public bool isGrounded() {
    	Collider[] colliders = Physics.OverlapSphere(other.position, 0.1f); // Adjust radius as needed
		foreach (Collider collider in colliders) {
			if (collider != this.GetComponent<Collider>()) { // Exclude self-collider
				return true;
			}
		}
		return false;
	}

	public void Speed(float i){
		speed = i;
	}

	public void JumpForce(float i){
		jumpForce = i;
	}
}

	/*
	double factorial(int n){
		if (n == 0 || n == 1) {return 1;}
		double result = 1;
		int i = 0;
		while (i < n){
			result = result * (i + 1);
			i = i + 1;
		}
		return result;

	}

	double exp(double n, int i){
		int c = 0;
		double result = 1;
		while (c < i){
			result = result * n;
			c = c + 1;
		}
		return result;
	}

	double sin(double a){
		double rad = a * 3.1415 / 180;
		double s;
		s = (rad / factorial(1)) - (exp(rad, 3) / factorial(3)) + (exp(rad, 5) / factorial(5)) - (exp(rad, 7) / factorial(7));
		return s;
	}
	*/
