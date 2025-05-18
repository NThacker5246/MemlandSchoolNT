using UnityEngine;

public class LadderMovement : MonoBehaviour
{    
	[SerializeField] private byte climbSpeed = 2;
	[SerializeField] private bool inColl;    
	[SerializeField] private Rigidbody player;
	[SerializeField] private Vector3 vector;
	//[SerializeField] private float ct = 270;

	private void OnTriggerEnter(Collider other)
	{     
		if(other.tag == "Player"){
			inColl = true;
			player = other.GetComponent<Rigidbody>();
		}  
	}

	private void OnTriggerExit(Collider other)
	{     
		if(other.tag == "Player"){
			inColl = false;
			player = other.GetComponent<Rigidbody>();
		}  
	}

	void Update(){
		/*
		if(inColl){
			float verticalInput = Input.GetAxis("Vertical");
			float rY = player.transform.eulerAngles.y;
			Vector3 climbVelocity;
			if(rY >= 180){
				climbVelocity = Quaternion.Euler(new Vector3(360, 360, 360) - vector) * new Vector3(0f, verticalInput * climbSpeed, 0f);
			} else {
				climbVelocity = Quaternion.Euler(vector) * new Vector3(0f, verticalInput * climbSpeed, 0f);
			}
			player.GetComponent<Rigidbody>().velocity = climbVelocity;
		}
		*/
		if(inColl){
			float verticalInput = Input.GetAxis("Vertical") * climbSpeed;
			float rY = player.transform.eulerAngles.y;
			
			

			Vector3 climbVelocity;
			climbVelocity = Quaternion.Euler(new Vector3(360, 360, 360) - vector) * new Vector3(0, verticalInput, 0);

			player.linearVelocity = climbVelocity;
		}
	}
}
