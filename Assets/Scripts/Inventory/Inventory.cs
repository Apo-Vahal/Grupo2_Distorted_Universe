using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private bool inventoryEnabled;
    public GameObject inventory;
    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;
    public GameObject slotHalder;

    void Start()
    {
        allSlots = slotHalder.transform.childCount; //Calcular los slots que tenemos
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHalder.transform.GetChild(i).gameObject;
            if (slot[i].GetComponent<Slots>().items==null)
            {
                slot[i].GetComponent<Slots>().empty = true;
            }
        }
            

        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))//activar y desactivar inventario
        {
            inventory.SetActive(!inventory.gameObject.activeInHierarchy);
        }
        
    }

    private void OnTriggerEnter(Collider other)//Si jugador colisiona con objeto se añade al slot
    {
        if (other.tag=="Item")
        {
            GameObject itemPickedUp = other.gameObject;
            Items items = itemPickedUp.GetComponent<Items>();
            AddItems(itemPickedUp, items.ID, items.type, items.descripcion, items.icon);
        }
    }

    public void AddItems(GameObject itemsObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++) // para añadir el items al slot que encuentre vacio
        {
            if (slot[i].GetComponent<Slots>().empty)
            {
                itemsObject.GetComponent<Items>().PickedUp = true;
                slot[i].GetComponent<Slots>().items = itemsObject;
                slot[i].GetComponent<Slots>().ID = itemID;
                slot[i].GetComponent<Slots>().type = itemType;
                slot[i].GetComponent<Slots>().descripcion = itemDescription;
                slot[i].GetComponent<Slots>().icon = itemIcon;
                itemsObject.transform.parent = slot[i].transform;
                itemsObject.SetActive(false);
                slot[i].GetComponent<Slots>().UpdateSlot();
                slot[i].GetComponent<Slots>().empty = false;

                return; // evitar que el objeto se añada en todos los slots vacios

            }
           
        }
    }
}
