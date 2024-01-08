using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigMound : LookObject
{
    public bool requiresItem = true;
    public int itemRequired = 1;
    public Slider verticalSlider;
    public int digTurns = 0;
    public float baseScale = 600f;
    public float moundScale = 600f;

    float slideValue;
    float newMoundScale;
    float lastSlideValue = 0;
    float slideDifference;
public override void Start() {
        base.Start();
    }
    public override void Update() {
        base.Update();
        
    }
    public override void InteractingUpdate() {

        base.InteractingUpdate();
         slideValue = verticalSlider.value;
         slideDifference = slideValue - lastSlideValue;
        if(slideDifference > 0) {
            newMoundScale = baseScale - (slideDifference * 600);

            Debug.Log("Mound: " + newMoundScale + " Base: " + baseScale);
            if (newMoundScale < baseScale && newMoundScale > 0) {
                moundScale = newMoundScale;
                transform.localScale = new Vector3(moundScale, moundScale, moundScale);
                transform.position += new Vector3(0, -slideDifference *10, 0);
                baseScale = moundScale;
                
            }
        }
        
        

        if (slideValue >= 0.9f) {
            verticalSlider.value = 0.1f;
           
            if (lastSlideValue < 0.9f) {
                digTurns++;
                if (digTurns == 3) {
                    BackOut(); 
                }
            }
            
        }
        lastSlideValue = slideValue;
        
        
    }
    public override void LeftClickInteraction() {

        base.LeftClickInteraction();
        verticalSlider.gameObject.SetActive(true);

    }
    public override void BackOut() {
        // Removes minigame elements when the player backs out of the minigame
        base.BackOut();
        Destroy(gameObject);
        verticalSlider.gameObject.SetActive(false);
    }
}
