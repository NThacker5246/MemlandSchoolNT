using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    public Transform Camera;
    public int id;
    public SaveToFile sv;

    private void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        sv = GameObject.FindGameObjectWithTag("sv").GetComponent<SaveToFile>();
        player = sv.player;
    }

    public void SpawnDroppedItem()
    {
        Vector3 playerPos = player.position + player.forward*3 - new Vector3(0, 1, 0);
        GameObject gm = Instantiate(item, playerPos, item.transform.rotation);
        short id = sv.AddItem(gm);
        gm.GetComponent<Pickup>().num = id;
    }

    public void ThrowItem()
    {
        Vector3 playerPos = new Vector3(player.position.x, player.position.y, player.position.z);
        Vector3 an = Camera.eulerAngles;
        GameObject gm = Instantiate(item, playerPos, Quaternion.Euler(an));
        gm.GetComponent<BoxCollider>().isTrigger = true;
        gm.GetComponent<Rigidbody>().AddForce(Quaternion.Euler(an)*new Vector3(0, 0, 1000));
        gm.GetComponent<Pickup>().ignore = true;
        StartCoroutine(bott(gm));
        short id = sv.AddItem(gm);
        gm.GetComponent<Pickup>().num = id;
    }

    IEnumerator bott(GameObject gm){
        yield return new WaitForSeconds(0.1f); 
        gm.GetComponent<BoxCollider>().isTrigger = false;
        Destroy(gameObject);
    }
}
