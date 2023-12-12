using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour
{


    public string itemName;
    public int id;
    public GameObject meshModel;
    public Sprite icon;

    public PlayerController playerScript;
    
    void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
    }



    public void LeftClickInteraction() {
        Item item  =  gameObject.AddComponent<Item>();
        item.id = id;
        item.itemName = itemName;
        item.meshModel = meshModel;
        item.icon = icon;
        playerScript.AddItem(item);
        Destroy(gameObject);
    }
}

