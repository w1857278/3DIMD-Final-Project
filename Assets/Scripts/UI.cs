using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController playerScript; 
    public List<Image> inventorySlot = new List<Image>(); 
    
    public Slider horizontalSlider;
    public Slider verticalSlider;

    public TMP_Text coinCounter;
    
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();

        horizontalSlider.gameObject.SetActive(false);
        verticalSlider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateUI() {
        //Updates the coin counter and player inventory. Use UpdateUI() whenever something in the UI needs to change
        coinCounter.text = playerScript.coins.ToString() ;
        for (int i = 0; i < playerScript.inventory.Count; i++) {
            if (i < inventorySlot.Count) {
                inventorySlot[i].sprite = playerScript.inventory[i].icon;
                inventorySlot[i].gameObject.SetActive(true);
            }
        }
    }

}


