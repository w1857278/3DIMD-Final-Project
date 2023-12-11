using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{


    private string name;
    private int id;
    private GameObject meshModel;
    private Sprite icon;
    

    public Item(int ID, string NAME, GameObject MESHMODEL, Sprite ICON) {
        id = ID;
        name = NAME;
        meshModel = MESHMODEL;
        icon = ICON;
    }
}
