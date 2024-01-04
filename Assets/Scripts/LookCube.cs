using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookCube : LookObject
{
    public Slider verticalSlider;
    public Slider horizontalSlider;
    
    //When implementing A look object make sure you are using public override methods and including the base methods if they exist in the LookObject class
    public override void Start() {
        base.Start();
    }
    public override void Update() {
        base.Update();
        
    }
    public override void InteractingUpdate() {
        base.InteractingUpdate();
        //This gives the value of the sliders
        Debug.Log(verticalSlider.value);
        Debug.Log(horizontalSlider.value);
    }
    public override void LeftClickInteraction() {

        // Activates the game elements on left click (in this case two sliders)
        base.LeftClickInteraction();
        horizontalSlider.gameObject.SetActive(true);
        verticalSlider.gameObject.SetActive(true);
    }
    public override void BackOut() {
        // Removes minigame elements when the player backs out of the minigame
        horizontalSlider.gameObject.SetActive(false);
        verticalSlider.gameObject.SetActive(false);
    }
}