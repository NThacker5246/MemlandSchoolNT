using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
	public GameObject pat;
    public Transform tr;
    public Inventory player;

    public void Start(){
        tr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = tr.GetComponent<Inventory>();
    }

    public void Shoot(){
        player.an.SetBool("LKM", true);
    	//Vector3 tr1 = new Vector3(tr.position.x, tr.position.y, tr.position.z);
        StartCoroutine("Shotted");
    }

    private void OnMouseDown(){
    	Debug.Log("click");
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            foreach(Transform item in player.slots[player.isHOT].transform){
                if(item.tag == transform.tag){
                    Shoot();
                    Debug.Log("Shot");
                }
            }
        } else if(Input.GetMouseButton(1)){
            foreach(Transform item in player.slots[player.isHOT].transform){
                if(item.tag == transform.tag){
                    player.an.SetBool("PKM", true);
                }
            }
        } else if(Input.GetMouseButtonUp(1)){
            foreach(Transform item in player.slots[player.isHOT].transform){
                if(item.tag == transform.tag){
                    player.an.SetBool("PKM", false);
                }
            }
        }

        //StartCoroutine("Shott");
    }

    IEnumerator Shotted(){
        yield return new WaitForSeconds(0.33f);
        Instantiate(pat, tr.position, Quaternion.Euler(tr.eulerAngles));
        yield return new WaitForSeconds(0.66f);
        player.an.SetBool("LKM", false);
    }

    /*
    IEnumerator Shott(){
        if(Input.GetMouseButton(0)){
            foreach(Transform item in player.slots[player.isHOT].transform){
                if(item.tag == transform.tag){
                    yield return new WaitForSeconds(0.25f);
                    Instantiate(pat, tr.position, Quaternion.Euler(tr.eulerAngles));
                    //Debug.Log("Shot");
                }
            }
        }
    }
    */
}
