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
	public Vipravitel v1;
	public Vipravitel v2;
	public int c;

	void Awake(){
		try {
			ReadState();
		} catch (Exception e) {
			Debug.Log($"Файла нет или {e.ToString()}");
		}
	}

	void Update(){
		
		if(Input.GetKeyDown(KeyCode.I)){
			CreateState(false);
		}
		/*
		try {
			Check();
		} catch (Exception e){
			Debug.Log(e.ToString());
			return;
		}
		*/
	}

	public void Check(){
		/*
			GameObject[] newItems = new GameObject[its.Length-1];
			int i = 0;
			foreach(GameObject gm in its){
				if(gm != null){
					newItems[i] = gm;
					i += 1;
				}
			}

			its = newItems;
		*/
		GameObject[] newItems = new GameObject[its.Length-1];
		short i = 0;
		foreach(GameObject gm in its){
			if(gm != null){
				newItems[i] = gm;
				gm.GetComponent<Pickup>().num = i;
				i += 1;
			}
		}

		its = newItems;
	}

	public short AddItem(GameObject gm){
		GameObject[] temp = its;
		its = new GameObject[temp.Length + 1];
		int i = 0;
		foreach(GameObject t in temp){
			its[i] = t;
			i += 1;
		}
		its[its.Length - 1] = gm;
		return (short) (its.Length - 1);
	}

	public void StartGame(){
		string json = ReadNewTextFile("TEMP.json", "./Saves");
		Data newData = JsonUtility.FromJson<Data>(json);
		SceneManager.LoadScene(newData.level);
	}

	public void CreateState(bool isPortal){
		if(Trollface.isEnded && Trollface.c == c){
			c += 1;
		}
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

		if(isPortal){
			dialog = 0;
		}

		try {
			Data oldData = JsonUtility.FromJson<Data>(ReadNewTextFile("TEMP.json", "./saves"));
			if(level == 0){
				Data newData = new Data(position, ids, level, write, oldData.itemInB, btn.isDid, s, dialog, oldData.v1, oldData.v2, c); //инициализация объекта
				string json = JsonUtility.ToJson(newData);
				CreateNewTextFile(json, "TEMP.json", "./Saves");
			} else if(level == 1){
				Data newData = new Data(position, ids, level, oldData.itemInM, write, oldData.isOpPor, s, dialog, v1.isDid, v2.isDid, c); //инициализация объекта
				string json = JsonUtility.ToJson(newData);
				CreateNewTextFile(json, "TEMP.json", "./Saves");
			}
		} catch (Exception e){
			Data newData = new Data(position, ids, level, write, new string[1], false, s, dialog, false, false, c); //инициализация объекта
			string json = JsonUtility.ToJson(newData);
			CreateNewTextFile(json, "TEMP.json", "./Saves");
			Debug.Log(e.ToString());
		}

	}

	public void ReadState(){
		string json = ReadNewTextFile("TEMP.json", "./Saves");
		Data newData = JsonUtility.FromJson<Data>(json);
		player.position = newData.position;
		short i = 0;
		Inventory inv = player.GetComponent<Inventory>();
		foreach(int id in newData.ids){
			if(id != -1) {
				Instantiate(items[id], inv.slots[i].transform);
				inv.emp = (short) (i+1);
				//inv.isFull[i] = true;
				inv.SetBit(i);
			} else {
				inv.delC += 1;
				inv.ResetBit(i);
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
				GameObject gm = Instantiate(items[it.id].GetComponent<Spawn>().item, it.pos, items[it.id].GetComponent<Spawn>().item.transform.rotation);
				its[i] = gm;
				gm.GetComponent<Pickup>().num = (short) i;
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
				gm.GetComponent<Pickup>().num = (short) i;
				i += 1;
			}
		}

		i = 0;
		for(i = 0; i < its.Length; i++){
			its[i].GetComponent<Pickup>().num = i;
		}

		if(Trollface != null) {
			Trollface.MovementAI.i = newData.s;
			c = newData.c;
			Trollface.transform.position = Trollface.MovementAI.dt[newData.c].moveSpots[newData.s].position;
			Trollface.dm.i = newData.dialog;
			c = newData.c;
			// /Trollface.c = c;
		}

		if(v1 != null){
			v1.isDid = newData.v1;
		}
		if(v2 != null){
			v2.isDid = newData.v2;
		}

		c = newData.c;

		//Inventory inv = player.GetComponent<Inventory>();
		for(byte j = 0; j < inv.slots.Length; j++){
			inv.emp += 1;
		}
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
	public bool v1;
	public bool v2;
	public int c;

	public Data(Vector3 position, int[] ids, int level, string[] itemInM, string[] itemInB, bool isOpPor, int s, int dialog, bool v1, bool v2, int c){
		this.position = position; //приравнивание
		this.ids = ids;
		this.level = level;
		this.itemInM = itemInM;
		this.itemInB = itemInB;
		this.isOpPor = isOpPor;
		this.s = s;
		this.dialog = dialog;
		this.v1 = v1;
		this.v2 = v2;
		this.c = c;
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