using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Inventory Inventory;
    public GameObject MessagePanel;
 
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
        // Inventory.ItemRemoved += Inventory_ItemRemoved;

    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        foreach(Transform slot in inventoryPanel)
        {
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();

            if(!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                break;
            }
        }
    }
    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
         foreach(Transform slot in inventoryPanel)
        {
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();

            if(!image.enabled)
            {
                image.enabled = false;
                image.sprite = e.Item.Image;

                break;
            }
        }
    }


    // void Update()
    // {

    // }



    public void OpenMessagePanel(string text)
    {
        MessagePanel.SetActive(true);
    }

     public void CloseMessagePanel()
    {
        MessagePanel.SetActive(false);
    }


}
