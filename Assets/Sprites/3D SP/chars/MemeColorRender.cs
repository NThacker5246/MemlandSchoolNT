using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeColorRender : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
	}
}
