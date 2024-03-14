using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HT: MonoBehaviour
{
	public string[] Array;
	public int length;

	public int getHash(int key){
		return key;
	}

	public int getHash(string key){
		int i = 0;
		int num = 0;
		while(i < key.Length){
			num = (num << 5) - num + ((byte) ((char) key[i]));
			i += 1;
		}
		return num;
	}

	public int getIndex(int hash){
		return hash % length;
	}

	public void insert(string key, string value1){
		int index = getIndex(getHash(key));
		Array[index] = value1;
	}

	public void insert(int key, string value1){
		int index = getIndex(getHash(key));
		Array[index] = value1;
	}

	public string getElement(string key){
		int index = getIndex(getHash(key));
		return Array[index];
	}

	public string getElement(int key){
		int index = getIndex(getHash(key));
		return Array[index];
	}
	
	public void delete(string key){
		int index = getIndex(getHash(key));
		Array[index] = "";
	}
	
	public void delete(int key){
		int index = getIndex(getHash(key));
		Array[index] = "";
	}

	public void Start(){
		Debug.Log(getHash("thig"));
		insert("Test", "Hi");
		Debug.Log(getElement("Test"));
		delete("Test");
	}
}