using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour
{


    public string itemName;
    public int id;
    public GameObject meshModel;
    public Sprite icon;

    public Item item;
    public PlayerController playerScript;
    
    void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
    }

    public Item(int ID, string NAME, GameObject MESHMODEL, Sprite ICON) {
        id = ID;
        itemName = NAME;
        meshModel = MESHMODEL;
        icon = ICON;
    }
    public Item() {

    }

    public void LeftClickInteraction() {
        Debug.Log("Click");
        item  = new Item(id, itemName, meshModel, icon);
        playerScript.AddItem(item);
        Destroy(gameObject);
    }
}

