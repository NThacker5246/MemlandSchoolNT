using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    public Transform Camera;
    public int id;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    public void SpawnDroppedItem()
    {
        Vector3 playerPos = new Vector3(player.position.x, player.position.y, player.position.z + 5);
        Instantiate(item, playerPos, Quaternion.identity);
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
    }

    IEnumerator bott(GameObject gm){
        yield return new WaitForSeconds(0.1f); 
        gm.GetComponent<BoxCollider>().isTrigger = false;
        Destroy(gameObject);
    }
}
