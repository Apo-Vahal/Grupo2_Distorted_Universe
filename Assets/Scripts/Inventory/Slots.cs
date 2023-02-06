using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public GameObject items;
    public int ID; //Identificar los items y poder recorrer el inventario buscando un ID especifico
    public string type;
    public string descripcion;
    public bool empty; // Para saber si el slots esta vacio
    public Sprite icon;
    public Transform slotIconGameObject;
    private void Start()
    {
        slotIconGameObject = transform.GetChild(0);
    }


    public void UpdateSlot()
    {
        Debug.Log("ASSAD");
        slotIconGameObject.GetComponent<Image>().sprite = icon;
    }

  
}
