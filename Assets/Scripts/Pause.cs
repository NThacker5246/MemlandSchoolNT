using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	public Animator anim;
	// Start is called before the first frame update
	void Start()
	{
		anim = GetComponent<Animator>();	
	}

	public void pause(){
		anim.SetBool("Menu", true);
	}

	public void resume(){
		anim.SetBool("Menu", false);
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerC2>().LockCursor();
		run();
	}

	public void stop(){
		Time.timeScale = 0f;
	}

	public void run(){
		Time.timeScale = 1f;
	}
}
