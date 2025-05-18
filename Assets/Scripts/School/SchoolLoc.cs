using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolLoc : MonoBehaviour
{
	[SerializeField] private byte x;
	[SerializeField] private byte y;
	[SerializeField] private Optimizator school;

	void OnTriggerEnter(){
		school.SetPosition(x, y);

		school.ClearPosition((byte)(x-2), (byte)(y-2));
		school.ClearPosition((byte)(x+2), (byte)(y-2));
		school.ClearPosition((byte)(x-2), (byte)(y+2));
		school.ClearPosition((byte)(x+2), (byte)(y+2));

		school.SetPosition(x, y);
	}

}