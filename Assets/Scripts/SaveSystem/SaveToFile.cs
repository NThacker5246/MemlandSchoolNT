using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SaveToFile : MonoBehaviour
{
	public Transform player;
	public GameObject[] items;
	public int level;
	public Transform spawn;
	public GameObject[] its;
	public Button1 btn;
	public MemeAIController Trollface;

	void Start(){
		try {
			ReadState();
		} catch (Exception e) {
			Debug.Log($"Файла нет или {e.ToString()}");
		}
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.I)){
			CreateState();
		}
		try {
			Check();
		} catch (Exception e){
			Debug.Log(e.ToString());
			return;
		}
	}

	public void Check(){
		GameObject[] newItems = new GameObject[its.Length-1];
		int i = 0;
		foreach(GameObject gm in its){
			if(gm != null){
				newItems[i] = gm;
				i += 1;
			}
		}

		its = newItems;
	}

	public void AddItem(GameObject gm){
		GameObject[] temp = its;
		its = new GameObject[temp.Length + 1];
		int i = 0;
		foreach(GameObject t in temp){
			its[i] = t;
			i += 1;
		}
		its[its.Length - 1] = gm;
	}

	public void StartGame(){
		string json = ReadNewTextFile("TEMP.json", "./Saves");
		Data newData = JsonUtility.FromJson<Data>(json);
		SceneManager.LoadScene(newData.level);
	}

	public void CreateState(){
		Vector3 position = player.position;
		Inventory inv = player.GetComponent<Inventory>();
		int[] ids = new int[7];
		int i = 0;
		foreach(GameObject slot in inv.slots){
			Transform slt = slot.transform;
			bool flag = false;
			foreach(Transform child in slt){
				Spawn item = child.GetComponent<Spawn>();
				ids[i] = item.id;
				flag = true;
			}
			if(!flag){
				ids[i] = -1;
			}
			i += 1;
		}
		ItemN[] itemInM = new ItemN[its.Length];
		i = 0;
		foreach(GameObject it in its){
			ItemN m = new ItemN(it.transform.position, it.GetComponent<Pickup>().id); 
			itemInM[i] = m;
			i += 1;
		}
		string[] write = new string[its.Length];
		i = 0;
		foreach(ItemN it in itemInM){
			string toWr = JsonUtility.ToJson(it);
			write[i] = toWr;
			Debug.Log(toWr);
			i += 1;
		}

		int s = Trollface.MovementAI.i;
		int dialog = Trollface.dm.i;

		try {
			Data oldData = JsonUtility.FromJson<Data>(ReadNewTextFile("TEMP.json", "./saves"));
			if(level == 0){
				Data newData = new Data(position, ids, level, write, oldData.itemInB, btn.isDid, s, dialog); //инициализация объекта
				string json = JsonUtility.ToJson(newData);
				CreateNewTextFile(json, "TEMP.json", "./Saves");
			} else if(level == 1){
				Data newData = new Data(position, ids, level, oldData.itemInM, write, oldData.isOpPor, s, dialog); //инициализация объекта
				string json = JsonUtility.ToJson(newData);
				CreateNewTextFile(json, "TEMP.json", "./Saves");
			}
		} catch (Exception e){
			Data newData = new Data(position, ids, level, write, new string[1], false, s, dialog); //инициализация объекта
			string json = JsonUtility.ToJson(newData);
			CreateNewTextFile(json, "TEMP.json", "./Saves");
			Debug.Log(e.ToString());
		}

	}

	public void ReadState(){
		string json = ReadNewTextFile("TEMP.json", "./Saves");
		Data newData = JsonUtility.FromJson<Data>(json);
		player.position = newData.position;
		int i = 0;
		Inventory inv = player.GetComponent<Inventory>();
		foreach(int id in newData.ids){
			if(id != -1) {
				Instantiate(items[id], inv.slots[i].transform);
				inv.isFull[i] = true;
			}
			i += 1;
		}

		if(newData.level != level){
			player.position = spawn.position;
		}

		if(level == 0){
			ItemN[] wrt = new ItemN[newData.itemInM.Length];
			i = 0;
			foreach(string wt in newData.itemInM){
				ItemN m = JsonUtility.FromJson<ItemN>(wt);
				wrt[i] = m;
				i += 1;
			}

			its = new GameObject[newData.itemInM.Length];
			i = 0;
			foreach(ItemN it in wrt){
				GameObject gm = Instantiate(items[it.id].GetComponent<Spawn>().item, it.pos, Quaternion.identity);
				its[i] = gm;
				i += 1;
			}
			btn.isDid = newData.isOpPor;
			btn.Start();
		} else if(level == 1){
			ItemN[] wrt = new ItemN[newData.itemInB.Length];
			i = 0;
			foreach(string wt in newData.itemInB){
				ItemN m = JsonUtility.FromJson<ItemN>(wt);
				wrt[i] = m;
				i += 1;
			}

			its = new GameObject[newData.itemInB.Length];
			i = 0;
			foreach(ItemN it in wrt){
				GameObject gm = Instantiate(items[it.id].GetComponent<Spawn>().item, it.pos, Quaternion.identity);
				its[i] = gm;
				i += 1;
			}
		}

		Trollface.MovementAI.i = newData.s;
		Trollface.transform.position = Trollface.MovementAI.moveSpots[newData.s].position;
		Trollface.dm.i = newData.dialog;
	}

	public void CreateNewTextFile(string data, string name, string way)
	{
		using (StreamWriter sw = new StreamWriter(way + "/" + name,false))
		{
			sw.WriteLine(data);
		}
	}
	public string ReadNewTextFile(string name, string way)
	{
		using (StreamReader sr = new StreamReader(way + "/" + name,true))
		{
			string line = sr.ReadLine();
			return line;
		}
	}
}

struct Data {
	public Vector3 position; //позиция игрока
	public int[] ids;
	public int level;
	public string[] itemInM;
	public string[] itemInB;
	public bool isOpPor;
	public int s;
	public int dialog;

	public Data(Vector3 position, int[] ids, int level, string[] itemInM, string[] itemInB, bool isOpPor, int s, int dialog){
		this.position = position; //приравнивание
		this.ids = ids;
		this.level = level;
		this.itemInM = itemInM;
		this.itemInB = itemInB;
		this.isOpPor = isOpPor;
		this.s = s;
		this.dialog = dialog;
	}
}

struct ItemN {
	public int id;
	public Vector3 pos;

	public ItemN(Vector3 pos, int id){
		this.pos = pos;
		this.id = id;
	}
}