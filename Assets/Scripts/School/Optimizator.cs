using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimizator : MonoBehaviour
{
	[SerializeField] private GameObjMatrix[] location;

	public void SetPosition(byte x, byte y){
		if(location[y-1].row[x-1] != null){
			location[y-1].row[x-1].SetActive(true);
		}
		if(location[y].row[x-1] != null){
			location[y].row[x-1].SetActive(true);
		}

		if(location[y+1].row[x-1] != null){
			location[y+1].row[x-1].SetActive(true);
		}

		if(location[y-1].row[x] != null){
			location[y-1].row[x].SetActive(true);
		}
		if(location[y].row[x] != null){
			location[y].row[x].SetActive(true);
		}

		if(location[y+1].row[x] != null){
			location[y+1].row[x].SetActive(true);
		}


		if(location[y-1].row[x+1] != null){
			location[y-1].row[x+1].SetActive(true);
		}
		if(location[y].row[x+1] != null){
			location[y].row[x+1].SetActive(true);
		}

		if(location[y+1].row[x+1] != null){
			location[y+1].row[x+1].SetActive(true);
		}
		
	}

	public void ClearPosition(byte x, byte y){
		if(location[y-1].row[x-1] != null){
			location[y-1].row[x-1].SetActive(false);
		}
		if(location[y].row[x-1] != null){
			location[y].row[x-1].SetActive(false);
		}

		if(location[y+1].row[x-1] != null){
			location[y+1].row[x-1].SetActive(false);
		}

		if(location[y-1].row[x] != null){
			location[y-1].row[x].SetActive(false);
		}
		if(location[y].row[x] != null){
			location[y].row[x].SetActive(false);
		}

		if(location[y+1].row[x] != null){
			location[y+1].row[x].SetActive(false);
		}


		if(location[y-1].row[x+1] != null){
			location[y-1].row[x+1].SetActive(false);
		}
		if(location[y].row[x+1] != null){
			location[y].row[x+1].SetActive(false);
		}

		if(location[y+1].row[x+1] != null){
			location[y+1].row[x+1].SetActive(false);
		}
		
	}

	
}
