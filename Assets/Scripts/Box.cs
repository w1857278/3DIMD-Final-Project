using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Box : LookObject
{
    public bool requiresItem = true;
    public int itemRequired = 1;
    public Slider verticalSlider;
    float slideValue;

    public Vector3 startPosition;

    public GameObject axe;

    public GameObject box;
    // Start is called before the first frame update
    public override void Start() {
        base.Start();
        startPosition = axe.transform.position;
        axe.SetActive(false);
    }
    public override void Update() {
        base.Update();
        
    }
    public override void InteractingUpdate() {
        base.InteractingUpdate();
         slideValue = verticalSlider.value;
         
        axe.transform.rotation = Quaternion.Euler(-75.57f - (slideValue * 90f) , -90f  , 0f);
        if(slideValue == 1) EndMinigame();
    }
    public void EndMinigame() {
        
        for(int i=0; i<10; i++) {
            box.transform.rotation = Quaternion.Euler(0, -87.17f + (i*10), 0 );
        }
        Invoke("BackOut", 2f);
        
    }
    public override void LeftClickInteraction() {

        base.LeftClickInteraction();
        verticalSlider.gameObject.SetActive(true);
        axe.SetActive(true);

    }
    public override void BackOut() {
        // Removes minigame elements when the player backs out of the minigame
        base.BackOut();
        gameObject.SetActive(false);
        verticalSlider.gameObject.SetActive(false);
        axe.SetActive(false);

    }
}