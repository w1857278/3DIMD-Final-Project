using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController playerScript; 
    public List<Image> inventorySlot = new List<Image>(); 
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateUI() {
        for (int i = 0; i < playerScript.inventory.Count; i++) {
            if (i < inventorySlot.Count) {
                Debug.Log(playerScript.inventory[i].icon);
                inventorySlot[i].sprite = playerScript.inventory[i].icon;
                inventorySlot[i].gameObject.SetActive(true);
            }
        }
    }

}


