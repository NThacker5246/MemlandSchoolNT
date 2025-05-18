using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUp : MonoBehaviour
{
	public string type;
	public int i;
	public int[] speeds;
	public int[] costs;
	public Text txt;
	public Text cost;

	public PlayerC2 player;
	public Skillset orbs;

	public void SpeedUpgrade(){
		if(orbs.orbs >= costs[i+1]){
			i += 1;
			if(type == "speed"){
				player.Speed(speeds[i]);
			} else if(type == "jumpSt"){
				player.JumpForce((float) speeds[i]);
			} else if(type == "jumps"){
				player.JumpMax = speeds[i];
			}
			txt.text = "" + i;
			orbs.orbs -= costs[i];
			cost.text = "Цена: " + costs[i + 1]; 
		}

	}
}
