using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wandAnim : MonoBehaviour
{
	public Animator anim;

	public void blkAttack()
	{
		anim.SetBool("isAtt", true);
	}
	public void blkDwn()
	{
		anim.SetBool("isAtt", false);
	}
}
