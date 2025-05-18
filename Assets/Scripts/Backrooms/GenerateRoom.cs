using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoom : MonoBehaviour
{
	private float X;

	[SerializeField] private GameObject[] rooms;
	
	[SerializeField] private short width;
	[SerializeField] private short height;

	[SerializeField] private short x;
	[SerializeField] private short A;
	[SerializeField] private short C;

	[SerializeField] private Vector2 pos;

	[SerializeField] private Transform player;

	[SerializeField] private GameObject[] vec = new GameObject[64];

	byte LineMethod(){
		x = (short) (x * A + C);
		print(x % 4);
		return (byte) (x % 4);
	}

	GameObject UGenerateRoom(float x, float y) {
		float xCoord = (float)x / (float)width * rooms.Length;// + offsetX; // Координата по X.
	    float yCoord = (float)y / (float)height * rooms.Length;// + offsetY; // Координата по Y.

	    float sample = Mathf.PerlinNoise(xCoord, yCoord);
	    short sampleId = (short) (sample*rooms.Length);
	    	
	    GameObject gm = Instantiate(rooms[sampleId], transform);
	    gm.transform.localPosition = new Vector3(x*10, 0, y*10);
	    gm.transform.eulerAngles = new Vector3(0, LineMethod()*90, 0);
		return gm;
	}

	void Awake(){
		Generate();
	}

	Vector2 GetCoords(){
		short pX1 = (short) Mathf.Floor(player.position.x / 10);
		short pY1 = (short) Mathf.Floor(player.position.z / 10);

		return new Vector2(pX1, pY1);
	}

	void Generate(){
		Vector2 coords = GetCoords();
		Vector2 dt = coords - pos;
		for(short x = 0; x < width; x++){
			for(short y = 0; y < height; y++){
				float posX = x-4;
				float posY = y-4;
				GameObject toArr = UGenerateRoom(posX + coords.x, posY + coords.y);
				vec[y*8 + x] = toArr;
			}
		}

		pos = coords;
	}
}
