using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{

    public int ID; //Identificar los items
    public string type;
    public string descripcion;
    public Sprite icon;

    [HideInInspector]
    public bool PickedUp;
  
}

