using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC2 : MonoBehaviour
{
	public int speed;
	public Rigidbody rb;
	public int JumpsRemain = 1;
	public float jumpForce;
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
			rb.AddForce(movement);
		}
	}

	public float mouseSensitivity = 100f;

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
	}

	private void RotatePlayerWithMouse()
	{
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		rotationY += mouseX;
		transform.localRotation = Quaternion.Euler(0f, rotationY, 0f);

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			UnlockCursor();
		}
	}

	public void UnlockCursor()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	private void CheckJumpInput()
	{
		if(JumpsRemain > 0 && Input.GetKeyDown(KeyCode.Space)){
			rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
			JumpsRemain -= 1;
			StartCoroutine("RestoreJump");
		}
		if(transform.position.y < -200){
			Gm.RestartGame();
		}
	}

	IEnumerator RestoreJump(){
		yield return new WaitForSeconds(1f);
		JumpsRemain += 1;
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
