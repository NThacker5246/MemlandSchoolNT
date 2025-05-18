using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	//public bool[] isFull;
	public int isHOT;
	public byte isF;
	public GameObject[] slots;

	public short emp = 0;
	public short ful = 0;
	public byte delC;

	public Animator an;

	[SerializeField] private GameObject[] items;
	[SerializeField] private GameObject[] itemsInSlot;
	[SerializeField] private MinHeap que;

	void Awake(){
		que = new MinHeap(7);
		for(int i = 0; i < 7; i++){
			que.Insert(i);
		}
	}

	public void AddItem(int id){
		int slot = que.ExtractMin();
		Instantiate(itemsInSlot[id], slots[slot].transform);
	}

	private void Update()
	{
		
		for (int i = 0; i < 7; i++) {
			if (Input.GetKeyDown(KeyCode.Alpha1 + i)) {
				isHOT = i;
			}
		}

		if (Input.GetKeyDown(KeyCode.Q)){
			slots[isHOT].GetComponent<Slot>().DropItem();
		}

		if (Input.GetKeyDown(KeyCode.E) && slots[isHOT].transform.childCount > 0 && slots[isHOT].transform.GetChild(0).tag == "bottle1") {
			slots[isHOT].GetComponent<Slot>().Throw2Item();
		}

	}

	private void CheckAnimation(){
		int j = 0;
		foreach(Transform item in slots[isHOT].transform){
			if(item.tag == "pick"){
				an.SetBool("inHandPick", true);
				an.SetBool("inHandAxe", false);
				an.SetBool("inHandCard", false);
				an.SetBool("inHandGun", false);
				an.SetBool("inbot", false);
			} else if(item.tag == "axe"){
				an.SetBool("inHandPick", false);
				an.SetBool("inHandAxe", true);
				an.SetBool("inHandCard", false);
				an.SetBool("inHandGun", false);
				an.SetBool("inbot", false);
			} else if(item.tag == "Card"){
				an.SetBool("inHandPick", false);
				an.SetBool("inHandAxe", false);
				an.SetBool("inHandCard", true);
				an.SetBool("inHandGun", false);
				an.SetBool("inbot", false);
			} else if(item.tag == "Gun"){
				an.SetBool("inHandPick", false);
				an.SetBool("inHandAxe", false);
				an.SetBool("inHandCard", false);
				an.SetBool("inHandGun", true);
				an.SetBool("inbot", false);
			}  else if(item.tag == "bottle1"){
				an.SetBool("inHandPick", false);
				an.SetBool("inHandAxe", false);
				an.SetBool("inHandCard", false);
				an.SetBool("inHandGun", false);
				an.SetBool("inbot", true);
			} else {
				an.SetBool("inHandPick", false);
				an.SetBool("inHandAxe", false);
				an.SetBool("inHandCard", false);
				an.SetBool("inHandGun", false);
				an.SetBool("inbot", false);
			}
			j += 1;
		}

		if(j == 0){
			an.SetBool("inHandPick", false);
			an.SetBool("inHandAxe", false);
			an.SetBool("inHandCard", false);
			an.SetBool("inHandGun", false);
			an.SetBool("inbot", false);
		}
	}

	public bool IsSetBit(short i){
		byte cb = (byte) (1 << i);
		if((byte) (isF & cb) > 0){
			return true;
		} else {
			return false;
		}
	}

	public void SetBit(short i){
		byte cb = (byte) (1 << i);
		isF = (byte) (isF | cb);
	}

	public void ResetBit(int i){
		byte cb = (byte) (1 << i);
		cb = (byte) ~cb;
		isF = (byte) (isF & cb);
	}
}

[System.Serializable]
public class MinHeap
{
	private int[] heap;
	private int size;
	private int capacity;

	public MinHeap(int capacity)
	{
		this.capacity = capacity;
		heap = new int[capacity];
		size = 0;
	}

	private int Parent(int i)
	{
		return (i - 1) / 2;
	}

	private int LeftChild(int i)
	{
		return 2 * i + 1;
	}

	private int RightChild(int i)
	{
		return 2 * i + 2;
	}

	private void Swap(int i, int j)
	{
		int temp = heap[i];
		heap[i] = heap[j];
		heap[j] = temp;
	}

	private void HeapifyUp(int i)
	{
		while (i > 0 && heap[i] < heap[Parent(i)])
		{
			Swap(i, Parent(i));
			i = Parent(i);
		}
	}

	private void HeapifyDown(int i)
	{
		int minIndex = i;
		int left = LeftChild(i);
		int right = RightChild(i);

		if (left < size && heap[left] < heap[minIndex])
		{
			minIndex = left;
		}

		if (right < size && heap[right] < heap[minIndex])
		{
			minIndex = right;
		}

		if (i != minIndex)
		{
			Swap(i, minIndex);
			HeapifyDown(minIndex);
		}
	}

	public void Insert(int value)
	{
		if (size == capacity)
		{
			return;
		}

		heap[size++] = value;
		HeapifyUp(size - 1);
	}

	public int ExtractMin()
	{
		if (size == 0)
		{
			return -1;
		}

		int min = heap[0];
		heap[0] = heap[size - 1];
		size--;
		HeapifyDown(0);

		return min;
	}

	public int GetMin()
	{
		if (size == 0) {
			return -1;
		}

		return heap[0];
	}

	public bool IsEmpty()
	{
		return size == 0;
	}

}