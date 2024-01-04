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
        //Assign the player object
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
    }



    public void LeftClickInteraction() {
        // Create an instance of item class based on assigned properties in Inspector, add it to the player's inventory and then remove this gameobject
        Item item  =  gameObject.AddComponent<Item>();
        item.id = id;
        item.itemName = itemName;
        item.meshModel = meshModel;
        item.icon = icon;
        playerScript.AddItem(item);
        Destroy(gameObject);
    }
}

